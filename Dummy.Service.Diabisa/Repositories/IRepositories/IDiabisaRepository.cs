using Dummy.Service.Diabisa.Models;
using Dummy.Service.Diabisa.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Repositories.IRepositories
{
    interface IDiabisaRepository
    {
        ParamCreateDiabisa CreateDiabisa(ParamCreateDiabisa create_param);
        IEnumerable<DiabisaItem> GetAll_diabisa();
    }
}
