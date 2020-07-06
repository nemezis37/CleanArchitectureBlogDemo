using FluentValidation;

namespace CleanArchitecture.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandValidator: AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(x => x.Body)
                .MaximumLength(4000)
                .NotEmpty();

            RuleFor(x => x.Author)
                .NotEmpty();
        }
    }
}
