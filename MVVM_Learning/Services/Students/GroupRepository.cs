using System.Linq;
using MVVM_Learning.Models.DeanOffice;
using MVVM_Learning.Services.Base;

namespace MVVM_Learning.Services.Students
{
    class GroupRepository : RepositoryInMemory<Group>
    {

        public GroupRepository() : base(TestData.Groups) { }

        public Group Get(string GroupName) => GetAll().FirstOrDefault(g => g.Name == GroupName);
        protected override void Update(Group Source, Group Destination)
        {
            Destination.Name = Source.Name;
            Destination.Description = Source.Description;
        }
    }
}