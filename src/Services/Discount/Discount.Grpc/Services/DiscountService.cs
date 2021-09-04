using System;
using System.Threading.Tasks;
using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Discount.Grpc.Services
{

    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepo _repo;
        private readonly ILogger<DiscountService> _logger;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepo repo, ILogger<DiscountService> logger, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);
            await _repo.CreateDiscount(coupon);
            _logger.LogInformation($"CreateDiscount Success. Product Name: {coupon.ProductName}");

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }
        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);
            await _repo.UpdateDiscount(coupon);
            _logger.LogInformation($"UpdateDiscount Success. Product Name: {coupon.ProductName}");

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;

        }
        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var deleted = await _repo.DeleteDiscount(request.ProductName);
            _logger.LogInformation($"DeleteDiscount Success. Product Name: {request.ProductName}");
            return new DeleteDiscountResponse { Success = deleted };
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repo.GetDiscount(request.ProductName);

            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} not found"));
            }
            _logger.LogInformation($"Discount is retreived for Product: {request.ProductName}, Amount: {coupon.Amount}")
            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }
    }
}

