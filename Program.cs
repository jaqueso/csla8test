using Csla;
using Csla.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CslaBox = Client.CslaBox;

var services = new ServiceCollection();

services.AddCsla(o => o
  .Security(o => o.FlowSecurityPrincipalFromClient = false)
  .DataPortal(o => o.ClientSideDataPortal(o => o
    .UseHttpProxy(o => o.DataPortalUrl = "/api/DataPortal"))));

CslaBox.ServiceProvider = services.BuildServiceProvider();

var dpfactory = CslaBox.ServiceProvider.GetRequiredService<IDataPortalFactory>();