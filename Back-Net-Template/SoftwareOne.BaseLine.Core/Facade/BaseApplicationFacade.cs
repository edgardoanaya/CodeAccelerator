using AutoMapper;
using SoftwareOne.BaseLine.Core.DataAccess;
using SoftwareOne.BaseLine.Core.Entities;
using SoftwareOne.BaseLine.Core.RequestDto;
using System.Linq.Expressions;
using SoftwareOne.BaseLine.ApplicationTexts;

namespace SoftwareOne.BaseLine.Core.Facade
{
    public abstract class BaseApplicationFacade<T, TDto, IApplicationServicesEntity> : IBaseApplicationFacade<T, TDto>
        where T : class, new()
        where TDto : class, new()
        where IApplicationServicesEntity : IBaseRepositoryDataAccess<T>
    {
        //Initialize the mapper
        protected readonly MapperConfiguration configMapperFacade =
            new(cfg =>
            {
                cfg.CreateMap<T, TDto>();
                cfg.CreateMap<TDto, T>();
            });
        protected IMapper _mapper;

        /// <summary>
        /// Entity that contains the Business context of the Entity <typeparamref name="T"/>
        /// </summary>
        protected readonly IApplicationServicesEntity applicationServicesEntity;

        /// <summary>
        /// Base Class Constructor Method
        /// </summary>
        /// <param name="applicationServicesEntity">Entity Context <typeparamref name="T"/> containing the interface instance or method implementations.</param>
        protected BaseApplicationFacade(IApplicationServicesEntity applicationServicesEntity)
        {
            this.applicationServicesEntity = applicationServicesEntity;
            _mapper = new Mapper(configMapperFacade);
        }

        public IMainDataAccessContext Contexto => applicationServicesEntity.Contexto;

        public ICollection<TDto> ListAll()
        {
            return _mapper.Map<ICollection<TDto>>(this.applicationServicesEntity.ListAll());
        }

        public ICollection<TDto> ListAll(SwoParameterOfQuery<T> parameterOfList)
        {
            return _mapper.Map<ICollection<TDto>>(this.applicationServicesEntity.ListAll(parameterOfList));
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return this.applicationServicesEntity.Count(expression);
        }

        public TDto? Get(Expression<Func<T, bool>> expression)
        {
            return _mapper.Map<TDto>(this.applicationServicesEntity.Get(expression));
        }

        public TDto? Get(Expression<Func<T, bool>> expression, Expression<Func<T, object>> include)
        {
            return _mapper.Map<TDto>(this.applicationServicesEntity.Get(expression, include));
        }

        public int? Add(TDto objectAdd)
        {
            return applicationServicesEntity.Add(_mapper.Map<T>(objectAdd));
        }

        public int? Add(IEnumerable<TDto> listObjectsAdd)
        {
            return applicationServicesEntity.Add(_mapper.Map<IEnumerable<T>>(listObjectsAdd));
        }

        public bool? Update(TDto objectUpdate)
        {
            return applicationServicesEntity.Update(_mapper.Map<T>(objectUpdate));
        }

        public bool? Update(ICollection<TDto> listObjectsUpdate)
        {
            return applicationServicesEntity.Update(_mapper.Map<ICollection<T>>(listObjectsUpdate));
        }

        public bool? Delete(TDto objectDelete)
        {
            return applicationServicesEntity.Delete(_mapper.Map<T>(objectDelete));
        }

        public bool? Delete(Expression<Func<T, bool>> expression)
        {
            return applicationServicesEntity.Delete(expression);
        }

        public bool? DeleteRange(Expression<Func<T, bool>> expression)
        {
            return applicationServicesEntity.DeleteRange(expression);
        }

        public bool? DeleteRange(ICollection<TDto> listObjectsDelete)
        {
            return applicationServicesEntity.DeleteRange(_mapper.Map<ICollection<T>>(listObjectsDelete));
        }

        public async Task<List<TDto>> ListAllAsync()
        {
            return _mapper.Map<List<TDto>>(await applicationServicesEntity.ListAllAsync());
        }

        public async Task<List<TDto>> ListAllAsync(SwoParameterOfQuery<T> parameterOfList)
        {
            return _mapper.Map<List<TDto>>(await applicationServicesEntity.ListAllAsync(parameterOfList));
        }

        public async Task<TDto> GetAsync(Expression<Func<T, bool>> expression)
        {
            return _mapper.Map<TDto>(await applicationServicesEntity.GetAsync(expression));
        }

        public async Task<TDto> AddAsync(TDto objectAdd)
        {
            return _mapper.Map<TDto>(await applicationServicesEntity.AddAsync(_mapper.Map<T>(objectAdd)));
        }

        public Task<int> AddAsync(IEnumerable<TDto> listObjectsAdd)
        {
            return applicationServicesEntity.AddAsync(_mapper.Map<IEnumerable<T>>(listObjectsAdd));
        }

        public async Task<TDto> UpdateAsync(TDto objectUpdate)
        {
            return _mapper.Map<TDto>(await applicationServicesEntity.UpdateAsync(_mapper.Map<T>(objectUpdate)));
        }

        public Task<int> UpdateAsync(ICollection<TDto> listObjectsUpdate)
        {
            return applicationServicesEntity.UpdateAsync(_mapper.Map<ICollection<T>>(listObjectsUpdate));
        }

        public Task<int> DeleteAsync(TDto objectDelete)
        {
            return applicationServicesEntity.DeleteAsync(_mapper.Map<T>(objectDelete));
        }

        public async Task<BaseResponseDto> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            int result = await applicationServicesEntity.DeleteAsync(expression);
            if(result > 0) {
                return new BaseResponseDto();
            } else {
                return new BaseResponseDto {
                    Code = "500",
                    Message = ResourceTexts.InternalServerError
                };
            }
        }

        public Task<int> DeleteRangeAsync(Expression<Func<T, bool>> expression)
        {
            return applicationServicesEntity.DeleteRangeAsync(expression);
        }

        public Task<int> DeleteRangeAsync(ICollection<TDto> listObjectsDelete)
        {
            return applicationServicesEntity.DeleteRangeAsync(_mapper.Map<ICollection<T>>(listObjectsDelete));
        }

        public SwoPaginatedList<TDto> ListAllPaged(SwoParameterOfQuery<T> parameterOfList)
        {
            var listPaged = applicationServicesEntity.ListAllPaged(parameterOfList);
            return new SwoPaginatedList<TDto>(_mapper.Map<List<TDto>>(listPaged.List), listPaged.Paged);
        }
    }
}