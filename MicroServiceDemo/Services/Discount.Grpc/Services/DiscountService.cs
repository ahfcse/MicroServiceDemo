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
        public override async Task<CouponRequest> CreateDiscount(CouponRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request);
            var IsSave= await _repository.CreateCoupon(coupon);
            if (IsSave)
            {
                _logger.LogInformation("Discount is successfully created for ProductName :{productName},Amount : {amount}", coupon.ProductName, coupon.Amount);
            }
            else
            {
                _logger.LogError("Discount is not created for ProductName :{productName},Amount : {amount}", coupon.ProductName, coupon.Amount);
            }



            return _mapper.Map<CouponRequest>(coupon);
        }
        public override async Task<CouponRequest> UpdateDiscount(CouponRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request);
            var IsUpdate = await _repository.UpdateCoupon(coupon);
            if (IsUpdate)
            {
                _logger.LogInformation("Discount is Updated for ProductName :{productName},Amount : {amount}", coupon.ProductName, coupon.Amount);
            }
            else
            {
                _logger.LogError("Discount is not Updated for ProductName :{productName},Amount : {amount}", coupon.ProductName, coupon.Amount);
            }
            return _mapper.Map<CouponRequest>(coupon);
        }
        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var deleted = await _repository.DeleteCoupon(request.ProductId);
            if (deleted)
            {
                _logger.LogInformation("Discount is successfully deleted for ProductId :{productId}", request.ProductId);
            }
            else
            {
                _logger.LogError("Discount is not deleted for ProductId :{productId}", request.ProductId);
            }
            
            return new DeleteDiscountResponse { Success = deleted };
        }
    }
   
}
