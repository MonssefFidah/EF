using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibaryManagment.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }


        public List<Book> Books { get; set; }

    }
}