using System.Collections.Generic;
using TodoApp.Entities;

namespace TodoApp.Interfaces
{
    public interface INodeRepository
    {
        IEnumerable<Node> GetAll();
        Node GetById(int id);
        Node Create(Node node);
        Node Update(Node node);
        bool Clear();
        bool DeleteById(int id);
        void SaveChanges();
    }
}
