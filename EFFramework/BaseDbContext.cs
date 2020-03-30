using Autofac;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace EFFramework
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext()
            : base("name=ConnectionStrings")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var typesToRegister = Assembly.Load("Models").GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
              .Where(type => type.BaseType != null && type.BaseType.IsGenericType
             && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            //var dataAccess = Assembly.GetExecutingAssembly();

            //builder.RegisterAssemblyTypes(dataAccess)
            //       .Where(t => t.Name.EndsWith("Repository"))
            //       .AsImplementedInterfaces();

            //var builder = new ContainerBuilder();


            //foreach (var type in typesToRegister.())
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}

            //IContainer resolver = builder.Build();

            //IEnumerable<EntityTypeConfiguration<>> blls = resolver.Resolve<IEnumerable<EntityTypeConfiguration<>>>();


            //builder.RegisterGeneric(typeof(EntityTypeConfiguration<>)).As()
            //var typesToRegister = System.AppDomain.CurrentDomain.GetAssemblies().Where(s=>s.).GetTypes()
            //    .Where(type => !String.IsNullOrEmpty(type.Namespace))
            //    .Where(type => type.BaseType != null && type.BaseType.IsGenericType
            //        && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
