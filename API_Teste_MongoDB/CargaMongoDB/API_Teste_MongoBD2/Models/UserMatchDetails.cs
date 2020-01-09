using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace API_Teste_MongoBD2.Models
{
    public class UserMatchDetails
    {

        [BsonId]
        [DataMember]
        public ObjectId _id { get; set; }
        [DataMember]
        public string id { get; set; }
        public string usermatchid { get; set; }
        public string usermatchdetailstypes { get; set; }
        public string usermatchdetailscontenttypes { get; set; }
        public string dataid { get; set; }
        public string genericvalue { get; set; }
        public string creationdatetime { get; set; }
        public string modificationdatetime { get; set; }



    }
}
