﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Common
{
    public abstract class DatabaseConfig
    {
        protected readonly DatabaseContext Context;
        protected readonly DbContextOptions<DatabaseContext> ContextOptions;

        protected DatabaseConfig() { }

        public DatabaseConfig(DatabaseContext _Context)
        {
            Context = _Context;
            ContextOptions = Context.options;
        }

        private bool Disposed;

        protected virtual void Disposing(bool _Disposing)
        {
            if (!Disposed)
            {
                if (_Disposing)
                {
                    Context?.Dispose();
                }
            }

            Disposed = true;
        }

        public void Dispose()
        {
            Disposing(true);
            GC.SuppressFinalize(this);
        }

    }
}
