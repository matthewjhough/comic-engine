using System;
namespace ComicEngine.Marvel
{
    public class MarvelResponse
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHTML { get; set; }
        public MarvelComicData MarvelComicData { get; set; }
    }
}
