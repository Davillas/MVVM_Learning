using System;
using System.Collections.Generic;
using System.Text;
using MVVM_Learning.Models.DeanOffice;
using MVVM_Learning.Services.Base;

namespace MVVM_Learning.Services.Students
{
    class StudentRepository : RepositoryInMemory<Student>
    {
        protected override void Update(Student Source, Student Destination)
        {
            Destination.Name = Source.Name;
            Destination.Surname = Source.Surname;
            Destination.Patronymic = Source.Patronymic;
            Destination.BirthDay = Source.BirthDay;
            Destination.Rating = Source.Rating;

        }
    }
}
