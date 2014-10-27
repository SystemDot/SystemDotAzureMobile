using System;
using SystemDot.Bootstrapping;
using SystemDot.Ioc;
using SystemDot.RelationalDataStore.Bootstrapping;
using SystemDot.RelationalDataStore.InMemory.Bootstrapping;
using Machine.Specifications;

namespace SystemDot.Domain.Specifications.configuring
{
    public class when_using_in_memory_relational_data_storing
    {
        static Exception exception;

        Establish context = () => exception = Catch.Exception(() =>
            Bootstrap.Application()
                .ResolveReferencesWith(new IocContainer())
                .UseRelationalDataStore().PersistToMemory()
                .InitialiseAsync().Wait());

        It should_verify_that_all_in_memory_data_storing_components_are_setup = () =>
            exception.ShouldBeNull();
    }
}