// See https://aka.ms/new-console-template for more information

using Autofac;
using ChannelEngineConsoleApp;

Console.WriteLine("===========Start Program============");


var container = ClassContainerConfig.Configure();

using(var scope = container.BeginLifetimeScope())
{
    var app = scope.Resolve<IApplication>();
    app.Run();
}


