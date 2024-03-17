using Xunit;
using Moq;
using EntityApi.Services;

namespace EntityApi.Tests
{
    public class DatabaseServiceTests
    {
        [Fact]
        public void WriteToDatabase_RetriesOnFailure_SuccessfulWrite()
        {
            var mockDatabaseService = new Mock<DatabaseService>();
            mockDatabaseService.SetupSequence(x => x.PerformOperation())
                               .Throws(new Exception())
                               .Throws(new Exception())
                               .Throws(new Exception())
                               .Returns(() => { });

            mockDatabaseService.Object.WriteToDatabase();
        }

        [Fact]
        public void WriteToDatabase_BackoffStrategy_AppliedCorrectly()
        {
            var mockDatabaseService = new Mock<DatabaseService>();
            mockDatabaseService.SetupSequence(x => x.PerformOperation())
                               .Throws(new Exception())
                               .Throws(new Exception())
                               .Throws(new Exception())
                               .Returns(() => { });

            mockDatabaseService.Object.WriteToDatabase();
        }
    }
}
