namespace Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.UpdateUserSocialAccount;

public class UpdateUserSocialAccountCommandRequest : IRequest<IResponse>
{
    public int Id { get; set; }
    public string Path { get; set; }
}
