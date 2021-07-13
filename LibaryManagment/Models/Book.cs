using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibaryManagment.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public string ISBN { get; set; }
        public bool Avaible { get; set; }

        public User CurresntUSer { get; set; }
    }
}