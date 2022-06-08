using Microsoft.Extensions.DependencyInjection;
using RobotAndMaze.Application;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Services;
using RobotAndMaze.Domain.Strategies;
using RobotAndMaze.Infrastructure;


IServiceProvider serviceProvider;

ConfigureServices();

var gameManager = serviceProvider.GetRequiredService<GameManager>();
gameManager.Run(RobotType.BasicRover);

DisposeServices();

void ConfigureServices()
{
    IRobotMoveFactory[] robotMoveFactories =
    {
        new RoverMoveFactory(new BasicRover("Jessie")),
        new RoverMoveFactory(new AdvancedRover("Walter")),
        new HelicopterMoveFactory(new BasicHelicopter("Skyler"))
    };

    var services = new ServiceCollection();
    services.AddTransient<GameManager>();
    services.AddTransient<IMatrixProvider, MatrixProvider>();
    services.AddTransient<IGameDisplay, GameDisplay>();
    services.AddTransient<IMoveService, MoveService>();
    services.AddTransient<IMoveStrategy, MoveStrategy>(_ => new MoveStrategy(robotMoveFactories));

    serviceProvider = services.BuildServiceProvider();
}

void DisposeServices()
{
    switch (serviceProvider)
    {
        case null:
            return;
        case IDisposable disposable:
            disposable.Dispose();
            break;
    }
}