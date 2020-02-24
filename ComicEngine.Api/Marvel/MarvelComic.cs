using System;
using System.Collections.Generic;
using ComicEngine.Common;

namespace ComicEngine.Api.Marvel {
    public class MarvelComic {

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int DigitalId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public double IssueNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string VariantDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Description { get; set; }

        // TODO: CONVERT TO DATETIME
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Modified { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Isbn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Upc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string DiamondCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Ean { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Issn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Format { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int PageCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IEnumerable<TextObject> TextObjects { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string ResourceUri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IEnumerable<ComicUrl> Urls { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public ComicResource ComicSeries { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IEnumerable<ComicResource> Variants { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IEnumerable<ComicResource> Collections { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IEnumerable<ComicResource> CollectedIssues { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IEnumerable<ComicDate> Dates { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IEnumerable<ComicPrice> Prices { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public ComicImageResource Thumbnail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IEnumerable<ComicImageResource> Images { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public CreatorProfile Creators { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public CharacterProfile Characters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public StoryProfile Stories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public EventProfile Events { get; set; }
    }
}