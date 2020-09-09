using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Entities;
using TodoApp.Models;

namespace TodoApp.Mapping
{
    public class NodeMappingProfile : Profile
    {
        public NodeMappingProfile()
        {
            CreateMap<Node, NodeResponseModel>();
            CreateMap<NodeCreateModel, Node>();
            CreateMap<NodeUpdateModel, Node>();
        }
    }
}
