using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Entity;
using OA.Dtos;
using OA.Dtos.Department;

namespace OA.Service
{
    public class OaProfile : Profile
    {
        public OaProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
        }
    }
}
