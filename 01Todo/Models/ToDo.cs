using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01Todo.Models
{
    public class ToDo
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
    }
}