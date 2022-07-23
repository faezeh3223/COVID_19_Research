using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace COVID_19_Research
{
    public class BIBREF
    {
        public string ref_id { set; get; }
        public string title { set; get; }
        public List<BaseAuthor> authors { set; get; }
        public object year { set; get; }
        public string venue { set; get; }
        public string volume { set; get; }
        public string issn { set; get; }
        public string pages { set; get; }
        public class Others
        {
            public List<string> DOI { set; get; }
        }
        public Others other_ids { set; get; }
        
    }
}
