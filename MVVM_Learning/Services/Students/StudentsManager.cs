using System;
using System.Collections.Generic;
using System.Text;
using MVVM_Learning.Models.DeanOffice;

namespace MVVM_Learning.Services.Students
{
    class StudentsManager
    {
        private readonly StudentRepository _Students;
        private readonly GroupRepository _Groups;

        public IEnumerable<Student> Students => _Students.GetAll();
        public IEnumerable<Group> Groups => _Groups.GetAll();


        public StudentsManager(StudentRepository Students, GroupRepository Groups)
        {
            _Students = Students;
            _Groups = Groups;
        }
    }
}
