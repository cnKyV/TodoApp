using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Entities;

namespace Infrastructure.Interfaces
{
    public interface INodeService
    {
        IEnumerable<Node> GetAll();
        Node GetById(int id);
        Node Create(Node node);
        Node Update(Node node);
        bool Completed(int id);
        bool Clear();
        bool DeleteById(int id);
        
    }
}
