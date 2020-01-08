using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace API_Teste_MongoDB.Models
{
    public class Grade
    {

        [BsonId]
        [DataMember]
        public ObjectId _id { get; set; }
        
        [DataMember]
        public string id { get; set; }
        public string name { get; set; }
        public string deleted { get; set; }
        public string createdate { get; set; }
        public string createuserid { get; set; }
        public string deletedate { get; set; }
        public string deleteuserid { get; set; }
        public string updatedate { get; set; }
        public string updateuserid { get; set; }

        public Grade()
        {

        }

    }
}
