using AutoMapper;
using OA.Dtos.Department;
using OA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
        }
    }
}
