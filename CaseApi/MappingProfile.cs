using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cases, CasesDTO>();
            CreateMap<CasesForCreationDTO, Cases>();
            CreateMap<StandDTO, Stand>();
            CreateMap<Stand, StandDTO>();
            CreateMap<CaseHistory, CaseHistoryDTO>();
            CreateMap<Cases, CaseHistoryDTO>();
        }
    }
}
