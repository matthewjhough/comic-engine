﻿using System;

namespace ComicEngineApi.Marvel {
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
        public MarvelComicData MarvelComicData { get; set; }
    }
}