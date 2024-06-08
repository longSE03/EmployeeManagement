using AutoMapper;
using EmployeeManagement.DataAccess.DTOs;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Helper.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserRespondDTO>().ReverseMap();
            CreateMap<User, UserRegisterRequestDTO>().ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));
            CreateMap<User, UserUpdateRequestDTO>().ReverseMap();
            CreateMap<Submission, SubmissionDTO>().ReverseMap();
        }
    }
}
