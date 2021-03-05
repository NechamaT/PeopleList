using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleList.Data;

namespace PeopleList.Models
{
    public class IndexViewModel
    {
        public List<Person> People { get; set; }

        public string Message { get; set; }
    }
}
