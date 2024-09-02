using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<int> Adicionar(T entity);
        Task<int> Alterar(T entity);
        Task<int> Apagar(int Id);
        Task<T> LeituraPorId(int Id);
        Task<List<T>> ListaTodos();
    }
}
