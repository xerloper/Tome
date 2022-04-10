using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tome
{
    class Manager
    {
        public static Frame MainFrame { get; set; }

        public static TomeEntities DBModel { get; set; }

        public static List<Product> products { get; set; }
    }
}
