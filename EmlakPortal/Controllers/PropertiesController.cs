using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmlakPortal.Dtos;
using EmlakPortal.Models;

namespace EmlakPortal.Controllers
{
    [Route("api/Properties")]
    [ApiController]
    [Authorize]
    public class PropertiesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public PropertiesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<EstateDto> GetList()
        {
            var Properties = _context.Properties.ToList();
            var EstateDtos = _mapper.Map<List<EstateDto>>(Properties);
            return EstateDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public EstateDto Get(int id)
        {
            var Estate = _context.Properties.Where(s => s.Id == id).SingleOrDefault();
            var EstateDto = _mapper.Map<EstateDto>(Estate);
            return EstateDto;
        }
        [HttpGet]
        [Route("{id}/Listings")]
        public List<ListingDto> GetListings(int id)
        {
            var Listings = _context.Listings.Where(s => s.EstateId == id).ToList();
            var ListingDtos = _mapper.Map<List<ListingDto>>(Listings);
            return ListingDtos;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ResultDto Post(EstateDto dto)
        {
            if (_context.Properties.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Kategori Adı Kayıtlıdır!";
                return result;
            }
            var Estate = _mapper.Map<Estate>(dto);
            Estate.Updated = DateTime.Now;
            Estate.Created = DateTime.Now;
            _context.Properties.Add(Estate);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Kategori Eklendi";
            return result;
        }


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public ResultDto Put(EstateDto dto)
        {
            var Estate = _context.Properties.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (Estate == null)
            {
                result.Status = false;
                result.Message = "Kategori Bulunamadı!";
                return result;
            }
            Estate.Name = dto.Name;
            Estate.IsActive = dto.IsActive;
            Estate.Updated = DateTime.Now;

            _context.Properties.Update(Estate);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Kategori Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public ResultDto Delete(int id)
        {
            var Estate = _context.Properties.Where(s => s.Id == id).SingleOrDefault();
            if (Estate == null)
            {
                result.Status = false;
                result.Message = "Kategori Bulunamadı!";
                return result;
            }
            _context.Properties.Remove(Estate);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Kategori Silindi";
            return result;
        }
    }
}
