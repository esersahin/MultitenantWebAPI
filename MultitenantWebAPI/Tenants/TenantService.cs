namespace MultitenantWebAPI.Tenants;

public class TenantService
{
    private readonly IConfiguration _configuration;

    public TenantService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<Tenant> GetTenants()
    {
        return _configuration.GetSection("Tenants").Get<List<Tenant>>();
    }
}