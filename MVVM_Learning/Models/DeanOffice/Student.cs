using System;
using System.Text;
using MVVM_Learning.Models.Interfaces;

namespace MVVM_Learning.Models.DeanOffice
{
    internal class Student : IEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public DateTime BirthDay { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; }

    }
}
