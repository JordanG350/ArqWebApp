using ArqWebApp.Core.Exceptions;
using HotChocolate;

namespace ArqWebApp.Api.GraphQL.Errors
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is NotFoundException notFound)
            {
                return error
                .WithMessage(notFound.Message)
                .WithCode("NOT_FOUND");
            }


            if (error.Exception is DomainException domain)
            {
                return error
                .WithMessage(domain.Message)
                .WithCode("DOMAIN_ERROR");
            }


            return error
            .WithMessage("Error interno del servidor")
            .WithCode("INTERNAL_ERROR");
        }
    }
}
