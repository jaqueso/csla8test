using Csla;

namespace Business
{
    public static class CslaBox
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static bool TryGetPortal<T>(out IDataPortal<T> dataportal)
        {
            dataportal = default;
            if (ServiceProvider == null) return false;
            var service = ServiceProvider.GetService(typeof(IDataPortalFactory));
            if (!(service is IDataPortalFactory factory)) return false;
            dataportal = factory.GetPortal<T>();
            return dataportal != null;
        }
    }
}
