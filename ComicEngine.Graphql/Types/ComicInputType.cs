using ComicEngine.Common.Comic;
using HotChocolate.Types;

namespace ComicEngine.Graphql.Types {
    public class ComicInputType : InputObjectType<Comic> {
        protected override void Configure (IInputObjectTypeDescriptor<Comic> descriptor) {
            descriptor.Field (t => t.StorageId).Type<IntType> ().Ignore ();
            descriptor.Field (t => t.Id).Type<IntType> ();
            // descriptor.Field (t => t.Title).Type<NonNullType<StringType>> ();
            // descriptor.Field (t => t.Copyright).Type<StringType> ();
            // descriptor.Field (t => t.IssueNumber).Type<NonNullType<FloatType>> ();
            // descriptor.Field (t => t.Upc).Type<StringType> ();
            // descriptor.Field (t => t.Description).Type<StringType> ();
            // descriptor.Field (t => t.PageCount).Type<IntType> ();
            // descriptor.Field (t => t.ResourceUri).Type<StringType> ();
            // descriptor.Field (t => t.Thumbnail).Type<StringType> ();

            // descriptor.Field (t => t.Characters).Type<CharacterProfileInputType> ();

            // descriptor.Field (t => t.Creators).Type<CreatorProfileInputType> ();

            // descriptor.Field (t => t.Series).Type<SeriesInputType> ();

            // descriptor.Field (t => t.PublishDates).Type<ListType<PublishDateInputType>> ();

            // descriptor.Field (t => t.RelevantLinks).Type<ListType<RelevantLinksInputType>> ();
        }
    }
}