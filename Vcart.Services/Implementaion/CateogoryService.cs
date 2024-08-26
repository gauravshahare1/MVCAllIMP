using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vcart.Data.entities;
using Vcart.Services.Interface;
using VCartRepositories.Interfaces;

namespace Vcart.Services.Implementaion
{
    public class CateogoryService : ICateogoryService
    {
        ICategoryRepository _categoryRepository;

        public CateogoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Create(Category category)
        {
            _categoryRepository.Create(category);
        }

        public void Delete(Category category)
        {
           _categoryRepository.Delete(category);
        }

        public Category FindById(int id)
        {
          return  _categoryRepository.FindById(id);
        }

        public List<Category> GetAll()
        {
           return _categoryRepository.GetAll();
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
