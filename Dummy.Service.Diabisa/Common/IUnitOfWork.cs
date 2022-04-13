using Dummy.Service.Diabisa.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Common
{
    public interface IUnitOfWork : IDisposable
    {
        BloodGlucoseRepository UnifOfWork_ms_BloodGlucose();
        BloodPressureRepository UnifOfWork_ms_BloodPressure();
    }
}
