using System;
using ComicEngine.Shared;
using HotChocolate.Types;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql.Types {
    public class MutationType : ObjectType<Mutation> {

        private static readonly ILogger Logger = ApplicationLogging.CreateLogger (nameof (MutationType));

        protected override void Configure (IObjectTypeDescriptor<Mutation> descriptor) {
            descriptor
                .Field (t => t.CreateUserComic (default))
                .Type<UserComicType> ()
                .Argument ("comic", a => 
                    a.Type<NonNullType<ComicInputType>> ())
                .Argument("userId", a => 
                    a.Type<NonNullType<StringType>>())
                // Move this out to reusable middleware for error reporting
                .Use (next => async context => {
                    // try and move on through context
                    Logger.LogDebug ("Processing mutation: {mutationVariables}", context.Variables);
                    try {
                        // Log here
                        await next (context);
                    } catch (Exception ex) {
                        Logger.LogError (ex, "An error occured while executing {mutationName}", context.Field.Name);
                        context.ReportError (ex.Message);
                        throw;
                    }
                });

            descriptor
                .Field(t => t.DeleteUserComic(default))
                .Type<BooleanType>()
                .Argument("userComicId", arg => arg.Type<NonNullType<StringType>>())
                .Argument("userId", a => a.Type<NonNullType<StringType>>())
                // Move this out to reusable middleware for error reporting
                .Use (next => async context => {
                    // try and move on through context
                    Logger.LogDebug ("Processing mutation: {mutationVariables}", context.Variables);
                    try {
                        // Log here
                        await next (context);
                    } catch (Exception ex) {
                        Logger.LogError (ex, "An error occured while executing {mutationName}", context.Field.Name);
                        context.ReportError (ex.Message);
                        throw;
                    }
                })
                ;

            descriptor
                .Field(t => t.CreateStorageContainer(default))
                .Type<StorageContainerType>()
                .Argument("storageContainer", arg => 
                    arg.Type<NonNullType<StorageContainerInputType>>())
                .Use(next => async context =>
                {
                    // try and move on through context
                    Logger.LogDebug ("Processing mutation: {mutationVariables}", context.Variables);
                    try {
                        // Log here
                        await next (context);
                    } catch (Exception ex) {
                        Logger.LogError (ex, "An error occured while executing {mutationName}", context.Field.Name);
                        context.ReportError (ex.Message);
                        throw;
                    }
                })
                ;
        }
    }
}