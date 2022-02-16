namespace CQRS_With_MeditR_Demo.DTO
{
    public class AddProductDTO
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public bool IsActive { get; set; } = true;
        public string Description { get; set; }
        public decimal Rate { get; set; }

    }
}
