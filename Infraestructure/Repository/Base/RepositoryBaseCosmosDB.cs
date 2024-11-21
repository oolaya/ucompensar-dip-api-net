using Domian.Port;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class RepositoryBaseCosmosDB<T> : IRepositoryBaseCosmosDB<T>
        where T : class, new()
    {

        public IMainContextCosmos _mainContextCosmos { get; set; }

        protected IMongoCollection<T> Coleccion;
        public RepositoryBaseCosmosDB(IMainContextCosmos mainContextCosmos) 
        {
            _mainContextCosmos = mainContextCosmos;
            Coleccion = _mainContextCosmos.GetCollection<T>(typeof(T).Name);
        }

        public async Task<List<T>> ToListModel()
        {
            return await Coleccion.Find(_ => true).ToListAsync();
        }

        public async Task<T> CreateModel ( T entity)
        {
            await Coleccion.InsertOneAsync(entity);
            return entity;
        }

    }
}
