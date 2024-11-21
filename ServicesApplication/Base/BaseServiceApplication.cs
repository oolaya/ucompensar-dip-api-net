
using AutoMapper;
using Domian.Port;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServiceApplication.Base
{
    public abstract partial class BaseServiceApplication<ENT, DTO> : IBaseServiceApplication<ENT, DTO>
        where ENT : class, new()
        where DTO : class, new()
    {




        public IRepositoryBaseCosmosDB<ENT> RepositoryBase { get; set; }
        private MapperConfigurationExpression configurationmapper;
        private IMapper Mapper;

        public BaseServiceApplication(IRepositoryBaseCosmosDB<ENT> repositoryBase)
        {
            RepositoryBase = repositoryBase;
        }
        public BaseServiceApplication()
        {

        }

        public virtual async Task<DTO> CreateModel(DTO dto)
        {
            var entity = MapToENT<ENT, DTO>(dto);
            return MapToDTO<ENT, DTO>(await RepositoryBase.CreateModel(entity));
        }

        public virtual async Task<List<DTO>> TolistModel()
        {
            return MapLstToDTO<ENT, DTO>(await RepositoryBase.ToListModel());

        }

        public List<DTO> MapLstToDTO<ENT, DTO>(List<ENT> entity)
        {
            return Mapper.Map<List<DTO>>(entity);
        }

        public List<ENT> MapLstToENT<ENT, DTO>(List<DTO> dto)
        {
            return Mapper.Map<List<ENT>>(dto);
        }

        public ENT MapToENT<ENT, DTO>(DTO dto)
        {
            return Mapper.Map<ENT>(dto);
        }

        public DTO MapToDTO<ENT, DTO>(ENT entity)
        {
            return Mapper.Map<DTO>(entity);
        }

        protected void CreateMapper<ENT, DTO>() where ENT : class, new() where DTO : class, new()
        {
            configurationmapper = CreateConfiguration<ENT, DTO>();
            CreateMapper();
        }

        public void CreateMapperExpresion<ENT, DTO>(Action<IMapperConfigurationExpression> configure) where ENT : class, new() where DTO : class, new()
        {
            configurationmapper = CreateConfiguration<ENT, DTO>();
            CreateMapperExpresion(configure);
        }

        public void CreateMapperExpresion(Action<IMapperConfigurationExpression> configure)
        {
            configure(configurationmapper);
            CreateMapper();
        }

        protected void CreateMapper()
        {
            MapperConfiguration cnfMapper = new(configurationmapper);
            Mapper = cnfMapper.CreateMapper();
        }

        private static MapperConfigurationExpression CreateConfiguration<ENT, DTO>() where ENT : class, new() where DTO : class, new()
        {
            var cnf = new MapperConfigurationExpression
            {
                AllowNullCollections = true
            };
            cnf.CreateMap<DateTimeOffset, DateTime>().ConvertUsing(n => n.UtcDateTime);
            cnf.CreateMap<DateTime, DateTimeOffset>().ConvertUsing(n => DateTime.SpecifyKind(n, DateTimeKind.Utc));
            return cnf;

        }

    }
}
