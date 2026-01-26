namespace ArqWebApp.Api.GraphQL.Inputs
{
    public record UpdateProductInput(
    int Id,
    string Name,
    string Description,
    double Price
    );
}
