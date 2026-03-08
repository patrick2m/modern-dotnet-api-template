public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
{
  private readonly AppDbContext _context;

  public CreateOrderHandler(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
  {
    var order = new Order(request.Amount);

    _context.Orders.Add(order);

    await _context.SaveChangesAsync(cancellationToken);

    return order.Id;
  }
}