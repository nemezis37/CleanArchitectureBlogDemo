using FluentValidation;

namespace CleanArchitecture.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator: AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.Body)
                .MaximumLength(4000)
                .NotEmpty();

            RuleFor(x => x.Header)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
