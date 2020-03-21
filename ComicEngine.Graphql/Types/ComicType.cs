using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class ComicType : ObjectType<Comic> {
        protected override void Configure (IObjectTypeDescriptor<Comic> descriptor) {
            descriptor.Field (t => t.Characters).Type<ProfileType> ();
            descriptor.Field (t => t.Creators).Type<ProfileType> ();
        }
    }
}