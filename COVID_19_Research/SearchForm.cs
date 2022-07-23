using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVID_19_Research
{
    public partial class SearchForm : Form
    {
        List<Article> items;
        public SearchForm(List<Article> articles)
        {
            InitializeComponent();
            items = articles;
            foreach(var a in articles)
            {
                listBox1.Items.Add(a.doi + " , Title : " + a.metadata.title);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            new DisplayForm(items[listBox1.SelectedIndex]).ShowDialog();
        }
    }
}
