﻿using Discount.Grpc;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandValidation : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidation()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
            RuleFor(x => x.Cart.UserName).NotNull().WithMessage("Username is required");
        }
    }
    public class StoreBasketCommandHandler
        (IBasketRepository repository, DiscountProtoService.DiscountProtoServiceClient discountProto) 
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            // Deduct discount
            await DeductDiscount(command.Cart, cancellationToken);

            // Store basket in DB usingg marten and redis cache
            await repository.StoreBasket(command.Cart, cancellationToken); // store basket information

            return new StoreBasketResult(command.Cart.UserName);
        }

        private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
        {
            foreach (var item in cart.Items)
            {
                var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
                item.Price -= coupon.Amount;
            }
        }
    }
}
