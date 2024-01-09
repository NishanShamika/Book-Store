using System.Net;

namespace BookStore.Application.Helpers.Exceptions;

public class CustomeException : Exception
{
    public string CustomMessage { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }
}
