using KovanCaseStudy.Domain.Aggregates.UserAggregate;

namespace KovanCaseStudy.Infrastructure.EfCore.Repositories;

public class UserRepository: EFRepository<User>, IUserRepository
{
    public UserRepository(KovanDbContext context) : base(context)
    { }
}