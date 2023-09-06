
namespace MultitenantWebAPI.Tenants
{
    public sealed class TenantProvider
    {
        private const string TenantIdHeaderName = "X-TenantId";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TenantService _tenantService;

        public TenantProvider
        (
            IHttpContextAccessor httpContextAccessor,
            TenantService tenantService
        )
        {
            _httpContextAccessor = httpContextAccessor;
            _tenantService = tenantService;
        }

        public string TenantId => _httpContextAccessor
            .HttpContext
            .Request
            .Headers[TenantIdHeaderName];

        public string GetConnectionString()
        {
            var tenants = _tenantService.GetTenants();
            return tenants.Single(t => t.Id == TenantId).ConnectionString;
        }
    }
}
