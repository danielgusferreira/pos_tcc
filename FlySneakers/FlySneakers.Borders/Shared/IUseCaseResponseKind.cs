using System.Net;

namespace FlySneakers.Borders.Shared
{
    public enum UseCaseResponseKind
    {
        Success = HttpStatusCode.OK,
        DataPersisted = HttpStatusCode.Created,
        DataAccepted = HttpStatusCode.Accepted,
        InternalServerError = HttpStatusCode.InternalServerError,
        RequestValidationError = HttpStatusCode.BadRequest,
        ForeignKeyViolationError = HttpStatusCode.BadRequest,
        UniqueViolationError = HttpStatusCode.Conflict,
        NotFound = HttpStatusCode.NotFound,
        Unauthorized = HttpStatusCode.Unauthorized,
        Forbidden = HttpStatusCode.Forbidden,
        Unavailable = HttpStatusCode.ServiceUnavailable,
        BadRequest = HttpStatusCode.BadRequest
    }
}
