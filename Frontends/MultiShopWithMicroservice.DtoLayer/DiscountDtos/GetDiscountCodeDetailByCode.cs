using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopWithMicroservice.DtoLayer.DiscountDtos
{
    public class GetDiscountCodeDetailByCode
    {
        public string UserId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
