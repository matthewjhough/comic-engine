using ComicEngine.Common.UserComics;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types
{
    public class UserComicType : ObjectType<UserComic>
    {
        protected override void Configure (IObjectTypeDescriptor<UserComic> descriptor) { }
    }
}