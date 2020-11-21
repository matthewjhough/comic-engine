using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common.Comics {
    [Table ("TextObjects")]
    public class TextObject {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Language { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Text { get; set; }
    }
}