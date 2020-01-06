using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargaBancoMongoDB;
using Microsoft.IdentityModel.Protocols;
using MongoDB.Driver;

namespace CargaBancoMongoDB1
{
    class Program
    {
        static void Main(string[] args)
        {

            MongoClient client = new MongoClient(
               ConfigurationManager.AppSettings["ConexaoContext"]);

            IMongoDatabase db = client.GetDatabase("CatsprodDB");

            Console.WriteLine("Incuindo produtos");
            var categoriaProd = db.GetCollection<Produto>("Conexao");

            Produto prod1 = new Produto();
            prod1.Codigo = "PROD1";
            prod1.Nome = "Detergente";
            prod1.Tipo = "Limpeza";
            prod1.Preco = 5.75;
            categoriaProd.InsertOne(prod1);


            Produto prod2 = new Produto();
            prod2.Codigo = "PROD2";
            prod2.Nome = "Detergente";
            prod2.Tipo = "Limpeza";
            prod2.Preco = 5.00;
            categoriaProd.InsertOne(prod2);

            Console.WriteLine("Finalizado");
            Console.ReadKey();


        }
    }
}
