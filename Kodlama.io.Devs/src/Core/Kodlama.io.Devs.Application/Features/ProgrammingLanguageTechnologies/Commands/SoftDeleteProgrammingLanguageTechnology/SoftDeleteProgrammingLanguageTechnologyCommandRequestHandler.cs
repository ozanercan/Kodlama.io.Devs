using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.BusinessRules;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguageTechnologies;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.SoftDeleteProgrammingLanguageTechnology;

public class SoftDeleteProgrammingLanguageTechnologyCommandRequestHandler : IRequestHandler<SoftDeleteProgrammingLanguageTechnologyCommandRequest, IResponse>
{
    private readonly IProgrammingLanguageTechnologyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguageTechnologyBusinessRules _businessRules;
    public SoftDeleteProgrammingLanguageTechnologyCommandRequestHandler(IProgrammingLanguageTechnologyRepository repository, IMapper mapper, ProgrammingLanguageTechnologyBusinessRules businessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<IResponse> Handle(SoftDeleteProgrammingLanguageTechnologyCommandRequest request, CancellationToken cancellationToken)
    {
        var programmingLanguageTechnology = await _repository.GetAsync(_programmingLanguageTechnology => _programmingLanguageTechnology.Id.Equals(request.Id));

        _businessRules.IsNotNull(programmingLanguageTechnology, Messages.ProgrammingLanguageTechnologyIsNotFound);

        programmingLanguageTechnology.IsDeleted = true;

        _repository.Update(programmingLanguageTechnology);

        if (await _repository.SaveChangesAsync() is false)
            throw new Exception(Messages.ProgrammingLanguageTechnologyIsNotDeleted);

        return new SuccessResponse(Messages.ProgrammingLanguageTechnologyIsDeleted, HttpStatusCode.OK);
    }
}
