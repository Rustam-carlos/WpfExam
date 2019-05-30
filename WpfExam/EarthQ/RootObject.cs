using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExam.EarthQ
{
    public class RootObject
    {
        public string type { get; set; }
        public Metadata metadata { get; set; }
        public List<Feature> features { get; set; }
        public List<double> bbox { get; set; }
        public override string ToString()
        {
            return type;
        }
    }
}
