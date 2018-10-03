using Autofac;
using CreationalLibrary.Singleton;
using Xunit;

namespace CreationalLibrary.Tests
{
    public class SingletonDataBaseTests
    {
        [Fact]
        public void SingletonDataBaseTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.True(db.Equals(db2));
        }

        [Fact]
        public void DISingletonDatabaseTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConfigurableDatabase>()
                .As<IDatabase>()
                .SingleInstance();

            builder.RegisterType<ConfigurableRecordFinder>();

            using (var c = builder.Build())
            {
                var recordFinder = c.Resolve<ConfigurableRecordFinder>();
                var recordFinder2 = c.Resolve<ConfigurableRecordFinder>();

                Assert.False(ReferenceEquals(recordFinder, recordFinder2));
                Assert.True(ReferenceEquals(recordFinder.Database, recordFinder2.Database));
            }
        }
    }
}
