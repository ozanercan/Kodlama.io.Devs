using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguageTechnologies;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;

public class CreateProgrammingLanguageTechnologyCommandRequestHandler : IRequestHandler<CreateProgrammingLanguageTechnologyCommandRequest, IDataResponse<CreateProgrammingLanguageTechnologyCommandResponse>>
{
    private readonly IProgrammingLanguageTechnologyRepository _repository;
    private readonly IMapper _mapper;

    public CreateProgrammingLanguageTechnologyCommandRequestHandler(IProgrammingLanguageTechnologyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IDataResponse<CreateProgrammingLanguageTechnologyCommandResponse>> Handle(CreateProgrammingLanguageTechnologyCommandRequest request, CancellationToken cancellationToken)
    {
        ProgrammingLanguageTechnology entityToAdd = _mapper.Map<CreateProgrammingLanguageTechnologyCommandRequest, ProgrammingLanguageTechnology>(request);

        await _repository.CreateAsync(entityToAdd);

        if (await _repository.SaveChangesAsync() is false)
            throw new BusinessException(Messages.ProgrammingLanguageTechnologyIsNotCreated);

        var responseModel = _mapper.Map<ProgrammingLanguageTechnology, CreateProgrammingLanguageTechnologyCommandResponse>(entityToAdd);

        return new SuccessDataResponse<CreateProgrammingLanguageTechnologyCommandResponse>(Messages.ProgrammingLanguageTechnologyIsCreated, HttpStatusCode.Created, responseModel);
    }
}
