using ComicEngine.Shared.UserComics;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Server.Impl.Types
{
    public class UserComicType : ObjectType<UserComic>
    {
        protected override void Configure (IObjectTypeDescriptor<UserComic> descriptor) { }
    }
}