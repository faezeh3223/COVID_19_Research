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
    public partial class DisplayForm : Form
    {
        public DisplayForm(Article article)
        {
            InitializeComponent();
            textBox1.Text = 
                "Title : " + article.metadata.title+Environment.NewLine
                + "Authors : " + String.Join(Environment.NewLine,article.metadata.authors) + Environment.NewLine
                + "Abstract : " + String.Join(Environment.NewLine,article.abstracts);

        }
    }
}
