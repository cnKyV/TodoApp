using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Entities;
using TodoApp.Interfaces;

namespace TodoApp.Repositories
{
    public class NodeRepository : INodeRepository
    {
        private readonly TodoDbContext _todoDbContext;
        private readonly ILogger<NodeRepository> _logger;
        public NodeRepository(TodoDbContext todoDbContext,ILogger<NodeRepository> logger)
        {
            _todoDbContext = todoDbContext;
            _logger = logger;
            
        }
        public bool Clear()
        {
            var nodes = _todoDbContext.Nodes;
            try
            {
                _todoDbContext.Nodes.RemoveRange(nodes);
                _todoDbContext.SaveChanges();              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
            return true;
        }

        public Node Create(Node node)
        {
            try
            {
                node.IsCompleted = false;
                _todoDbContext.Nodes.Add(node);
                _todoDbContext.SaveChanges();               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            _logger.LogInformation($"Node with ID:{node.Id} has been succesfully created.");
            return node;
        }

        public bool DeleteById(int id)
        {
            var node = _todoDbContext.Nodes.FirstOrDefault(x => x.Id == id);
            try
            {
                
                _todoDbContext.Nodes.Remove(node);
                _todoDbContext.SaveChanges();
                _logger.LogInformation($"Node with ID: {node.Id} has been succesfully removed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
            return true;
        }

        public IEnumerable<Node> GetAll()
        {
            try
            {
                return _todoDbContext.Nodes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            
        }

        public Node GetById(int id)
        {
            try
            {
                return _todoDbContext.Nodes.FirstOrDefault(x => x.Id == id);               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }           
        }

        public void SaveChanges()
        {
            _todoDbContext.SaveChanges();
        }

        public Node Update(Node node)
        {
            var query = _todoDbContext.Nodes.FirstOrDefault(i => i.Id == node.Id);
            try
            {
                query.Task = node.Task;
                query.Description = node.Description;
                query.Deadline = node.Deadline;
                _todoDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            _logger.LogInformation($"Node with ID: {node.Id} has been succesfully updated.");
            return node;
        }
    }
}
