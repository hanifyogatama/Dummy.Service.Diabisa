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

        private DiabisaRepository Diabisa_Repository;

        public UnitOfWork(DatabaseContext _Context)
        {
            Context = _Context;
        }

        public DiabisaRepository UnifOfWork_ms_diabisa()
        {
            if (Diabisa_Repository == null)
            {
                Diabisa_Repository = new DiabisaRepository(Context);
            }

            return Diabisa_Repository;
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
