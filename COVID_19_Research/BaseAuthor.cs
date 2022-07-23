using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID_19_Research
{
    public class BaseAuthor
    {
        public string first { set; get; }
        public List<string> middle { set; get; }
        public string last { set; get; }
        public string suffix { set; get; }
        public override string ToString()
        {
            return first + "," + String.Join(",", middle) + "," + last + suffix;
        }

    }
    public class Author:BaseAuthor
    {
        public Affiliation affiliation { set; get; }
        public string email { set; get; }
        public override string ToString()
        {
            return base.ToString() + ", email : " + email;
        }
    }
}
