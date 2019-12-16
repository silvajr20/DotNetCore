using System;
using System.Linq.Expressions;
using Payment.Context.Domain.Entities;

namespace Payment.Context.Domain.Queries{
    public static class StudentQueries{

        public static Expression<Func<Student, bool>> GetStudentInfo (string document){
            return x => x.Document.Number == document;
        } 

    }    
}
