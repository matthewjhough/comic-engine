using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    [Table ("ComicDates")]
    public class ComicDate {
        [Key]
        public int Id { get; set; }

        public DateTime _Date { get; set; }

        public string Type { get; set; }
    }
}