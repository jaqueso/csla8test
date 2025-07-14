using System;
using System.Security.Claims;
using Csla;
using Csla.Core;

namespace Business
{
    public static class CslaBox
    {
        public static IServiceProvider? ServiceProvider { get; set; }

        public static bool TryGetPortal<T>(out IDataPortal<T> dataportal)
        {
            var context = CslaBox.ServiceProvider?.GetService(typeof(ApplicationContext)) as ApplicationContext;
            dataportal = context?.GetRequiredService<IDataPortal<T>>();
            return dataportal != null;
        }

        public static void SetUser(ClaimsPrincipal claim)
        {
            var context = CslaBox.ServiceProvider?.GetService(typeof(ApplicationContext)) as ApplicationContext;
            if (context != null) context.User = claim;
        }
    }
}
