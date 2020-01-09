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
    public class UserDetailContext
    {

        private IConfiguration _configuration;
        //Array com uma cópia dos dados da coleção de userdetail
        private readonly IMongoCollection<UserDetail> _userDetail;


        public UserDetailContext(IConfiguration config)
        {
            _configuration = config;

            MongoClient client = new MongoClient(
                _configuration.GetSection("MongoDB:ConexaoString").Value);
            IMongoDatabase db = client.GetDatabase("API_Teste");

            _userDetail = db.GetCollection<UserDetail>("ilhas.userdetail");
        }

        //Listar todas as userdetails
        public List<UserDetail> Get()
        {
            return _userDetail.Find(new BsonDocument()).ToList();
        }
        //Listar um userdetails pelo id
        public UserDetail Get(string id)
        {
            return _userDetail.Find<UserDetail>(userdetail => userdetail.id == id).FirstOrDefault();
        }
        //Salvar um userdetails (save ou create)
        public UserDetail Create(UserDetail userdetail)
        {
            _userDetail.InsertOne(userdetail);
            return userdetail;
        }
        //Atualizar um userdetails (PUT ou POST copy)
        public void Update(string id, UserDetail userdetail1)
        {
            _userDetail.ReplaceOne(userdetail => userdetail.id == id, userdetail1);
        }
        //Deletar um userdetails pelo objeto (Delete)
        public void Remove(UserDetail userDetail1)
        {
            _userDetail.DeleteOne(userdetail => userdetail.id == userDetail1.id);
        }
        //Deletar um userdetails pelo id (Delete)
        public void Remove(string id)
        {
            _userDetail.DeleteOne(userdetail => userdetail.id == id);
        }



    }
}
