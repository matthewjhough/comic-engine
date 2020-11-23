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
                .Execute(context => new PersistUserComicActivity())
                .TransitionTo(Completed)
            );
        }

        // Events
        public Event CreateUserComic { get; set; }
        public Event<Comic> ValidateComic { get; set; }
        public Event<Comic> ConvertToUserComic { get; set; }
        public Event<IUserComicsRepository> CreateAndAddUserComic { get; set; }
        
        /// States
        public Automatonymous.State CreatingUserComic { get; set; }
        // Validate user comic
        public Automatonymous.State ValidatingComic { get; set; }
        // convert user comic state.
        public Automatonymous.State ConvertingUserComic { get; set; }
        public Automatonymous.State Completed { get; set; }
    }
}