using System.Threading.Tasks;
using WebApi.Repositories;

namespace WebApi.Services
{
    public interface ISeed
    {
         public Task Initialize(TVShowDbContext context);
    }
}