using CleanArchitecture.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.DataAccess.Interfaces
{
    interface IDepartmentRepository : IDisposable
    {
        IEnumerable<Department> GetAll();
    }
}