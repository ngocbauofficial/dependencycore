using AutoMapper;
using CreativeTim.Argon.DotNetCore.Free.Models;
using CreativeTim.Argon.DotNetCore.Free.Models.Cms;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeTim.Argon.DotNetCore.Free.Infrastructure.Mapper
{
    
        public class MappingExtensions : Profile
        {
            public MappingExtensions()
            {
                CreateMap<User, UserModel>();
            }
        }

}
