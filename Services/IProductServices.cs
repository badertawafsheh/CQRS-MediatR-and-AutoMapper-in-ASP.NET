using CQRS_With_MeditR_Demo.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS_With_MeditR_Demo.Services
{
    public interface IProductServices
    {
        Task<List<GetProductDTO>> GetAllProducts();
        Task<GetProductDTO> GetProductById(int id);
        Task<GetProductDTO> CreateProduct(AddProductDTO productDTO);
    }
}
