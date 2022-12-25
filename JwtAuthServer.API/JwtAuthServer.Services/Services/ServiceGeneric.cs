using JwtAuthServer.Core.Repositories;
using JwtAuthServer.Core.Services;
using JwtAuthServer.Core.UnitOfWork;
using JwtAuthServer.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthServer.Services.Services
{
    public class ServiceGeneric<TEntity, TDto> : IServiceGeneric<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;

        public ServiceGeneric(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Response<TDto>> AddAsync(TDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            await _genericRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);

            return Response<TDto>.Success(newDto, 200);

            //return Response<TDto>.Success(entity ,200);  //üstteki 2 komut satırı yerine direkt bunu yazsak olur mu ? dene !!!
        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            var products = _genericRepository.GetByIdAsync(id);

            if (products == null)
            {
                return Response<TDto>.Fail("Id Not Found !", 404, true);
            }

            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(products), 200);
        }

        public async Task<Response<NoDataDto>> Remove(int id)
        {
            var IsExistEntity = await _genericRepository.GetByIdAsync(id);

            if (IsExistEntity == null)
            {
                return Response<NoDataDto>.Fail("Id Not Found !", 404, true);
            }

            _genericRepository.Remove(IsExistEntity);

            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(204);
            //204 code => no content => response body empty


        }

        public async Task<Response<NoDataDto>> Update(TDto entity, int id)
        {
            var IsExistEntity = await _genericRepository.GetByIdAsync(id);

            if (IsExistEntity == null)
            {
                return Response<NoDataDto>.Fail("Id Not Found ! ", 404, true);
            }

            var updateEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            _genericRepository.Update(updateEntity);
            await _unitOfWork.CommitAsync(); 

            return Response<NoDataDto>.Success(204);
            //204 code => no content => response body empty
        }

        public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var list = _genericRepository.Where(predicate);

            return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()),200);
        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            /*
            var values = await _genericRepository.GetAllAsync();
            var valuesDto = ObjectMapper.Mapper.Map<TDto>(values);
            return Response<IEnumerable<TDto>>.Success(valuesDto,200);        //bu olur mu ? */


            var products = ObjectMapper.Mapper.Map<List<TDto>>(await _genericRepository.GetAllAsync());
            return Response<IEnumerable<TDto>>.Success(products, 200);
        }

    }
}
