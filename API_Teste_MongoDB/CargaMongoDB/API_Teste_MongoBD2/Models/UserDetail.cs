using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace API_Teste_MongoBD2.Models
{
    public class UserDetail
    {

        [BsonId]
        [DataMember]
        public ObjectId _id { get; set; }
        [DataMember]
        public string id { get; set; }
        public string userid { get; set; }
        public string charactertypeid { get; set; }
        public string iscustomavatar { get; set; }
        public string avatarvalue { get; set; }
        public string macaddress { get; set; }
        public string appversion { get; set; }
        public string creationdatetime { get; set; }
        public string modificationdatetime { get; set; }



    }
}
