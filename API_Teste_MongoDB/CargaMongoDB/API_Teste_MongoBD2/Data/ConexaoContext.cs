using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Teste_MongoDB.Data
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
            IMongoDatabase db = client.GetDatabase("API_Teste");

            var filter = Builders<T>.Filter.Eq("codigo", codigo);

            return db.GetCollection<T>("users")
                .Find(filter).FirstOrDefault();
        }


    }
}
