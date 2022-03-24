using Dummy.Service.Diabisa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Repositories.IRepositories
{
    interface IDiabisaRepository
    {
        IEnumerable<DiabisaItem> GetAll_diabisa();
    }
}
