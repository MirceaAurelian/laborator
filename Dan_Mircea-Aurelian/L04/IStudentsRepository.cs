using L04.Models;
using L04.Repository;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L04
{
    public interface IStudentsRepository
    {
        Task<List<StudentEntity>> GetAllStudents();
        Task CreateStudent(StudentEntity student);
        Task DeleteStudent(JObject delete);
        Task UpdateStudent(JObject update);
    }
}
