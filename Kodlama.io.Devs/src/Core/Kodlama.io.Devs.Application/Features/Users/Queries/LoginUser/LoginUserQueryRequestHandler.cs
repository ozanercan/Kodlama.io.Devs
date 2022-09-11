using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.RefreshTokens.Commands.CreateRefreshTokenToUser;
using Kodlama.io.Devs.Application.Features.Users.BusinessRules;
using Kodlama.io.Devs.Application.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Users.Queries.LoginUser;

public class LoginUserQueryRequestHandler : IRequestHandler<LoginUserQueryRequest, IDataResponse<LoginUserQueryResponse>>
{
    private readonly IUserRepository _repository;
    private readonly UserBusinessRules _businessRules;
    private readonly ITokenHelper _tokenHelper;
    private readonly IMediator _mediator;
    public LoginUserQueryRequestHandler(IUserRepository repository, UserBusinessRules businessRules, ITokenHelper tokenHelper, IMediator mediator)
    {
        _repository = repository;
        _businessRules = businessRules;
        _tokenHelper = tokenHelper;
        _mediator = mediator;
    }

    public async Task<IDataResponse<LoginUserQueryResponse>> Handle(LoginUserQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetAsync(
            predicate: _user => _user.Email.Equals(request.Email),
            include: _userQuery => _userQuery.Include(_user => _user.UserOperationClaims).ThenInclude(_userOperationClaim => _userOperationClaim.OperationClaim));

        _businessRules.IsShouldNotNull(user, Messages.EmailOrPasswordAreIncorrect);

        _businessRules.PasswordIsShouldCorrect(request.Password, user.PasswordHash, user.PasswordSalt, Messages.EmailOrPasswordAreIncorrect);

        var accessToken = _tokenHelper.CreateToken(user, user.UserOperationClaims.Select(_userOperationClaim => _userOperationClaim.OperationClaim).ToList());

        var refreshToken = await _mediator.Send(new CreateRefreshTokenToUserCommandRequest() { User = user });

        if (await _repository.SaveChangesAsync() is false)
            throw new BusinessException(Messages.UserLoginFailed);

        var responseModel = new LoginUserQueryResponse()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        return new SuccessDataResponse<LoginUserQueryResponse>(Messages.UserLoginSuccessful, HttpStatusCode.OK, responseModel);
    }
}
