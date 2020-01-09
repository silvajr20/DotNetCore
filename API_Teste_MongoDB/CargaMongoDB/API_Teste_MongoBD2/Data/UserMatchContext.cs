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
    public class UserMatchContext
    {        
        private IConfiguration _configuration;
        //Array com uma cópia dos dados da coleção de usermatch
        private readonly IMongoCollection<UserMatch> _userMatch;


        public UserMatchContext(IConfiguration config)
        {
            _configuration = config;

            MongoClient client = new MongoClient(
                _configuration.GetSection("MongoDB:ConexaoString").Value);
            IMongoDatabase db = client.GetDatabase("API_Teste");

            _userMatch = db.GetCollection<UserMatch>("ilhas.usermatch");
        }

        //Listar todas as userlogs
        public List<UserMatch> Get()
        {
            return _userMatch.Find(new BsonDocument()).ToList();
        }
        //Listar um userlog pelo id
        public UserMatch Get(string id)
        {
            return _userMatch.Find<UserMatch>(usermatch => usermatch.id == id).FirstOrDefault();
        }
        //Salvar um userlog (save ou create)
        public UserMatch Create(UserMatch usermatch)
        {
            _userMatch.InsertOne(usermatch);
            return usermatch;
        }
        //Atualizar um userlog (PUT ou POST copy)
        public void Update(string id, UserMatch usermatch1)
        {
            _userMatch.ReplaceOne(usermatch => usermatch.id == id, usermatch1);
        }
        //Deletar um userlog pelo objeto (Delete)
        public void Remove(UserMatch usermatch1)
        {
            _userMatch.DeleteOne(usermatch => usermatch.id == usermatch1.id);
        }
        //Deletar um userlog pelo id (Delete)
        public void Remove(string id)
        {
            _userMatch.DeleteOne(usermatch => usermatch.id == id);
        }


    }
}
