using AutoMapper;
using DOTN_Business.Repository.IRepository;
using DOTN_DataAccess;
using DOTN_DataAccess.Data;
using DOTN_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTN_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        //dependency injection
        public CategoryRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CategoryDTO objDto)
        {
            //pretvaramo DTO u Category
            var obj= _mapper.Map<CategoryDTO, Category>(objDto);
            //vrijeme nije u DTO
            obj.CreatedDate = DateTime.Now;
            //dodamo u context
            await _dbContext.AddAsync(obj);
            //spremimo promjene u bazu
            await _dbContext.SaveChangesAsync();

            //vraćamo DTO pa opet moramo napraviti konverziju
            return _mapper.Map<Category, CategoryDTO>(obj);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(obj != null)
            {
                _dbContext.Categories.Remove(obj);
                //vraća koliko se stvarili spremilo - u ovom slučaju će vratiti 1
                return  await _dbContext.SaveChangesAsync();
            }

            //nismo ništa pobrisali
            return 0;
        }

        public async Task<CategoryDTO> Get(int id)
        {
            var obj = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_dbContext.Categories);
        }

        public async Task<CategoryDTO> Update(CategoryDTO objDto)
        {
            var objFromDb = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == objDto.Id);
            if(objFromDb !=null)
            {
                objFromDb.Name = objDto.Name;
                _dbContext.Categories.Update(objFromDb);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }

            return objDto;
        }
    }
}
