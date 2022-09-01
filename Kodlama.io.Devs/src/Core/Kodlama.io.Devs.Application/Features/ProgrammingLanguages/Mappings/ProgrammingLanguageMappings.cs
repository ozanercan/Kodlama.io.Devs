using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageById;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguages;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Mappings;
public class ProgrammingLanguageMappings : Profile
{
    public ProgrammingLanguageMappings()
    {
        CreateMap<CreateProgrammingLanguageCommandRequest, ProgrammingLanguage>()
            .ForMember(_entity => _entity.CreatedDate, mopt => mopt.MapFrom(_request => DateTime.UtcNow));

        CreateMap<UpdateProgrammingLanguageCommandRequest, ProgrammingLanguage>();

        CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommandResponse>();
        CreateMap<ProgrammingLanguage, GetProgrammingLanguagesQueryResponse>();
        CreateMap<ProgrammingLanguage, GetProgrammingLanguageByIdQueryResponse>();

    }
}
