using KeplerCrud.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerCrud.Model
{
    public class Student
    {
        [KeplerColumn]
        public int Raj { get; set; }
        [KeplerColumn]
        public int User { get; set; }
        [KeplerColumn]
        public int Name { get; set; }
    }
}
