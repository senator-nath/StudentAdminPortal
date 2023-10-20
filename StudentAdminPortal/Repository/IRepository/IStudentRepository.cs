﻿using StudentAdminPortal.Model;

namespace StudentAdminPortal.Repository.IRepository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentById(Guid studentId);
        Task<bool> StudentExist(Guid studentId);
        Task<Student> UpdateStudent(Guid studentId, Student request);
    }
}