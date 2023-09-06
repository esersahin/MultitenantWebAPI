using Microsoft.Extensions.Options;

namespace MultitenantWebAPI.Tenants;

public class TenantService
{
    private readonly List<Tenant> _tenants;

    public TenantService
    (
        IOptions<List<Tenant>> tenants
    )
    {
        _tenants = tenants.Value;
    }

    public List<Tenant> GetTenants()
    {
        return _tenants;
    }
}