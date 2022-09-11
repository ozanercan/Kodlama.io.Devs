using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.BusinessRules;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommandRequestHandler : IRequestHandler<UpdateProgrammingLanguageCommandRequest, IResponse>
{
    private readonly IProgrammingLanguageRepository _repository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;

    public UpdateProgrammingLanguageCommandRequestHandler(IProgrammingLanguageRepository repository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
    }

    public async Task<IResponse> Handle(UpdateProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(_programmingLanguage => _programmingLanguage.Id.Equals(request.Id));

        _programmingLanguagesBusinessRules.IsShouldBeNotNull(entity);

        await _programmingLanguagesBusinessRules.DatabaseShouldNotHaveProgrammingLanguageNameAsync(request.Name, request.Id);

        _mapper.Map<UpdateProgrammingLanguageCommandRequest, ProgrammingLanguage>(request, entity);

        _repository.Update(entity);

        if (await _repository.SaveChangesAsync() is false)
            throw new BusinessException(Messages.ProgrammingLanguageIsNotUpdated);

        return new SuccessResponse(Messages.ProgrammingLanguageIsUpdated, HttpStatusCode.OK);
    }
}
