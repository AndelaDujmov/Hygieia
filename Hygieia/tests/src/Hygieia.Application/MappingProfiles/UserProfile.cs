using AutoMapper;
using Hygieia.Application.Models.User;
using Hygieia.DataAccess.Identity;

namespace Hygieia.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserModel, ApplicationUser>();
    }
}
