using System.Diagnostics.CodeAnalysis;
using KontackPortal.Repository.Helpers;
using KontackPortal.Repository.Interfaces;
using KontackPortal.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KontackPortal.Repository
{
    [ExcludeFromCodeCoverage]
    public static class Initialiser
    {
      

        public static void AddRepository(this IServiceCollection repository, string connectionString)
        {
            repository.AddEntityFrameworkNpgsql().AddDbContext<ContactContext>(opt =>
            opt.UseNpgsql(connectionString));
        }

        public static void AddRepositories(this IServiceCollection repositories)
        {
            repositories.AddTransient<IContactRepository, ContactRepository>();
        }
    }
}