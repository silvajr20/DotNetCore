using API_Teste_MongoBD2.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Teste_MongoBD2.Data
{
    public class UserLogContext
    {

        private IConfiguration _configuration;
        //Array com uma cópia dos dados da coleção de userlog
        private readonly IMongoCollection<UserLog> _userlog;
        
        
        public UserLogContext(IConfiguration config)
        {
            _configuration = config;

            MongoClient client = new MongoClient(
                _configuration.GetSection("MongoDB:ConexaoString").Value);
            IMongoDatabase db = client.GetDatabase("API_Teste");

            _userlog = db.GetCollection<UserLog>("app.userlog");
        }

        //Listar todas as userlogs
        public List<UserLog> Get()
        {
            return _userlog.Find(new BsonDocument()).ToList();
        }
        //Listar um userlog pelo id
        public UserLog Get(string id)
        {
            return _userlog.Find<UserLog>(userlog => userlog.id == id).FirstOrDefault();
        }
        //Salvar um userlog (save ou create)
        public UserLog Create(UserLog userlog)
        {
            _userlog.InsertOne(userlog);
            return userlog;
        }
        //Atualizar um userlog (PUT ou POST copy)
        public void Update(string id, UserLog userlog1)
        {
            _userlog.ReplaceOne(userlog => userlog.id == id, userlog1);
        }
        //Deletar um userlog pelo objeto (Delete)
        public void Remove(UserLog userlog1)
        {
            _userlog.DeleteOne(userlog => userlog.id == userlog1.id);
        }
        //Deletar um userlog pelo id (Delete)
        public void Remove(string id)
        {
            _userlog.DeleteOne(userlog => userlog.id == id);
        }




    }
}
