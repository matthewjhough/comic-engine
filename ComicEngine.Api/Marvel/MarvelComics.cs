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

        // TODO: Create objects for all of these, and put them in common
        //        "urls": [
        //            {
        //                "type": "string",
        //                "url": "string"
        //            }
        //        ],
        //        "series": {
        //            "resourceURI": "string",
        //            "name": "string"
        //        },
        //        "variants": [
        //            {
        //                "resourceURI": "string",
        //                "name": "string"
        //            }
        //        ],
        //        "collections": [
        //            {
        //                "resourceURI": "string",
        //                "name": "string"
        //            }
        //        ],
        //        "collectedIssues": [
        //            {
        //                "resourceURI": "string",
        //                "name": "string"
        //            }
        //        ],
        //        "dates": [
        //            {
        //                "type": "string",
        //                "date": "Date"
        //            }
        //        ],
        //        "prices": [
        //            {
        //                "type": "string",
        //                "price": "float"
        //            }
        //        ],
        //        "thumbnail": {
        //            "path": "string",
        //            "extension": "string"
        //        },
        //        "images": [
        //            {
        //                "path": "string",
        //                "extension": "string"
        //            }
        //        ],
        //        "creators": {
        //            "available": "int",
        //            "returned": "int",
        //            "collectionURI": "string",
        //            "items": [
        //                {
        //                    "resourceURI": "string",
        //                    "name": "string",
        //                    "role": "string"
        //                }
        //            ]
        //        },
        //        "characters": {
        //            "available": "int",
        //            "returned": "int",
        //            "collectionURI": "string",
        //            "items": [
        //                {
        //                    "resourceURI": "string",
        //                    "name": "string",
        //                    "role": "string"
        //                }
        //            ]
        //        },
        //        "stories": {
        //            "available": "int",
        //            "returned": "int",
        //            "collectionURI": "string",
        //            "items": [
        //                {
        //                    "resourceURI": "string",
        //                    "name": "string",
        //                    "type": "string"
        //                }
        //            ]
        //        },
        //        "events": {
        //            "available": "int",
        //            "returned": "int",
        //            "collectionURI": "string",
        //            "items": [
        //                {
        //                    "resourceURI": "string",
        //                    "name": "string"
        //                }
        //            ]
        //        }
        //    }
        //]
    }
}