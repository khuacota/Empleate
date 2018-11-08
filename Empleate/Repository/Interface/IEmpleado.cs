using Empleate.Models;
using System;

namespace Empleate.Repository.Interface
{
    interface IEmpleado : IEmpleate<Empleado>, IDisposable
    {
        int CompleteTransaction();
    }
}
