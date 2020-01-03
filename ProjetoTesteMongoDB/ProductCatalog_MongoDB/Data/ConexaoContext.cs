using System.Linq;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace ProductCatalog.Data
{
    public class ConexaoContext 
    
    {
        private IConfiguration _configuration;

        public ConexaoContext(IConfiguration config)
        {
            _configuration = config;
        }

        public T ObterItem<T>(string codigo)
        {
            MongoClient client = new MongoClient(
                _configuration.GetSection("MongoDB:ConexaoString").Value);
            IMongoDatabase db = client.GetDatabase("CatsprodDB");

            var filter = Builders<T>.Filter.Eq("Codigo", codigo);

            return db.GetCollection<T>("Conexao")
                .Find(filter).FirstOrDefault();
        }
    }
}