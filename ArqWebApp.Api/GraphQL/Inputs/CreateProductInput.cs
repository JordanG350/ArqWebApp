namespace ArqWebApp.Api.GraphQL.Inputs
{
    public record CreateProductInput(
    string Name,
    string Description,
    double Price
    );
}
