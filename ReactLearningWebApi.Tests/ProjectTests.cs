using Microsoft.AspNetCore.Mvc;
using ReactLearningWebApi;
using Xunit;

namespace ReactLearningWebApi.Tests
{
    public class ProjectTests
    {
        private readonly ProjectController projectController;

        public ProjectTests()
        {
            projectController = new ProjectController();
        }


        [Fact]
        public void AddingProject_ReturnsOK()
        {
            //Arrange
            var dto = new AddProjectDTO { Name = "UT project name", Description = "UT project description" };

            //Act
            var result=projectController.Add(dto);

            //Assert
            Assert.IsType<OkResult>(result);
            var r = (OkResult)result;


        }
    }
}