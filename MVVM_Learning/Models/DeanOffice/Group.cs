using System.Collections.Generic;
using MVVM_Learning.Models.Interfaces;

namespace MVVM_Learning.Models.DeanOffice
{
    internal class Group : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Student> Students { get; set; } = new List<Student>();

        public string Description { get; set; }
        
    }
}