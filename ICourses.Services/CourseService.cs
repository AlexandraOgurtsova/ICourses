using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ICourses.Interfaces;
using ICourses.Services.Interfaces;
using ICourses.Entities;
using ICourses.ViewModels;

namespace ICourses.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourse _coursesRepository;
        private readonly ISubjectService _subjectService;
        public CourseService(ICourse coursesRepository, ISubjectService subjectService)
        {
            _subjectService = subjectService;
            _coursesRepository = coursesRepository;
        }

        public async Task<Course> AddCourse(Guid id, CreateCourseViewModel course, string userId)
        {
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(course.Image.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)course.Image.Length);
            }

            Subject subject = await _subjectService.GetSubject(id);

            Course new_course = new Course()
            {
                Id = Guid.NewGuid(),
                Modified = DateTime.Now,
                Name = course.Name,
                Description = course.Description,
                Language = course.Language,
                Image = imageData,
                SubjectId = subject.Id,
                AuthorId = userId,
            };

            await _coursesRepository.AddCourse(new_course);
            return new_course;
        }

        public async Task DeleteCourse(Course course)
        {
            await _coursesRepository.DeleteCourse(course);
        }


        public async Task<Course> GetCourse(Guid id)
        {
            var course = await _coursesRepository.GetCourse(id);
            return course;
        }    

        public async Task UpdateCourse(Course course)
        {
            await _coursesRepository.UpdateCourse(course);
        }
        
        //-
        public async Task<IEnumerable<Course>> GetFavoriteCourses(Guid id)
        {
            return await _coursesRepository.GetFavoriteCourses(id);
        }

        public async Task<IEnumerable<Course>> GetUserCourses(string id)
        {
            return await _coursesRepository.GetUserCourses(id);
        }

        public async Task<IEnumerable<Course>> FindCoursesByName(string name)
        {
            return await _coursesRepository.FindCoursesByName(name);
        }


        public async Task<IEnumerable<Comment>> GetComments(Course course)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Like>> GetLikes(Guid postId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveLike(Guid postId, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Course> EditCourse(Guid id, EditCourseViewModel course)
        {
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(course.Image.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)course.Image.Length);
            }

            Course new_course = await _coursesRepository.GetCourse(id);

            if (new_course != null)
            {
                new_course.Name = course.Name;
                new_course.Description = course.Description;
                new_course.Image = imageData;

                await _coursesRepository.UpdateCourse(new_course);
            }
            return new_course;
        }
    }
}
