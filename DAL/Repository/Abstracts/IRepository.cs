using MODEL.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Abstracts
{
    public interface IRepository<T> where T : BaseEntity
    {

        //Aşağıdaki metotlar bütün entity için kullanılacak metotları temsil etmektedirler.

        //List Commands

        /// <summary>
        /// Bütün verileri Koleksiyon olarak teslim eder.
        /// </summary>
        /// <returns></returns>
       IQueryable<T> GetAll(); //IQueryable sorgulamaları localhost tarafındaki RAM üzerinde gerçekleştirilmesine olanak sağlar.

        /// <summary>
        /// Aktif verileri listeler.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetActives();

        /// <summary>
        /// Pasif verileri listeler.
        /// </summary>
        /// <returns></returns>

        IQueryable<T> GetPassives();

        /// <summary>
        /// Tekil veriyi listeler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);


        //Modified Commands

        /// <summary>
        /// Dışarıdan alınan veriyi veritabanına kaydeder.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
       Task CreateAsync(T entity);


        /// <summary>
        /// Dışarıdan alınan birden fazla veriyi veritabanına kaydeder.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateRangeAsync(List<T> entities);

        /// <summary>
        /// Dışarıdan alınan veriyi günceller.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        Task UpdateAsync(T entity);

        /// <summary>
        /// Dışarıdan alınan birden fazla veriyi günceller.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        Task UpdateRangeAsync(List<T> entities);

        /// <summary>
        /// Dışarıdan alınan veriyi veritabanından kaldırır.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        Task DeleteAsync(T entity);

        /// <summary>
        /// Dışarıdan alınan birden fazla veriyi veritabanından kaldırır.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        Task DeleteAllAsync(List<T> entities);

        /// <summary>
        /// Dışarıdan alınan veriyi veritabanından siler.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        Task DestroyAsync(T entity);

        /// <summary>
        /// Dışarıdan alınan birden fazla veriyi veritabanından siler.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        Task DestroyRangeAsync(List<T> entities);


    }
}
