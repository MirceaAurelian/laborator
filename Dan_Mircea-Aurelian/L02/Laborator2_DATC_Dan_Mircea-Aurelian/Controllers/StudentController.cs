using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Laborator2_DATC_Dan_Mircea_Aurelian.Models;
using Laborator2_DATC_Dan_Mircea_Aurelian.Repositories;
using System.Text.Json;


namespace Laborator2_DATC_Dan_Mircea_Aurelian.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Student Get(int id)
        {
            foreach(var i in StudentRepo.Studenti)
            {
                if (i.id == id)
                    return i;
            }
            return null;
        }
        [HttpPost]
        public IEnumerable<Student> Post([FromBody] Student student)
        {
            StudentRepo.Studenti.Add(student);
            return StudentRepo.Studenti.ToArray();
        }
        [HttpPut]
        public IEnumerable<Student> Put([FromBody]Update update)
        {
            foreach(var i in StudentRepo.Studenti)
            {
                if(i.id == update.id)
                {
                    switch(update.camp.ToLower())
                    {
                        case "id": i.id = Convert.ToInt32(update.valoare);
                                   break;
                        case "nume": i.nume = update.valoare;
                                     break;
                        case "facultate": i.facultate = update.valoare;
                                          break;
                        case "an": i.an = Convert.ToInt32(update.valoare);
                                   break;
                    }
                    break;
                }

            }
            return StudentRepo.Studenti.ToArray();
        }
        [HttpDelete]
        public IEnumerable<Student> Delete([FromBody] JsonElement id)
        {
            foreach (var i in StudentRepo.Studenti)
            {
                if (i.id == id.GetProperty("Id").GetInt32())
                {
                    StudentRepo.Studenti.Remove(i);
                    break;
                }

            }
            return StudentRepo.Studenti.ToArray();
        }
    }
}
