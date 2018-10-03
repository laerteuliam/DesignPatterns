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

            Assert.Equal(db, db2);
        }
    }
}
