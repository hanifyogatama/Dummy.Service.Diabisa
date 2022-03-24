using Dummy.Service.Diabisa.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Common
{
    public interface IUnitOfWork : IDisposable
    {
        DiabisaRepository UnifOfWork_ms_diabisa();
    }
}
