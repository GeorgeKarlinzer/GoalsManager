using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.Extensions.Options;

namespace GoalsManager.Web.Tests.Mocking
{
    public class TestOperationalStoreOptions : IOptions<OperationalStoreOptions>
    {
        public OperationalStoreOptions Value => new()
        {
            DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
            EnableTokenCleanup = false,
            PersistedGrants = new TableConfiguration("PersistedGrants"),
            TokenCleanupBatchSize = 100,
            TokenCleanupInterval = 3600,
        };
    }
}
