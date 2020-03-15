using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common.Comic {
    [Table ("Comics")]
    public class Comic : ComicBase {

        [Key]
        public int StorageId { get; set; }
    }
}