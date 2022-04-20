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

    public class BloodGlucoseController : BaseController
    {
        public BloodGlucoseController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        //[HttpPost("AddBloodGlucose")]
        //[ProducesResponseType(typeof(ResponseData<ParamAddBloodGlucose>), 200)]
        //public IActionResult Register([FromBody] ParamAddBloodGlucose create_param)
        //{

        //    int total = 0;

        //    if (create_param == null)
        //    {
        //        HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.BadRequest, StatusMessage.Fail, HttpResponseMessageKey.DataUnsuccessfullyCreated, total);
        //        goto response;
        //    }

        //    try
        //    {
        //        var result = IUnitOfWorks.UnifOfWork_ms_BloodGlucose().AddData_BloodGlucose(create_param);
        //        if (result != null)
        //        {
        //            HttpResults = new ResponseData<ParamAddBloodGlucose>("Data successfully created", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, create_param);
        //        }
        //        else
        //        {
        //            HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.BadRequest, StatusMessage.Fail, HttpResponseMessageKey.DataUnsuccessfullyCreated, total);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        int exCode = ex.HResult;

        //        if (exCode == -2147467259)
        //        {
        //            HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, ex.Message, total);
        //        }
        //        else
        //        {
        //            HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, ex.Message, total);
        //        }
        //    }

        //response:
        //    return HttpResponse(HttpResults);

        //}

        [HttpGet("GetAllBloodGlucose")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<BloodGlucoseItem>>), 200)]
        public IActionResult GetAllBloodGlucose()
        {
            int total = 0;

            try
            {
                var result = IUnitOfWorks.UnifOfWork_ms_BloodGlucose().GetAll_BloodGlucose();
                total = result.Count();

                if (total != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<BloodGlucoseItem>>("Get All Data Blood Glucose", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, result);

                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.OK, StatusMessage.Fail, "blood glucose data not available", total);
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

        [HttpGet("GetBloodGlucose/{patientId}")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<BloodGlucoseItem>>), 200)]
        public IActionResult GetBloodGlucoseByPatient(int patientId)
        {
            int total = 0;

            try
            {
                var result = IUnitOfWorks.UnifOfWork_ms_BloodGlucose().GetData_BloodGlucose_ByPatient(patientId);
                total = result.Count();

                if (total != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<BloodGlucoseItem>>("Get All Data Blood Glucose", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, result);

                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.OK, StatusMessage.Fail, "blood glucose data not available", total);
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

        [HttpGet("FilterBloodGlucose")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<BloodGlucoseItem>>), 200)]
        public IActionResult FilterBloodGlucose([FromQuery]ParamFilterBloodGlucose filter_param)
        {
            int total = 0;

            try
            {
                var result = IUnitOfWorks.UnifOfWork_ms_BloodGlucose().Filter_BloodGlucose(filter_param);
                total = result.Count();

                if (total != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<BloodGlucoseItem>>("Get All Data Blood Glucose", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, result);

                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.OK, StatusMessage.Fail, "blood glucose data not available", total);
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

        //[HttpGet("FilterBloodGlucoseBydate")]
        //[ProducesResponseType(typeof(ResponseData<IEnumerable<BloodGlucoseItem>>), 200)]
        //public IActionResult FilterBloodGlucose_ByDate(ParamFilterDateRange param_date, int patient_id)
        //{
        //    int total = 0;

        //    try
        //    {
        //        var result = IUnitOfWorks.UnifOfWork_ms_BloodGlucose().Filter_BloodGlucose_ByDate(param_date, patient_id);
        //        total = result.Count();
        //        if (total != 0)
        //        {
        //            HttpResults = new ResponseData<IEnumerable<BloodGlucoseItem>>("Get Data Blood Glucose by range date", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, result);

        //        }
        //        else
        //        {
        //            HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.OK, StatusMessage.Fail, "blood glucose data not available", total);
        //        }
        //    }
        //    catch (Exception exx)
        //    {
        //        int exCode = exx.HResult;

        //        if (exCode == -2147467259)
        //        {
        //            HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, exx.Message, total);
        //        }
        //        else
        //        {
        //            HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, exx.Message, total);
        //        }
        //    }

        //    return HttpResponse(HttpResults);
        //}

        [HttpGet("FilterChartAvgBG")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<ChartCoordinate>>), 200)]
        public IActionResult FilterChart_AvgBloodGlucose(ParamFilterDateRange param_date, int patient_id)
        {
            int total = 0;

            try
            {
                var result = IUnitOfWorks.UnifOfWork_ms_BloodGlucose().Filter_ChartAverageBG(param_date, patient_id);
                total = result.Count();
                if (total != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<ChartCoordinate>>("Get Data Blood Glucose by range date", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, result);

                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.OK, StatusMessage.Fail, "blood glucose data not available", total);
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
