using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Linq;
using ICourses.Entities;
using Moq;
using Bogus;
using NUnit.Framework;

using Microsoft.AspNet.Identity;
using AutoMapper;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xunit;
using ICourses.Controllers;
using Microsoft.AspNetCore.Mvc;
using ICourses.Services.Interfaces;

namespace ICourses.Tests
{
    public class SubjectControllerTest : Controller
    {

        ISubjectService subjectService;

        [Fact]
            public void getAllContent()
            {
                var controller = new SubjectsController(subjectService);
                var result = Ok(controller.Index());
                Xunit.Assert.Equal(200, result.StatusCode);
            }


        //private List<Subject> GetTestSubjects()
        //{
        //    var subjects = new List<Subject>
        //    {
        //        new Subject(){ Id=Guid.NewGuid(),Name = "1", Description = "1.1"},
        //        new Subject(){ Id=Guid.NewGuid(),Name = "2", Description = "2.2"},
        //        new Subject(){ Id=Guid.NewGuid(), Name = "3", Description = "3.3"}
        //    };
        //    return subjects;
        //}

        //[Fact]
        //public async Task IndexReturnsAViewResultWithAListOfUsersAsync()
        //{
        //    var result = await subjectService.GetAllSubject() as List<Subject>;
        //    // Arrange
        //    var mock = new Mock<CourseDbContext>();
        //    mock.Setup(_subjectService => _subjectService.GetAllSubject()).Returns(GetTestSubjects());
        //    var controller = new SubjectsController(result);

        //    // Act
        //    var result = controller.Index();

        //    // Assert
        //    var viewResult = Xunit.Assert.IsType<ViewResult>(result);
        //    var model = Xunit.Assert.IsAssignableFrom<IEnumerable<User>>(viewResult.Model);
        //    Xunit.Assert.Equal(GetTestSubjects().Count, model.Count());
        //}

    }
}
