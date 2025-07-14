using Business;
using Csla;
using Csla.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CslaBox = Business.CslaBox;

var services = new ServiceCollection();
services.AddTransient<HttpClient>();

services.AddCsla(o => o
  .Security(o => o.FlowSecurityPrincipalFromClient = false)
  .DataPortal(o => o.ClientSideDataPortal(o => o
    .UseHttpProxy(o => o.DataPortalUrl = "/api/DataPortal"))));

CslaBox.ServiceProvider = services.BuildServiceProvider();

var identity = new ClaimsIdentity("asdf");
var principal = new ClaimsPrincipal(identity);
CslaBox.SetUser(principal);

var cmd = RandomNumberCommand.Execute();
Console.WriteLine(cmd.Result);