using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using eOkulServer.Infrastructure.Context;

namespace eOkulServer.Infrastructure.Repositories;
internal sealed class UserTypeRepository : Repository<UserType>, IUserTypeRepository
{
    public UserTypeRepository(ApplicationDbContext context) : base(context)
    {
    }
}
