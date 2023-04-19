using AutoMapper;
using DOTN_Business.Repository.IRepository;
using DOTN_DataAccess;
using DOTN_DataAccess.Data;
using DOTN_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DOTN_Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        //dependency injection
        public ProductRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(ProductDTO objDto)
        {
            //pretvaramo DTO u Product
            var obj= _mapper.Map<ProductDTO, Product>(objDto);
            //dodamo u context
            await _dbContext.AddAsync(obj);
            //spremimo promjene u bazu
            await _dbContext.SaveChangesAsync();

            //vraćamo DTO pa opet moramo napraviti konverziju
            return _mapper.Map<Product, ProductDTO>(obj);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(obj != null)
            {
                _dbContext.Products.Remove(obj);
                //vraća koliko se stvarili spremilo - u ovom slučaju će vratiti 1
                return  await _dbContext.SaveChangesAsync();
            }

            //nismo ništa pobrisali
            return 0;
        }

        public async Task<ProductDTO> Get(int id)
        {
            var obj = await _dbContext.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Product, ProductDTO>(obj);
            }
            return new ProductDTO();
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_dbContext.Products.Include(x => x.Category));
        }

        public async Task<ProductDTO> Update(ProductDTO objDto)
        {
            var objFromDb = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == objDto.Id);
            if(objFromDb !=null)
            {
                objFromDb.Name = objDto.Name;
                objFromDb.Description = objDto.Description;
                objFromDb.ImageUrl = objDto.ImageUrl;
                objFromDb.CategoryId = objDto.CategoryId;
                objFromDb.Color = objDto.Color;
                objFromDb.ShopFavorites = objDto.ShopFavorites;
                objFromDb.CustomerFavorites = objDto.CustomerFavorites;
                objFromDb.Price = objDto.Price;
                _dbContext.Products.Update(objFromDb);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<Product, ProductDTO>(objFromDb);
            }

            return objDto;
        }
    }
}
