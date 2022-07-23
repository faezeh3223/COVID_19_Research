using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID_19_Research
{
    public class DocAbstract
    {
        public string text { set; get; }
        public List<Span> cite_spans { set; get; }
        public List<Span> ref_spans { set; get; }
        public string section { set; get; }
        public override string ToString()
        {
            return "[" + section + "]" + Environment.NewLine + text + "[" + section + "]";
        }

    }
}
