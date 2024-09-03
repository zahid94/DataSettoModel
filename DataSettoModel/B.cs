using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSettoModel
{
    public class B
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class C
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class A
    {
        public List<B> B { get; set; }
        public List<C> C { get; set; }
    }
}
