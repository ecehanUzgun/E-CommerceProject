using BLL.Services.Abstracts;
using DAL.Repository.Abstracts;
using MODEL.Abstracts;
using MODEL.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concretes
{
    public class ServiceManager<T> : IServiceManager<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public ServiceManager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(T entity)
        {
            try
            {
               await _repository.CreateAsync(entity);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public async Task CreateRangeAsync(List<T> entities)
        {
            try
            {
                await _repository.CreateRangeAsync(entities);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteAllAsync(List<T> entities)
        {
            try
            {
                _repository.DeleteAllAsync(entities);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
               await _repository.DeleteAsync(entity);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public async Task DestroyAsync(T entity)
        {
            try
            {
               await _repository.DestroyAsync(entity);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public async Task DestroyRangeAsync(List<T> entities)
        {
            try
            {
                await _repository.DestroyRangeAsync(entities);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public IEnumerable<T> GetActives()
        {
            return _repository.GetActives().ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<T> GetPassives()
        {
            return _repository.GetPassives().ToList();
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                await _repository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                //todo: Log'a kaydetme işlemi
            }
        }

        public async Task UpdateRangeAsync(List<T> entities)
        {
            try
            {
                await _repository.UpdateRangeAsync(entities);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                //todo: Log'a kaydetme işlemi
            }
        }
    }
}
