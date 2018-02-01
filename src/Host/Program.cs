using Autofac;
using ImageProcessingContracts;
using ImageProcessModule;
using LogicContracts;
using LogicModule;
using System;


namespace Host
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = Register();
            ILogic logic = container.Resolve<ILogic>();
            logic.Arguments(args);
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        private static IContainer Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Logic>()
                    .As<ILogic>()
                    .SingleInstance();
            builder.RegisterType<ImageProcessor>()
                    .As<IProcessImage>()
                  .SingleInstance();
            var container = builder.Build();
            return container;
        }
    }
}
