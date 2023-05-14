using Sales.Mobile.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Mobile.MVVM.ViewModels
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {
            Person = new()
            {
                Name = "Jair Arango",
                Age = 48,
                Birthday = new DateTime(1995,12,31),
                IsMarried= true,
                LunchTime= new TimeSpan(2, 0, 0),
                Weight = 75,
            };
        }

        public Person Person { get; set; }
    }
}
