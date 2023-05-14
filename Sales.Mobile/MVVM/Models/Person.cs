using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Mobile.MVVM.Models
{
    public class Person
    {
        public String Name { get; set; }

        public int Age { get; set; }

        public bool IsMarried { get; set; }

        public DateTime Birthday { get; set; }

        public int Weight { get; set; }

        public TimeSpan LunchTime { get; set; }
    }
}
