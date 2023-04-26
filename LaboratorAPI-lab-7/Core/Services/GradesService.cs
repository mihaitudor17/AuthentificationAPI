using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class GradesService
    {
        private readonly UnitOfWork unitOfWork;

        public GradesService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Dictionary<string,List<Grade>> GetAll()
        {
            return unitOfWork.Students.GetAll().ToDictionary(student => student.FirstName+" "+student.LastName,
                                                             student => student.Grades);                            
        }
        public List<Grade> GetGrades(int id) 
        {
            return unitOfWork.Students.GetById(id).Grades;
        }
    }
}
