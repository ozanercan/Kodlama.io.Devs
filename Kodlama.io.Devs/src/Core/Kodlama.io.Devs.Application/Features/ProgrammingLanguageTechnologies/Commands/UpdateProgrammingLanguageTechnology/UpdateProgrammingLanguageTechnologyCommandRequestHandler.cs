using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.BusinessRules;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguageTechnologies;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;

public class UpdateProgrammingLanguageTechnologyCommandRequestHandler : IRequestHandler<UpdateProgrammingLanguageTechnologyCommandRequest, IResponse>
{
    private readonly IProgrammingLanguageTechnologyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguageTechnologyBusinessRules _businessRules;
    public UpdateProgrammingLanguageTechnologyCommandRequestHandler(IProgrammingLanguageTechnologyRepository repository, IMapper mapper, ProgrammingLanguageTechnologyBusinessRules businessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<IResponse> Handle(UpdateProgrammingLanguageTechnologyCommandRequest request, CancellationToken cancellationToken)
    {
        var programmingLanguageTechnology = await _repository.GetAsync(_programmingLanguage => _programmingLanguage.Id.Equals(request.Id));

        _businessRules.IsNotNull(programmingLanguageTechnology, Messages.ProgrammingLanguageTechnologyIsNotFound);

        _mapper.Map<UpdateProgrammingLanguageTechnologyCommandRequest, ProgrammingLanguageTechnology>(request, programmingLanguageTechnology);

        _repository.Update(programmingLanguageTechnology);

        if (await _repository.SaveChangesAsync() is false)
            throw new BusinessException(Messages.ProgrammingLanguageTechnologyIsNotUpdated);

        return new SuccessResponse(Messages.ProgrammingLanguageTechnologyIsUpdated, HttpStatusCode.OK);
    }
}
