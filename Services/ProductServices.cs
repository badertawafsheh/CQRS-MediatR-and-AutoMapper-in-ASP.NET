using AutoMapper;
using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_With_MeditR_Demo.Services
{
    public class ProductServices : IProductServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetProductDTO>> GetAllProducts()
        {
            var products = await _context.Products.Select(p => _mapper.Map<GetProductDTO>(p)).ToListAsync();
            if (products == null) return null;

            return products;
        }

        public async Task<GetProductDTO> GetProductById(int Id)
        {
            var product = _context.Products.Where(a => a.Id == Id).FirstOrDefault();
            if (product == null) return null;

            return _mapper.Map<GetProductDTO>(product);
        }
    }
}
