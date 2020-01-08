using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace API_Teste_MongoBD2.Models
{
    public class UserLog
    {
        [BsonId]
        [DataMember]
        public ObjectId _id { get; set; }
        [DataMember]
        public string id { get; set; }
        public string userid { get; set; }
        public string userlogtypeid { get; set; }
        public string startdatetime { get; set; }
        public string finishdatetime { get; set; }
        public string macaddress { get; set; }
        public string appversion { get; set; }
        public string createdatetime { get; set; }
        public string modificationdatetime { get; set; }
        


    }
}
