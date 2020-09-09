using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Entities;
using TodoApp.Interfaces;

namespace Infrastructure.Services
{
    public class NodeService : INodeService
    {
        private readonly INodeRepository _nodeRepository;
        private readonly ILogger<NodeService> _logger;
        public NodeService(INodeRepository nodeRepository, ILogger<NodeService> logger)
        {
            _nodeRepository = nodeRepository;
            _logger = logger;
        }
        public bool Clear()
        {
            return _nodeRepository.Clear();
        }

        public bool Completed(int id)
        {

            var query = _nodeRepository.GetById(id);
            try
            {
                query.IsCompleted = true;
                _nodeRepository.SaveChanges();
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
            return _nodeRepository.Create(node);
        }

        public bool DeleteById(int id)
        {
            return _nodeRepository.DeleteById(id);
        }

        public IEnumerable<Node> GetAll()
        {
            return _nodeRepository.GetAll();
        }

        public Node GetById(int id)
        {
            return _nodeRepository.GetById(id);
        }

        public Node Update(Node node)
        {
            return _nodeRepository.Update(node);
        }
    }
}
