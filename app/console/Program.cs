using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            // pour la config, je copie colle ce qui était dans ce sample (la base pour les tests) https://github.com/danielgerlag/workflow-core/blob/06470ce83446a970ff95f2f070793cefa7f6e5cc/test/WorkflowCore.Testing/WorkflowCore.Testing.csproj
            Console.WriteLine("Start!");
            IServiceProvider serviceProvider = ConfigureServices();
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<HelloWorldWorkflow>();
            host.Start();
            host.StartWorkflow("HelloWorld", 1, null);
            Console.ReadLine(); // wait for async workflow to be over
            host.Stop();
            Console.WriteLine("End!");
        }

        private static IServiceProvider ConfigureServices()
        {
            //setup dependency injection
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddWorkflow();
            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }

    public class HelloWorld : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Hello world");
            return ExecutionResult.Next();
        }
    }

    public class GoodbyeWorld : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Goodbye world");
            Console.WriteLine("(type anything to quit)");
            return ExecutionResult.Next();
        }
    }

    public class HelloWorldWorkflow : IWorkflow
    {
        public string Id => "HelloWorld";
        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith<HelloWorld>()
                .Then<GoodbyeWorld>();
        }
    }

}
