using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace CargaMongoDB
{
    class web_grade
    {
        public ObjectId _id { get; set; }
        public int id { get; set; }
        public String name { get; set; }
        public String deleted { get; set; }
        public String createdate{ get; set; }
        public String createuserid { get; set; }
        public String deletedate { get; set; }
        public string deleteuserid { get; set; }
        public string updatedate { get; set; }
        public String updateuserid { get; set; }



    }
}
