using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace ComicEngine.Common.Comic {
    public class ComicDate {
        [ForeignKey ("Comic")]
        [GraphQLIgnore]
        public int ComicDateId { get; set; }

        public DateTime _Date { get; set; }

        public string Type { get; set; }
    }
}