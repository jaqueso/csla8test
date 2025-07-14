using System.Security.Claims;
using Business;
using Csla.Configuration;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddTransient<HttpClient>();

var portal = "https://localhost:7282";
services.AddCsla(
    o => o
        .Security(s =>
        {
            s.AuthenticationType = "Custom";
            s.FlowSecurityPrincipalFromClient = true;
        })
        .DataPortal(o => 
            o.ClientSideDataPortal(o => 
                o.UseHttpProxy(o => 
                    o.DataPortalUrl = portal + "/api/DataPortal")))
  );

CslaBox.ServiceProvider = services.BuildServiceProvider();

var identity = new ClaimsIdentity("asdf");
var principal = new ClaimsPrincipal(identity);
CslaBox.SetUser(principal);

var cmd = RandomNumberCommand.Execute();
Console.WriteLine(cmd.Result);