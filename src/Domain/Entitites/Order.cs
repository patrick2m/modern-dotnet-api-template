public class Order
{
  public Guid Id { get; private set; }
  public decimal Amount { get; private set; }

  public Order(decimal amount)
  {
    if (amount <= 0)
      throw new DomainException("Amount must be greater than zero");

    Id = Guid.NewGuid();
    Amount = amount;
  }
}