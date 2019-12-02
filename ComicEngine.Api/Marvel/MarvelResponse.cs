using System;

namespace ComicEngine.Api.Marvel {
    public class MarvelResponse {

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Copyright { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AttributionText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AttributionHTML { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public MarvelComicData Data { get; set; }
    }
}