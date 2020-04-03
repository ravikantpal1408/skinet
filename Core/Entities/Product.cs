namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; } // related entity 
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; } /* reacted entity  */   
        public int ProductBrandId { get; set; }
    }
}