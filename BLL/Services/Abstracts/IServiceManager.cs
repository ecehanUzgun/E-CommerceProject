using MODEL.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstracts
{
    public interface IServiceManager<T> where T:BaseEntity
    {
        //List Commands

        IEnumerable<T> GetAll();

        IEnumerable<T> GetActives();

        IEnumerable<T> GetPassives();

        T GetById(int id);


        //Modified Commands

        Task CreateAsync(T entity);

        Task CreateRangeAsync(List<T> entities);

        Task UpdateAsync(T entity);

        Task UpdateRangeAsync(List<T> entities);

        Task DeleteAsync(T entity);

        Task DeleteAllAsync(List<T> entities);

        Task DestroyAsync(T entity);

        Task DestroyRangeAsync(List<T> entities);

    }
}
