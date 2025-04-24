using AutoMapper;
using Discount.Grpc.Models;
using Discount.Grpc.Protos;
using Discount.Grpc.Repository;
using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly ICouponRepository _repository;
        private readonly ILogger<DiscountService> _logger;
        private readonly IMapper _mapper;
        public DiscountService(ICouponRepository repository, ILogger<DiscountService> logger,IMapper mapper)
        {
            _repository = repository ;
            _logger = logger;
            _mapper = mapper;
        }
        public override async Task<CouponRequest> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repository.GetDiscount(request.ProductId);
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Discount not found."));
            }
            _logger.LogInformation("Discount is retrived for ProductName :{productName},Amount : {amount}", coupon.ProductName, coupon.Amount);
            //return new CouponRequest { ProductId = coupon.ProductId, ProductName = coupon.ProductName, ProductDescription = coupon.Description, Amount = coupon.Amount };
            return _mapper.Map<CouponRequest>(coupon);
        }
        //public override async Task<Coupon> CreateDiscount(CouponRequest request)
        //{
        //    var coupon = request.;
        //    await _repository.CreateCoupon(coupon);
        //    return coupon;
        //}
        //public override async Task<Coupon> UpdateDiscount(CouponRequest request, ServerCallContext context)
        //{
        //    var coupon = request.Coupon;
        //    return await _repository.UpdateDiscount(coupon);
        //}
        //public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        //{
        //    var deleted = await _repository.DeleteDiscount(request.ProductName);
        //    return new DeleteDiscountResponse { Success = deleted };
        //}
    }
   
}
