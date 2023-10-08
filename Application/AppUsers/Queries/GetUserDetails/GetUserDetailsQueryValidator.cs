using FluentValidation;

namespace Application.AppUsers.Queries.GetUserDetails
{
    public class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}
