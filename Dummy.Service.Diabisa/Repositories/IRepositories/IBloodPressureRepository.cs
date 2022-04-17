using Dummy.Service.Diabisa.Models;
using Dummy.Service.Diabisa.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Repositories.IRepositories
{
    interface IBloodPressureRepository
    {
        IEnumerable<BloodPressureItem> GetAll_BloodPressure();
        IEnumerable<BloodPressureItem> GetData_BloodPressure_ByPatient(int patient_id);
        IEnumerable<BloodPressureItem> Filter_BloodPressure_ByDate(ParamFilterDateRange param_date);
        IEnumerable<BloodPressureItem> Filter_BloodPressureFilter(ParamFilterBloodPressure filter_param);
    }
}
