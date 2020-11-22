using Automatonymous;
using ComicEngine.Api.UserComics.CreateUserComic.Activities;
using ComicEngine.Api.UserComics.CreateUserComic.States;
using ComicEngine.Common.Comics;

namespace ComicEngine.Api.UserComics.CreateUserComic
{
    public class CreateUserComicStateMachine : AutomatonymousStateMachine<CreateUserComicState>
    {
        public CreateUserComicStateMachine()
        {
            During(Initial,
                When(CreateUserComic)
                    .TransitionTo(ValidatingComic));
            
            During(ValidatingComic, 
                When(ValidateComic)
                    .Execute(context => new ValidateComicActivity())
                    .TransitionTo(ConvertingUserComic)
            );
            
            During(ConvertingUserComic, 
                When(ConvertToUserComic)
                    .Execute(context => new ConvertToUserComicActivity())
                    .TransitionTo(CreatingUserComic)
            );

            During(CreatingUserComic, 
            When(CreateAndAddUserComic)
                .ExecuteAsync(async context => new PersistUserComicActivity())
                .TransitionTo(Completed)
            );
        }

        // Events
        public Event CreateUserComic { get; set; }
        public Event<Comic> ValidateComic { get; set; }
        public Event<Comic> ConvertToUserComic { get; set; }
        public Event<IUserComicsRepository> CreateAndAddUserComic { get; set; }
        
        /// States
        public State CreatingUserComic { get; set; }
        // Validate user comic
        public State ValidatingComic { get; set; }
        // convert user comic state.
        public State ConvertingUserComic { get; set; }
        public State Completed { get; set; }
    }
}