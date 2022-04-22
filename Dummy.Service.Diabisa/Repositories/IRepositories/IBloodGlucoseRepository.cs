using Dummy.Service.Diabisa.Models;
using Dummy.Service.Diabisa.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Repositories.IRepositories
{
    interface IBloodGlucoseRepository
    {
        ParamAddBloodGlucose AddData_BloodGlucose(ParamAddBloodGlucose create_param);
        IEnumerable<BloodGlucoseItem> GetAll_BloodGlucose();
        IEnumerable<BloodGlucoseItem> GetData_BloodGlucose_ByPatient(int patient_id);
        IEnumerable<BloodGlucoseItem> Filter_BloodGlucose_ByDate(ParamFilterDateRange param_date, int patient_id);
        IEnumerable<BloodGlucoseItem> Filter_BloodGlucose(ParamFilterBloodGlucose filter_param);
        IEnumerable<ChartCoordinate> Filter_ChartBloodGlucose(ParamFilterChart filter_param);

    }
}
