using MediatR;
using MultiShopWithMicroservice.Order.Application.Features.CQRS.Results.OrderDetailResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopWithMicroservice.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByOrderingIdQuery
    {
        public int Id { get; set; }
        public GetOrderDetailByOrderingIdQuery(int id)
        {
            Id = id;
        }
    }
}
