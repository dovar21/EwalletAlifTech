namespace EwalletAlifTech.Modules.Core.Responses
{
    enum HttpStatusCode: short
    {
        OK = 0,
        UNKNOWN_ERROR = 1,
        RESOURCE_NOT_FOUND =2, 
        FORBIDDEN = 3,
        BAD_REQUEST = 4,
        VALIDATION_EXCEPTION = 5
    }
}
