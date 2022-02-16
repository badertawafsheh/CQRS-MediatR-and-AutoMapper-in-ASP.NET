using CQRS_With_MeditR_Demo.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS_With_MeditR_Demo.Services
{
    public interface IProductServices
    {
        Task<GetProductDTO> GetProductById (int id);
    }
}
