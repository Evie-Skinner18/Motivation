using System;
using System.Collections.Generic;

namespace Motivation.Data.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public string ImageUrl { get; set; }

        //public IEnumerable<string> LanguagesAvailable { get; set; }
    }
}
