using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Repositories.RefreshTokens;
using Microsoft.AspNetCore.Http;

namespace Kodlama.io.Devs.Application.Features.RefreshTokens.Commands.CreateRefreshTokenToUser;

public class CreateRefreshTokenToUserCommandRequestHandler : IRequestHandler<CreateRefreshTokenToUserCommandRequest, Core.Security.JWT.RefreshToken>
{
    private readonly IRefreshTokenRepository _repository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITokenHelper _tokenHelper;
    public CreateRefreshTokenToUserCommandRequestHandler(IRefreshTokenRepository writeRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, ITokenHelper tokenHelper)
    {
        _repository = writeRepository;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
        _tokenHelper = tokenHelper;
    }

    public async Task<Core.Security.JWT.RefreshToken> Handle(CreateRefreshTokenToUserCommandRequest request, CancellationToken cancellationToken)
    {
        var clientIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

        var refreshToken = _tokenHelper.CreateRefreshToken(request.User, clientIpAddress);

        await _repository.CreateAsync(refreshToken);

        if (request.IsSaveChanges && await _repository.SaveChangesAsync() is false)
            throw new BusinessException(Messages.RefreshTokenIsNotCreated);

        return _mapper.Map<Core.Security.Entities.RefreshToken, Core.Security.JWT.RefreshToken>(refreshToken);
    }
}
