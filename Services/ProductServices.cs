using AutoMapper;
using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.DTO;
using CQRS_With_MeditR_Demo.Model;
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
        public async Task<GetProductDTO> CreateProduct(AddProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetProductDTO>(product);
        }

        public async Task<GetProductDTO> UpdateProduct(int id, GetProductDTO productDTO)
        {
            var product = await _context.Products.FirstOrDefaultAsync(a => a.Id == productDTO.Id);
            if (product == null) return null;
            else
            {
                product.Name = productDTO.Name;
                product.Description = productDTO.Description;
                product.Rate = productDTO.Rate;
                product.Barcode = productDTO.Barcode;
                await _context.SaveChangesAsync();
                return _mapper.Map<GetProductDTO>(product);

            }
        }

        public async Task<GetProductDTO> DeleteProduct(int id)
        {
            var product = await _context.Products.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (product == null) return null;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetProductDTO>(product);
        }
    }
}
