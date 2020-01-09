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
    public class UserMatchDetailsContext
    {

        private IConfiguration _configuration;
        //Array com uma cópia dos dados da coleção de usermatchdetails
        private readonly IMongoCollection<UserMatchDetails> _userMatchDetails;


        public UserMatchDetailsContext(IConfiguration config)
        {
            _configuration = config;

            MongoClient client = new MongoClient(
                _configuration.GetSection("MongoDB:ConexaoString").Value);
            IMongoDatabase db = client.GetDatabase("API_Teste");

            _userMatchDetails = db.GetCollection<UserMatchDetails>("app.usermatchdetails");
        }

        //Listar todas as usermatchdetails
        public List<UserMatchDetails> Get()
        {
            return _userMatchDetails.Find(new BsonDocument()).ToList();
        }
        //Listar um usermatchdetails pelo id
        public UserMatchDetails Get(string id)
        {
            return _userMatchDetails.Find<UserMatchDetails>(usermatchdetails => usermatchdetails.id == id).FirstOrDefault();
        }
        //Salvar um usermatchdetails (save ou create)
        public UserMatchDetails Create(UserMatchDetails usermatchdetails)
        {
            _userMatchDetails.InsertOne(usermatchdetails);
            return usermatchdetails;
        }
        //Atualizar um usermatchdetails (PUT ou POST copy)
        public void Update(string id, UserMatchDetails usermatchdetails1)
        {
            _userMatchDetails.ReplaceOne(usermatchdetails => usermatchdetails.id == id, usermatchdetails1);
        }
        //Deletar um usermatchdetails pelo objeto (Delete)
        public void Remove(UserMatchDetails usermatchdetails1)
        {
            _userMatchDetails.DeleteOne(usermatchdetails => usermatchdetails.id == usermatchdetails1.id);
        }
        //Deletar um usermatchdetails pelo id (Delete)
        public void Remove(string id)
        {
            _userMatchDetails.DeleteOne(usermatchdetails => usermatchdetails.id == id);
        }

    }
}
