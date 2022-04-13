using Dummy.Service.Diabisa.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        internal DatabaseContext Context;

        private BloodGlucoseRepository BloodGlucose_Repository;
        private BloodPressureRepository BloodPressure_Repository;

        public UnitOfWork(DatabaseContext _Context)
        {
            Context = _Context;
        }

        public BloodGlucoseRepository UnifOfWork_ms_BloodGlucose()
        {
            if (BloodGlucose_Repository == null)
            {
                BloodGlucose_Repository = new BloodGlucoseRepository(Context);
            }

            return BloodGlucose_Repository;
        }

        public BloodPressureRepository UnifOfWork_ms_BloodPressure()
        {
            if (BloodPressure_Repository == null)
            {
                BloodPressure_Repository = new BloodPressureRepository(Context);
            }

            return BloodPressure_Repository;
        }

        public bool Disposing;
        private void DisposingProperties()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        protected virtual void Disposed(bool _disposing)
        {
            if (!Disposing)
            {
                if (_disposing)
                {
                    DisposingProperties();
                }
            }
        }

        public void Dispose()
        {
            Disposed(true);
            GC.SuppressFinalize(this);
        }

       
    }
}
