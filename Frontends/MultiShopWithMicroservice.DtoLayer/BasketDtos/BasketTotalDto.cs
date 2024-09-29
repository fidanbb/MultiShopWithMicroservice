﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopWithMicroservice.DtoLayer.BasketDtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }

        public string DiscountCode { get; set; }

        public int? DiscountRate { get; set; }

        public IList<BasketItemDto> BasketItems { get; set; }
        public bool HasDiscount
        {
            get
            {
                if (DiscountCode != "-")
                {
                    return true;
                }
                return false;
            }
        }

        public decimal OriginalPrice
        {
            get
            {
                return BasketItems.Sum(x => x.Price * x.Quantity);
            }
        }
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = BasketItems.Sum(x => x.Price * x.Quantity);
                if (HasDiscount)
                {
                    if (DiscountRate.HasValue && DiscountRate > 0)
                    {
                        decimal discountAmount = totalPrice * ((decimal)DiscountRate / 100);
                        totalPrice -= discountAmount;
                    }
                }
                return totalPrice;
            }
        }
    }
}
