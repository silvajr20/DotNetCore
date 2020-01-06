using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace CargaBancoMongoDB
{
        
    public class Produto
    {
        public ObjectId id { get; set; }
        public String Codigo { get; set; }
        public String Nome { get; set; }
        public String Tipo { get; set; }
        public double Preco { get; set; }

                

    }
}
