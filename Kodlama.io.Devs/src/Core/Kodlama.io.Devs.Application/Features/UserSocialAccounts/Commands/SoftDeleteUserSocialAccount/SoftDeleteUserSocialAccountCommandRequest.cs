namespace Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.SoftDeleteUserSocialAccount;

public class SoftDeleteUserSocialAccountCommandRequest : IRequest<IResponse>
{
    public int Id { get; set; }
}
