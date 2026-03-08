public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
  public CreateOrderValidator()
  {
    RuleFor(x => x.Amount)
      .GreaterThan(0);
  }
}