using Autofac.Features.Metadata;
using Nest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace COVID_19_Research
{
    [ElasticsearchType(RelationName = "article")]
    public class Article
    {
        public string paper_id { set; get; }
        [Text(Name = "publish_time")]
        public string publish_time { set; get; }
        public string doi { set; get; }
        public string source_x { set; get; }
        public string pmcid { set; get; }
        public string pubmed_id { set; get; }
        public string license { set; get; }
        public string journal { set; get; }
        public int PageRank { set; get; } = 0;
        public Metadata metadata { set; get; }
        [JsonProperty("abstract")]
        public List<DocAbstract> abstracts { set; get; }
        public List<Paragraph> body_text { set; get; }
        public Dictionary<string, BIBREF> bib_entries { set; get; }
        public Dictionary<string, FIGTAB> ref_entries { set; get; }
        public List<Paragraph> back_matter { set; get; }
        public virtual object this[string propertyName]//.net indexer to get and set a property with the name string (eg. used for .csv columns name matched property)
        {
            get
            {
                // probably faster without reflection:
                // like:  return Properties.Settings.Default.PropertyValues[propertyName] 
                // instead of the following
                Type myType = typeof(Article);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(Article);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }

        }

    }
}