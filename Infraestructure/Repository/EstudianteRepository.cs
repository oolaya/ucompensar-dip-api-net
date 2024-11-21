using Domian.Entity;
using Domian.Port;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class EstudianteRepository : RepositoryBaseCosmosDB<Estudiante>, IRepositoryBaseCosmosDB<Estudiante> , IEstudianteRepository
    {
        public EstudianteRepository(IMainContextCosmos mainContext)
            :base(mainContext) { }
    }
}
