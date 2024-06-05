namespace EmlakPortal.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public int EstateId { get; set; }
        public Estate Estate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
