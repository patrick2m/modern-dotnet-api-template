public static class CreateOrderEndpoint
{
  public static void MapCreateOrderEndpoint(this IEndpointRouteBuilder app)
  {
    app.MapPost("/orders", async (CreateOrderCommand command, IMediator mediator) =>
    {
      var result = await mediator.Send(command);
      return Results.Ok(result);
    });
  }
}