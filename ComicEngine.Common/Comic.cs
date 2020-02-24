using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    [Table ("Comics")]
    public class Comic {

        [Key]
        public int StorageId { get; set; }

        /// <summary>
        /// Issue id (ideally taken from data source)
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        public string Copyright { get; set; }

        public double IssueNumber { get; set; }

        public string Title { get; set; }

        public string Upc { get; set; }

        public string Description { get; set; }

        [ForeignKey ("ComicStorageId")]
        public CharacterProfile Characters { get; set; }

        /// <summary>
        /// List of all authors/artists involved with creation of comic.
        /// </summary>
        /// <value></value>
        [ForeignKey ("ComicStorageId")]
        public CreatorProfile Creators { get; set; }

        /// <summary>
        /// Which series the issue is a member of.
        /// </summary>
        /// <value></value>
        public ComicResource Series { get; set; }

        /// <summary>
        /// Dates of publication for comic issue.
        /// </summary>
        /// <value></value>
        public IEnumerable<ComicDate> PublishDates { get; set; }

        /// <summary>
        /// Number of pages in comic issue.
        /// </summary>
        /// <value></value>
        public int PageCount { get; set; }

        /// <summary>
        /// Link to source material of data.
        /// </summary>
        /// <value></value>
        public string ResourceUri { get; set; }

        /// <summary>
        /// Combination of Response's thumbnail url + file extension (ex: .jpg or .png)
        /// </summary>
        /// <value></value>
        public string Thumbnail { get; set; }

        /// <summary>
        /// List of all media surrounding current issue. Broken into type of media
        /// in addition to a link to the source material.
        /// </summary>
        /// <value></value>
        public IEnumerable<ComicUrl> RelevantLinks { get; set; }
    }
}