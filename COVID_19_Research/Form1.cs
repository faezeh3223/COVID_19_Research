using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elasticsearch;
using Elasticsearch.Net;
using Nest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using ExcelDataReader;

namespace COVID_19_Research
{
    public partial class Form1 : Form
    {
        List<Article> SearchResult = new List<Article>(); //for store search indexes results
        string index_name = "corona_index"; //the index name for elasticsearch index
        List<Article> articles = new List<Article>();//all of the parse objects from .json files to class onjects
        List<string> columnNames = new List<string>();//for store .csv columns
        string[][] valueArray;//for store .csv rows
        Uri node;//elasticsearch uri based on it's document
        ConnectionSettings settings;//elasticsearch connection setting based on it's document
        ElasticClient client;//elasticsearch high level client based on it's document
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//opening .csv file start:
        {
            string fileFullPath;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "csv file (*.csv)|*.csv";//set limitation for file type selecting
            ofd.Title = "Select the all_source_metadata.csv file.";
            while (ofd.ShowDialog() != DialogResult.OK) ;//force user to select a .csv file by a loop
            fileFullPath = ofd.FileName;//get the .csv path
            

            FileStream stream = File.Open(fileFullPath, FileMode.Open, FileAccess.Read);//file stream reader for read .csv
            IExcelDataReader reader = null;
            try
            {

                //Must check file extension to adjust the reader to the .csv file type

                reader = ExcelReaderFactory.CreateCsvReader(stream);

                if (reader != null)
                {
                    //Fill DataSet
                    DataSet content = reader.AsDataSet();
                    List<DataRow> Rows = content.Tables[0].Rows.Cast<DataRow>().ToList();//get all rows in a single command
                    content = null;//release memory space
                    GC.Collect();//call the garbage collector to collect and free the memory
                    valueArray = Rows.Select(element => element.ItemArray.Cast<string>().ToArray()).ToArray();//cast all rows in a 2D array for better action
                    Rows = null;//free and release all non-used memory spaces
                    reader.Close();
                    stream.Close();
                    GC.Collect();
                    //get all columns:
                    for (int colIndex = 0; colIndex < valueArray[0].Length; colIndex++)
                    {
                        if (valueArray[0][colIndex] != null
                            && !string.IsNullOrEmpty(valueArray[0][colIndex]))
                        {
                            // Get name of all columns in the first sheet
                            columnNames.Add(valueArray[0][colIndex]);
                        }
                    }
                    //Read....
                    MessageBox.Show((valueArray.Length - 1) + " Metadata Added Successful!");//show a message to user with details
                    jsonBtn.Enabled = true;//turn on the next button for action
                }
            }
            catch (System.Exception generalException)
            {
                //error handling accourse reading .csv
                MessageBox.Show(generalException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (stream != null)
                {
                    // Close the workbook after job is done or exception
                    stream.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }





        }

        private void jsonBtn_Click(object sender, EventArgs e)//read .json files and parse them to class objects
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select directory of .JSON articles";
            string fileName;
            while (fbd.ShowDialog() != DialogResult.OK) ;
            fileName = fbd.SelectedPath;
            List<string> files = Directory.GetFiles(fileName).ToList();
            files.RemoveAll(element => element.Split('\\').Last().First() == '.');//remove all temp and thumb files (hidden thumb files)
            int start = articles.Count;//get start index for action
            articles.AddRange(files.Select(s => JsonConvert.DeserializeObject<Article>(File.ReadAllText(s))).Where(element => !articles.Exists(art => art.paper_id == element.paper_id)));//parse all .json files in a single command by linq option
            for (int i = start; i < articles.Count; i++)//match and set all details from .csv to .json and store all things in an object class
            {
                var item = valueArray.First(element => element[0] == articles[i].paper_id);
                if (item != null)
                {
                    for (int col = 0; col < columnNames.Count; col++)
                    {
                        if (typeof(Article).GetProperties().ToList().Exists(element => element.Name == columnNames[col]))//set all property matched with the name of columns (eg. object.doi = doi)
                        {
                            articles[i][columnNames[col]] = item[col];
                        }
                    }
                }
            }
            MessageBox.Show((articles.Count - start) + " new articles added and all articles count is " + articles.Count + " now");//show a message to user with details.
            jsonBtn.Text = "Open Another .JSON Files";//change the name of current button to understanding for add another .json files
            indexBtn.Enabled = true;//turn on next button

        }

        private void indexBtn_Click(object sender, EventArgs e)//indexing or PUT in to elasticsearch index:
        {
            //get all doi for generate PageRank:
            var BifEnts = articles.Select(art => art.bib_entries).ToList(); BifEnts.RemoveAll(art => art == null);
            var OtherIDs = BifEnts.SelectMany(dic => dic.Values).ToList(); OtherIDs.RemoveAll(dic => dic == null);
            var DOIs = OtherIDs.Select(ids => ids.other_ids).ToList(); DOIs.RemoveAll(ids => ids == null); DOIs.RemoveAll(ids => ids.DOI == null);
            var RealDOI = DOIs.SelectMany(doi => doi.DOI).ToList();
            for (int i = 0; i < articles.Count; i++)
            {
                
               articles[i].PageRank = RealDOI.Where(doi=>doi==articles[i].doi).Count();//set pagerank by number of call this article for ref
            }
            List<Result> results = new List<Result>();//to store the results of calling PUT on elasticsearch
            foreach (var art in articles)
            {
                var response = client.Index(art, idx => idx.Index(index_name));//PUT in default index on elasticSearch
                results.Add(response.Result);
            }
            //show a message to user with details of PUT results.
            MessageBox.Show("Created = " + results.Where(element => element == Result.Created).Count() + ", Error = " + results.Where(element => element == Result.Error).Count() + ", Updated = " + results.Where(element => element == Result.Updated).Count() + ".");
        }

        private void advanceSearchRadio_CheckedChanged(object sender, EventArgs e)//changing between advance or simple search and turn on-off controlls
        {
            if (advanceSearchRadio.Checked)
            {
                AdvanceGroup.Enabled = true;
                AdvanceGroup.Visible = true;
                searchBox.Enabled = false;
            }
            else
            {
                AdvanceGroup.Enabled = false;
                AdvanceGroup.Visible = false;
                searchBox.Enabled = true;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)//start GET or search on elasticsearch default index :
        {
            if (advanceSearchRadio.Checked)//advance search section:
            {
                List<KeyValuePair<decimal, List<Article>>> searchResponses = new List<KeyValuePair<decimal, List<Article>>>();//intersect of filters
                List<KeyValuePair<decimal,List<Article>>> searchResponsesTitle = new  List<KeyValuePair<decimal, List<Article>>>();//title filter
                List<KeyValuePair<decimal, List<Article>>> searchResponsesAbstract = new List<KeyValuePair<decimal, List<Article>>>();//abstract filter
                List<KeyValuePair<decimal, List<Article>>> searchResponsesTime = new List<KeyValuePair<decimal, List<Article>>>();//time filter
                //get all words from the filters :
                var titleTokens = titleBox.Text.ToLower().Split(' ', ',', '\n');
                var abstractTokens = abstractBox.Text.ToLower().Split(' ', ',', '\n');
                var timeTokens = timeBox.Text.ToLower().Split(' ', ',', '\n');
                foreach(var t in titleTokens)//search all title words on elasticsearch and get parse objects
                    searchResponsesTitle.Add(new KeyValuePair<decimal, List<Article>>(titleWeight.Value,client.Search<Article>(descriptor => descriptor.Size(10000)
        .Query(q => q
            .QueryString(queryDescriptor => queryDescriptor
                .Query(t)
                .Fields(fs => fs
                    .Fields(f1 => f1.metadata.title.ToLower())
                )
            )
        )).Documents.ToList()));
                foreach (var t in abstractTokens)//search all abstract words on elasticsearch and get parse objects
                    searchResponsesAbstract.Add(new KeyValuePair<decimal, List<Article>>(abstractWeight.Value, client.Search<Article>(descriptor => descriptor.Size(10000)
             .Query(q => q
                 .QueryString(queryDescriptor => queryDescriptor
                     .Query(t)
                     .Fields(fs => fs
                         .Fields(f1 => String.Join(" ", f1.abstracts.Select(ab => ab.text)))
                     )
                 )
             )).Documents.ToList()));
                foreach (var t in timeTokens)//search all greater than or equal publish time on elasticsearch and get parse objects
                    searchResponsesTime.Add(new KeyValuePair<decimal, List<Article>>(timeWeight.Value, client.Search<Article>(descriptor => descriptor.Size(10000)
             .Query(q => q
                 .TermRange(r => r
                     .Field(f => f.publish_time.ToLower())
                     .GreaterThanOrEquals(t)
                     )
                 )
             ).Documents.ToList()));
                //merge and intersect of filters: sum(weight) => intersect results
                searchResponses.Add(new KeyValuePair<decimal, List<Article>>(titleWeight.Value + abstractWeight.Value, searchResponsesTitle.SelectMany(s => s.Value).Where(w => searchResponsesAbstract.SelectMany(a => a.Value).ToList().Exists(el => el.paper_id == w.paper_id)).ToList()));
                searchResponses.Add(new KeyValuePair<decimal, List<Article>>(titleWeight.Value + timeWeight.Value, searchResponsesTitle.SelectMany(s => s.Value).Where(w => searchResponsesTime.SelectMany(a => a.Value).ToList().Exists(el => el.paper_id == w.paper_id)).ToList()));
                searchResponses.Add(new KeyValuePair<decimal, List<Article>>(abstractWeight.Value + timeWeight.Value, searchResponsesAbstract.SelectMany(s => s.Value).Where(w => searchResponsesTime.SelectMany(a => a.Value).ToList().Exists(el => el.paper_id == w.paper_id)).ToList()));
                searchResponses.Add(new KeyValuePair<decimal, List<Article>>(titleWeight.Value + abstractWeight.Value+timeWeight.Value, searchResponsesTitle.SelectMany(s => s.Value).Where(w => searchResponsesAbstract.SelectMany(a => a.Value).ToList().Exists(el => el.paper_id == w.paper_id)).Where(ww=> searchResponsesTime.SelectMany(aa => aa.Value).ToList().Exists(ell => ell.paper_id == ww.paper_id)).ToList()));
                //union of results:
                searchResponses.AddRange(searchResponsesTitle);
                searchResponses.AddRange(searchResponsesAbstract);
                searchResponses.AddRange(searchResponsesTime);
                //clear pointers
                searchResponsesTime = null;
                searchResponsesTitle = null;
                searchResponsesAbstract = null;
                searchResponses = searchResponses.OrderByDescending(a => a.Key).ToList();//sort by weight pair(weight , list)
                if(PageRankCheckBox.Checked)
                {
                    for (int i = 0; i < searchResponses.Count; i++)//sort by pagerank if it's on:
                        searchResponses[i] = new KeyValuePair<decimal, List<Article>>(searchResponses[i].Key,searchResponses[i].Value.OrderByDescending(a => a.PageRank).ToList());
                }
                SearchResult = searchResponses.SelectMany(s => s.Value).ToList();//get all sorted results to a single list
                try
                {
                    SearchResult.RemoveRange(10, SearchResult.Count - 10);//try to get only top 10 of search result
                }
                catch { }
                GC.Collect();
                

            }
            else
            {
                //same as the advance search but searching on all parameters here:
                string[] tokens = searchBox.Text.ToLower().Split(' ', ',', '\n');
                List<Article> searchResponses = new List<Article>();
                foreach(var t in tokens)
                {
                    searchResponses.AddRange(client.Search<Article>(descriptor => descriptor.Size(10000)
        .Query(q => q
            .QueryString(queryDescriptor => queryDescriptor
                .Query(t)
                .Fields(fs => fs
                    .Fields(f1 => f1.metadata.title.ToLower())
                )
            )
        )).Documents.ToList());
                    searchResponses.AddRange(client.Search<Article>(descriptor => descriptor.Size(10000)
             .Query(q => q
                 .QueryString(queryDescriptor => queryDescriptor
                     .Query(t)
                     .Fields(fs => fs
                         .Fields(f1 => String.Join(" ", f1.abstracts.Select(ab => ab.text)))
                     )
                 )
             )).Documents.ToList());
                    searchResponses.AddRange(client.Search<Article>(descriptor => descriptor.Size(10000)
             .Query(q => q
                 .TermRange(r => r
                     .Field(f => f.publish_time.ToLower())
                     .GreaterThanOrEquals(t)
                     )
                 )
             ).Documents.ToList());
                }
                if(PageRankCheckBox.Checked)
                {
                    searchResponses.OrderByDescending(a => a.PageRank);//sort by pagerank if it's on
                }
                SearchResult = searchResponses;
                try
                {
                    SearchResult.RemoveRange(10, SearchResult.Count - 10);//try to get only top 10 of search results
                }
                catch { }
                GC.Collect();//free space
            }
            new SearchForm(SearchResult).ShowDialog();//display results
        }

        private void button1_Click_1(object sender, EventArgs e)//connect to the elasticsearch service:
        {
            try
            {
                node = new Uri("http://localhost:9200");
                settings = new ConnectionSettings(node);
                client = new ElasticClient(settings);
                
                var resp = client.Index(new Article(), idx => idx.Index(index_name));
                if (resp.IsValid)//check if connection is valid
                {
                    csvBtn.Enabled = true;
                    searchBtn.Enabled = true;
                    connectBtn.Enabled = false;
                    connectBtn.Text = "Connected";
                    connectBtn.BackColor = Color.LightGreen;
                }
                else//show message if connection is invalid and get out of function
                {
                    MessageBox.Show("Connection failed!");
                    return;
                }
                settings.DefaultIndex(index_name);
                settings.DefaultMappingFor<Article>(i => i.IndexName(index_name).IdProperty(p => p.paper_id));
                //set the fields limitation of index in elasticsearch server based on it's document (defualt = 1,000 in our project = 100,000):
                client.LowLevel.Indices.UpdateSettingsForAll<StringResponse>(PostData.Serializable(new { index = new { mapping = new { total_fields = new { limit = 100000 } } } }));
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);//error handling
            }
        }
    }
}
