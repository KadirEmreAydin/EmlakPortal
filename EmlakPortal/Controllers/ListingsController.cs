using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmlakPortal.Dtos;
using EmlakPortal.Models;

namespace EmlakPortal.Controllers
{
    [Route("api/Listing")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public ListingController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<ListingDto> GetList()
        {
            var Listings = _context.Listings.ToList();
            var ListingDtos = _mapper.Map<List<ListingDto>>(Listings);
            return ListingDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public ListingDto Get(int id)
        {
            var Listing = _context.Listings.Where(s => s.Id == id).SingleOrDefault();
            var ListingDto = _mapper.Map<ListingDto>(Listing);
            return ListingDto;
        }

        [HttpPost]
        public ResultDto Post(ListingDto dto)
        {
            if (_context.Listings.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Gayrimenkul Adı Kayıtlıdır!";
                return result;
            }
            var Listing = _mapper.Map<Listing>(dto);
            Listing.Updated = DateTime.Now;
            Listing.Created = DateTime.Now;
            _context.Listings.Add(Listing);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Gayrimenkul Eklendi";
            return result;
        }


        [HttpPut]
        public ResultDto Put(ListingDto dto)
        {
            var Listing = _context.Listings.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (Listing == null)
            {
                result.Status = false;
                result.Message = "Gayrimenkul Bulunamadı!";
                return result;
            }
            Listing.Name = dto.Name;
            Listing.IsActive = dto.IsActive;
            Listing.Price = dto.Price;
            Listing.Updated = DateTime.Now;
            Listing.EstateId = dto.EstateId;
            _context.Listings.Update(Listing);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Gayrimenkul Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var Listing = _context.Listings.Where(s => s.Id == id).SingleOrDefault();
            if (Listing == null)
            {
                result.Status = false;
                result.Message = "Gayrimenkul Bulunamadı!";
                return result;
            }
            _context.Listings.Remove(Listing);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Gayrimenkul Silindi";
            return result;
        }
    }
}
