using Microsoft.AspNetCore.Mvc;
using ReactLearningWebApi;
using Xunit;
using FakeItEasy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ReactLearningWebApi.Repositories;
using ReactLearningWebApi.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace ReactLearningWebApi.Tests
{
    public class ProjectTests
    {
        private readonly DIInstaller installer;

        private readonly ProjectController projectController;

        public ProjectTests()
        {
            installer = new DIInstaller();
            var DICservices = installer.Services();
            installer.DoubleDatabase(DICservices);

            projectController = DICservices.BuildServiceProvider().GetRequiredService<ProjectController>();
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
            var r = installer.dbContext.Set<Project>().Single();
            Assert.Equal("UT project name", r.Name);
            Assert.Equal("UT project description", r.Description);
        }

    }
}