using System;
using System.Threading.Tasks;
using Discount.Grpc.Protos;

namespace Basket.Api.GrpcServices
{
    public class DiscountGrpcService
    {

        private readonly DiscountProtoService.DiscountProtoServiceClient _grpcServiceClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient grpcServiceClient)
        {
            _grpcServiceClient = grpcServiceClient ?? throw new ArgumentNullException(nameof(grpcServiceClient));
        }

        // public async Task<CouponModel> GetDiscount(string productName){

    }
}

}