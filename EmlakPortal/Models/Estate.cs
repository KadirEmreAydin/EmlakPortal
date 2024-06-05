using Microsoft.AspNetCore.Http.HttpResults;

namespace EmlakPortal.Models

{
    public class Estate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Listing> Listing { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
