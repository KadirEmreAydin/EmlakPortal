using EmlakPortal.Models;

namespace EmlakPortal.Dtos
{
    public class ListingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public int EstateId { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
