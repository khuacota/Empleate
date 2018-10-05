using Empleate.Models;
using System;
using System.Collections.Generic;

namespace Empleate.Repository.Interface
{
    interface IProfesion : IEmpleate<Profesion>, IDisposable
    {
        Profesion FindProfesionByDescription(string description);
        int CompleteTransaction();
    }
}
