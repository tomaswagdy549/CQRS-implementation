using Catalog.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Catalog.Infrastructure;
public class AuditService : IAuditService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuditService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetCurrentUserId()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value ?? "Unknown";
    }

    public string GetCurrentUserName()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirst("name")?.Value ?? "Unknown";
    }

    public DateTime GetCurrentUtcTime()
    {
        return DateTime.UtcNow;
    }
}
