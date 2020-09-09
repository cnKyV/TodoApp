using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApp.Entities;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly INodeService _nodeService;
        private readonly IMapper _mapper;
        private readonly ILogger<NodeController> _logger;
        public NodeController(INodeService nodeService, IMapper mapper, ILogger<NodeController> logger)
        {
            _nodeService = nodeService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(NodeCreateModel nodeCreateModel)
        {
            Node node = _mapper.Map<Node>(nodeCreateModel);
            NodeResponseModel nodeResponseModel = _mapper.Map<NodeResponseModel>(_nodeService.Create(node));
            return Ok(nodeResponseModel);
        }
        [HttpPut]
        public IActionResult Update(NodeUpdateModel nodeUpdateModel)
        {
            Node node = _mapper.Map<Node>(nodeUpdateModel);
            NodeResponseModel nodeResponseModel = _mapper.Map<NodeResponseModel>(_nodeService.Update(node));
            return Ok(nodeResponseModel);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<NodeResponseModel> nodeResponseModels = _mapper.Map<IEnumerable<NodeResponseModel>>(_nodeService.GetAll());
            return Ok(nodeResponseModels);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var node = _nodeService.GetById(id);
            if (node == null)
            {
                return NotFound();
            }
            NodeResponseModel nodeResponseModel = _mapper.Map<NodeResponseModel>(node);
            return Ok(nodeResponseModel);
        }
        [HttpDelete]
        public IActionResult Clear()
        {
            return Ok(_nodeService.Clear());
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            
            return Ok(_nodeService.DeleteById(id));
            
        }
        [HttpPatch("{id}")]
        public IActionResult Completed(int id)
        {

            return Ok(_nodeService.Completed(id));
            
        }
    }
}
