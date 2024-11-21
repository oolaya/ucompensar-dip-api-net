using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServiceApplication
{
    public interface IBaseServiceApplication<ENT, DTO>
        where ENT : class, new()
         where DTO : class, new()
    {
        Task<DTO> CreateModel(DTO dto);

        Task<List<DTO>> TolistModel();

    }
}
