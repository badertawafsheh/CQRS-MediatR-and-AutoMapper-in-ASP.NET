namespace CQRS_With_MeditR_Demo.DTO
{
    public class GetProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }

    }
}
