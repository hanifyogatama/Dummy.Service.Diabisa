using Dummy.Service.Diabisa.Common;
using Dummy.Service.Diabisa.Models;
using Dummy.Service.Diabisa.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siloam.System.Data;
using Siloam.System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Controllers
{

    public class BloodPressureController : BaseController
    {
        public BloodPressureController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [HttpGet("GetAllBloodPressure")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<BloodPressureItem>>), 200)]
        public IActionResult GetAllBloodPressure()
        {
            int total = 0;

            try
            {
                var result = IUnitOfWorks.UnifOfWork_ms_BloodPressure().GetAll_BloodPressure();
                total = result.Count();

                if (total != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<BloodPressureItem>>("Get All Data Blood Pressure", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, result);

                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.OK, StatusMessage.Fail, "blood pressure data not available", total);
                }
            }
            catch (Exception exx)
            {
                int exCode = exx.HResult;

                if (exCode == -2147467259)
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, exx.Message, total);
                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, exx.Message, total);
                }
            }

            return HttpResponse(HttpResults);
        }

        [HttpGet("FilterBloodPressureBydate")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<BloodPressureItem>>), 200)]
        public IActionResult GetFilterBloodGlucose_ByDate([FromQuery]ParamFilterDateRange param_date)
        {
            int total = 0;

            try
            {
                var result = IUnitOfWorks.UnifOfWork_ms_BloodPressure().Filter_BloodPressure_ByDate(param_date);
                total = result.Count();
                if (total != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<BloodPressureItem>>("Get Data Blood Pressure by range date", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, result);

                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.OK, StatusMessage.Fail, "blood pressure data not available", total);
                }
            }
            catch (Exception exx)
            {
                int exCode = exx.HResult;

                if (exCode == -2147467259)
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, exx.Message, total);
                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, exx.Message, total);
                }
            }

            return HttpResponse(HttpResults);
        }
    }
}
