﻿namespace MultiShopWithMicroservice.Catalog.Dtos.ProductImageDtos
{
    public class UpdateProductImageDto
    {
        public string ProductImageID { get; set; }
        public string ImageUrl { get; set; }

        public string ProductId { get; set; }
    }
}
