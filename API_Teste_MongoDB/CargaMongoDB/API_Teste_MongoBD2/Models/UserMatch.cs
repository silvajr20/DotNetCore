using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace API_Teste_MongoBD2.Models
{
    public class UserMatch
    {

        [BsonId]
        [DataMember]
        public ObjectId _id { get; set; }
        [DataMember]
        public string id { get; set; }
        public string userid { get; set; }
        public string stageid { get; set; }
        public string abilityid { get; set; }
        public string minigameid { get; set; }
        public string hitscount { get; set; }
        public string errorscount { get; set; }
        public string hitsreactiontime { get; set; }
        public string errorsreactiontime { get; set; }
        public string score { get; set; }
        public string starscount { get; set; }
        public string macaddress { get; set; }
        public string appversion { get; set; }
        public string startdatetime { get; set; }
        public string finishdatetime { get; set; }
        public string creationdatetime { get; set; }
        public string modificationdatetime { get; set; }

        


    }
}
