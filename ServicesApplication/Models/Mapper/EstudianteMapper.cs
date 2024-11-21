using System;
using AutoMapper;
using System.Collections.Generic;
using ServiceApplication.Dto;
using Domian.Entity;

namespace ServiceApplication.Models.Auth.Mapper
{
    public static class EstudianteMapper
    {
        public static void Expresion(IMapperConfigurationExpression cnf)
        {
            cnf.CreateMap<Estudiante, EstudianteDto>().ReverseMap();
        }
    }
}
