using Empleate.Models;
using System;

namespace Empleate.Repository.Interface
{
    interface IEmpleado : IEmpleate<Employee>, IDisposable
    {
        int CompleteTransaction();
    }
}
