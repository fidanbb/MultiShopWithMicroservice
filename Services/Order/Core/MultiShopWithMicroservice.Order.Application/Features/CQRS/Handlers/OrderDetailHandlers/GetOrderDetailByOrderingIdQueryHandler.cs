using MediatR;
using MultiShopWithMicroservice.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShopWithMicroservice.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShopWithMicroservice.Order.Application.Interfaces;
using MultiShopWithMicroservice.Order.Domain.Entities;


namespace MultiShopWithMicroservice.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByOrderingIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public GetOrderDetailByOrderingIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderDetailByOrderingIdQueryResult>> Handle(GetOrderDetailByOrderingIdQuery request)
        {

            var values = await _repository.GetFilteredListAsync(x => x.OrderingId == request.Id);

            return values.Select(x => new GetOrderDetailByOrderingIdQueryResult
            {
                OrderingId = x.OrderingId,
                OrderDetailId=x.OrderDetailId,
                ProductId=x.ProductId,
                ProductName=x.ProductName,
                ProductPrice=x.ProductPrice,
                TotalPrice=x.ProductTotalPrice,
                Quantity=x.ProductAmount
               
            }).ToList();
        }
    }
}
