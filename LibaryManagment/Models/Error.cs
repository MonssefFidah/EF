using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibaryManagment.Models
{
    public class Error
    {
        public int ID { get; set; }

        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}