using Microsoft.AspNetCore.Http;

namespace MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductImageDtos
{
    public class CreateProductImageDto
    {
        public string ImageUrl { get; set; }
        public IEnumerable<IFormFile> MultiFile { get; set; }

        public string ProductId { get; set; }
    }
}
