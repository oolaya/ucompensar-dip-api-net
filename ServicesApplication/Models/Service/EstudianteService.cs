
using System.Collections.Generic;
using System.Linq.Expressions;
using System.IO;
using ServiceApplication.Base;
using Domian.Entity;
using ServiceApplication.Dto;
using ServiceApplication.Models.Auth.Mapper;
using Domian.Port;

namespace ServiceApplication
{
    public class EstudianteService : BaseServiceApplication<Estudiante, EstudianteDto>, IBaseServiceApplication<Estudiante, EstudianteDto>,IEstudianteService
    {

        public EstudianteService(IEstudianteRepository estudianteRepository)
            :base(estudianteRepository)
        {
            CreateMapperExpresion<Estudiante, EstudianteDto>(cnf =>
            {
                EstudianteMapper.Expresion(cnf);
            });
        }

      
    }
}
