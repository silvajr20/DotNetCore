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
    public class UserProgressContext
    {
        
        private IConfiguration _configuration;
        //Array com uma cópia dos dados da coleção de userlog
        private readonly IMongoCollection<UserProgress> _userProgress;


        public UserProgressContext(IConfiguration config)
        {
            _configuration = config;

            MongoClient client = new MongoClient(
                _configuration.GetSection("MongoDB:ConexaoString").Value);
            IMongoDatabase db = client.GetDatabase("API_Teste");

            _userProgress = db.GetCollection<UserProgress>("app.userprogress");
        }

        //Listar todas as userlogs
        public List<UserProgress> Get()
        {
            return _userProgress.Find(new BsonDocument()).ToList();
        }
        //Listar um userlog pelo id
        public UserProgress Get(string id)
        {
            return _userProgress.Find<UserProgress>(userprogress => userprogress.id == id).FirstOrDefault();
        }
        //Salvar um userlog (save ou create)
        public UserProgress Create(UserProgress userprogress)
        {
            _userProgress.InsertOne(userprogress);
            return userprogress;
        }
        //Atualizar um userlog (PUT ou POST copy)
        public void Update(string id, UserProgress userprogress1)
        {
            _userProgress.ReplaceOne(userprogress => userprogress.id == id, userprogress1);
        }
        //Deletar um userlog pelo objeto (Delete)
        public void Remove(UserProgress userprogress1)
        {
            _userProgress.DeleteOne(userprogress => userprogress.id == userprogress1.id);
        }
        //Deletar um userlog pelo id (Delete)
        public void Remove(string id)
        {
            _userProgress.DeleteOne(userprogress => userprogress.id == id);
        }



    }
}
