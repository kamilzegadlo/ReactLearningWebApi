using Microsoft.AspNetCore.Mvc;
using ReactLearningWebApi;
using Xunit;
using FakeItEasy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ReactLearningWebApi.Repositories;
using ReactLearningWebApi.Domain;

namespace ReactLearningWebApi.Tests
{
    public class ProjectTests
    {
        private readonly DbAppRepositoryContext dbContext;
        private readonly IDBContextFactory contextFactory;

        private readonly ProjectController projectController;

        public ProjectTests()
        {
            var options = new DbContextOptionsBuilder<DbAppRepositoryContext>()
                 .UseInMemoryDatabase("InMemoryDb")
                 .Options;
            dbContext = new DbAppRepositoryContext(options);

            contextFactory=A.Fake<IDBContextFactory>();
            A.CallTo(() => contextFactory.Get()).Returns(dbContext);

            var r = new ProjectRepository(contextFactory);
            var s = new ProjectService(r);

            projectController = new ProjectController(s);
        }

        [Fact]
        public async Task AddingProject_ReturnsOK()
        {
            //Arrange
            var dto = new AddProjectDTO { Name = "UT project name", Description = "UT project description" };

            //Act
            var result = await projectController.AddAsync(dto);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task AddingProject_SavesToDB()
        {
            //Arrange
            var dto = new AddProjectDTO { Name = "UT project name", Description = "UT project description" };

            //Act
            var result = await projectController.AddAsync(dto);

            //Assert
            var r = dbContext.Set<Project>().Single();
            Assert.Equal("UT project name", r.Name);
            Assert.Equal("UT project description", r.Description);
        }

    }
}