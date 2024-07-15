using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaMicroServicios.Api.Cupon.Data;
using TiendaMicroServicios.Api.Cupon.Models.Dto;

namespace TiendaMicroServicios.Api.Cupon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuponController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly ResponseDto _responseDto;
        private readonly IMapper _mapper;

        public CuponController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<TiendaMicroServicios.Api.Cupon.Models.Cupon> Cupones = await _appDbContext.Cupons.ToListAsync();
                _responseDto.Result = _mapper.Map<IEnumerable<CuponDto>>(Cupones);
                _responseDto.IsSuccess = true;
            } catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("id:int")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                TiendaMicroServicios.Api.Cupon.Models.Cupon cupon = await _appDbContext.Cupons.FindAsync(id);
                _responseDto.Result = _mapper.Map<CuponDto>(cupon);
                _responseDto.IsSuccess = true;
                return _responseDto;
            } catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return null;
        }

        [HttpGet]
        [Route("getbycode/{code}")]
        public async Task<ResponseDto> GetByCode(string code)
        {
            try
            {
                TiendaMicroServicios.Api.Cupon.Models.Cupon cupon = await _appDbContext.Cupons.SingleOrDefaultAsync(p => p.CuponCode.Equals(code));
                _responseDto.Result = _mapper.Map<CuponDto>(cupon);
                _responseDto.IsSuccess = true;
                return _responseDto;
            } catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return null;
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] CuponDto cuponDto)
        {
            try
            {
                Cupon.Models.Cupon obj = _mapper.Map<Cupon.Models.Cupon>(cuponDto);
                _appDbContext.Cupons.Add(obj);
                await _appDbContext.SaveChangesAsync();
                _responseDto.Result = _mapper.Map<CuponDto>(obj);
                _responseDto.IsSuccess = true;
            } catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] CuponDto cuponDto)
        {
            try
            {
                Cupon.Models.Cupon obj = _mapper.Map<Cupon.Models.Cupon>(cuponDto);
                _appDbContext.Cupons.Update(obj);
                await _appDbContext.SaveChangesAsync();
                _responseDto.Result = _mapper.Map<CuponDto>(obj);
                _responseDto.IsSuccess = true;
            }catch(Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpDelete]
        [Route("id:int")]
        public async Task<ResponseDto> Delete(int id)
        {
            try 
            {
                TiendaMicroServicios.Api.Cupon.Models.Cupon cupon = await _appDbContext.Cupons.FindAsync(id);
                _appDbContext.Cupons.Remove(cupon);
                await _appDbContext.SaveChangesAsync();
                _responseDto.IsSuccess = true;
            }catch(Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
