namespace ComicEngine.Common {
    public class Profile {

        public int Available { get; set; }

        public int Returned { get; set; }

        public string CollectionUri { get; set; }

        public List<ProfileItem> Items { get; set; }
    }
}