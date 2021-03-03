using Ardalis.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rel.SharedKernel.Interfaces
{
    public interface IRepository
    {
        //T GetById<T>(int id) where T : BaseEntity;
        Task<T> GetByIdAsync<T>(int id) where T : BaseEntity;
        Task<List<T>> ListAsync<T>() where T : BaseEntity;
        Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : BaseEntity;//, IAggregateRoot;
        //T Add<T>(T entity) where T : BaseEntity;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;
        //void Update<T>(T entity) where T : BaseEntity;
        Task UpdateAsync<T>(T entity) where T : BaseEntity;
        //void Delete<T>(T entity) where T : BaseEntity;
        Task DeleteAsync<T>(T entity) where T : BaseEntity;
    }
}