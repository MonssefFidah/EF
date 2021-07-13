using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibaryManagment.ViewModels
{
    public class CreateBookViewModel
    {
        public Models.Book Book { get; set; }
        public List<Models.Author> Authors { get; set; }
        public List<Models.User> Users { get; set; }
    }
}