using System;
using System.Collections.Generic;
using ComicEngineCommon;

namespace ComicEngineApi.Marvel {
    public class MarvelComics {
        public int Id { get; set; }

        public int DigitalId { get; set; }

        public string Title { get; set; }

        public double IssueNumber { get; set; }

        public string VariantDescription { get; set; }

        public string Description { get; set; }

        public DateTime Modified { get; set; }

        public string Isbn { get; set; }

        public string Upc { get; set; }

        public string DiamondCode { get; set; }

        public string Ean { get; set; }

        public string Issn { get; set; }

        public string Format { get; set; }

        public int PageCount { get; set; }

        public List<TextObject> TextObjects { get; set; }

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