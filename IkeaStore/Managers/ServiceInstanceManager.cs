using System;
using IkeaStore.IServices;
using IkeaStore.Services;

namespace IkeaStore.Managers
{
    public class ServiceInstanceManager
    {
        // Register any service that should be considered as a singleton

        private IServiceDialogs serviceDialogs;

        public IServiceDialogs GetServiceDialogsInstance()
        {
            if (serviceDialogs == null) return new ServiceDialogs();

            return serviceDialogs;
        }

    }
}
