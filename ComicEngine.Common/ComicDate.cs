using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    public class ComicDate {
        [ForeignKey ("Comic")]
        public int ComicDateId { get; set; }

        public DateTime _Date { get; set; }

        public string Type { get; set; }
    }
}