using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetProgrammingLanguageTechnologies;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Mappings;
public class ProgrammingLanguageTechnologyMappings : Profile
{
    public ProgrammingLanguageTechnologyMappings()
    {
        CreateMap<CreateProgrammingLanguageTechnologyCommandRequest, ProgrammingLanguageTechnology>()
            .ForMember(x => x.Name, mopt => mopt.MapFrom(v => v.TechnologyName));

        CreateMap<ProgrammingLanguageTechnology, CreateProgrammingLanguageTechnologyCommandResponse>();

        CreateMap<UpdateProgrammingLanguageTechnologyCommandRequest, ProgrammingLanguageTechnology>();

        CreateMap<IPaginate<ProgrammingLanguageTechnology>, GetProgrammingLanguageTechnologiesQueryResponse>();

        CreateMap<ProgrammingLanguageTechnology, ProgrammingLanguageTechnologyDto>()
            .ForMember(x => x.ProgrammingLanguageName, mopt => mopt.MapFrom(v => v.ProgrammingLanguage.Name))
            .ForMember(x => x.TechnologyName, mopt => mopt.MapFrom(v => v.Name));
    }
}
