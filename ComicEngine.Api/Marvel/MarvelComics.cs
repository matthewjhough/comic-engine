using System;
using System.Collections.Generic;
using ComicEngineCommon;

namespace ComicEngineApi.Marvel {
    public class MarvelComics {

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

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public DateTime Modified { get; set; }

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
        public List<TextObject> TextObjects { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string ResourceUri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<ComicUrl> Urls { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public ComicResource ComicSeries { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<ComicResource> Variants { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<ComicResource> Collections { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<ComicResource> CollectedIssues { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<ComicDate> Dates { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<ComicPrice> Prices { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public ComicImageResource Thumbnail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<ComicImageResource> Images { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Profile Creators { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Profile Characters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Profile Stories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Profile Events { get; set; }
    }
}