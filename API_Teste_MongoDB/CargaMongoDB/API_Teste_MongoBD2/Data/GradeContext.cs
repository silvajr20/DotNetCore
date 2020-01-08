using API_Teste_MongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Teste_MongoDB.Data
{
    public class GradeContext
    {
        private IConfiguration _configuration;
        //Array com uma cópia dos dados da coleção
        private readonly IMongoCollection<Grade> _grades;


        public GradeContext(IConfiguration config)
        {
            _configuration = config;
            
            MongoClient client = new MongoClient(
                _configuration.GetSection("MongoDB:ConexaoString").Value);
            IMongoDatabase db = client.GetDatabase("API_Teste");                        

            _grades = db.GetCollection<Grade>("grade");
        }
                            

        //Listar todas as grades
        public List<Grade> Get()
        {
            return _grades.Find(new BsonDocument()).ToList();
        }
        //Listar uma grade pelo id
        public Grade Get(string id)
        {
            return _grades.Find<Grade>(grade => grade.id == id).FirstOrDefault();
        }
        //Salvar uma grade (save ou create)
        public Grade Create(Grade grade)
        {
            _grades.InsertOne(grade);
            return grade;
        }
        //Atualizar uma grade (PUT ou POST copy)
        public void Update(string id,  Grade grade1)
        {
            _grades.ReplaceOne(grade => grade.id == id, grade1);
        }
        //Deletar uma grade pelo objeto (Delete)
        public void Remove(Grade grade1)
        {
            _grades.DeleteOne(grade => grade.id == grade1.id);
        }
        //Deletar uma grade pelo id (Delete)
        public void Remove(string id)
        {
            _grades.DeleteOne(grade => grade.id == id);
        }


        /*
       //Listar uma grade pelo id
       public T ObterItem<T>(string id)
       {
           MongoClient client = new MongoClient(
               _configuration.GetSection("MongoDB:ConexaoString").Value);
           IMongoDatabase db = client.GetDatabase("API_Teste");

           var filter = Builders<T>.Filter.Eq("id", id);

           return db.GetCollection<T>("grade")
               .Find(filter).FirstOrDefault();
       }
       */


    }
}
