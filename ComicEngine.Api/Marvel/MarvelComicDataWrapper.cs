using System;
using System.Collections.Generic;

namespace ComicEngine.Api.Marvel {
    /// <summary>
    /// Gemeral Pagination wrapper around Marvel Comic Results.
    /// </summary>
    public class MarvelComicDataWrapper {

        /// <summary>
        /// Number of comics to skip to return results.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// How many comics should be returned.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Total number of comics found with query.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// How many comics were returned in request.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Various items included in the list returned by Marvel API.
        /// </summary>
        public List<MarvelComic> Results { get; set; }
    }
}