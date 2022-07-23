using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace COVID_19_Research
{
    public class Metadata
    {
        public string title { set; get; }
        public List<Author> authors { set; get; }
        
    }
}
