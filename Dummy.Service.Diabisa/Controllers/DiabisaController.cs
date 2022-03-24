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

    public class DiabisaController : BaseController
    {
        public DiabisaController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [HttpPost("CreateDiabisa")]
        [ProducesResponseType(typeof(ResponseData<ParamCreateDiabisa>), 200)]
        public IActionResult Register([FromBody] ParamCreateDiabisa create_param)
        {

            int total = 0;

            if (create_param == null)
            {
                HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.BadRequest, StatusMessage.Fail, HttpResponseMessageKey.DataUnsuccessfullyCreated, total);
                goto response;
            }

            try
            {
                var result = IUnitOfWorks.UnifOfWork_ms_diabisa().CreateDiabisa(create_param);
                if (result != null)
                {
                    HttpResults = new ResponseData<ParamCreateDiabisa>("Data successfully created", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, create_param);
                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.BadRequest, StatusMessage.Fail, HttpResponseMessageKey.DataUnsuccessfullyCreated, total);

                }
            }
            catch (Exception ex)
            {
                int exCode = ex.HResult;

                if (exCode == -2147467259)
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, ex.Message, total);
                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, ex.Message, total);
                }
            }

        response:
            return HttpResponse(HttpResults);

        }


        [HttpGet("GetAllDiabisa")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<DiabisaItem>>), 200)]
        public IActionResult GetAllDiabisa()
        {
            int total = 0;

            try
            {
                var result = IUnitOfWorks.UnifOfWork_ms_diabisa().GetAll_diabisa();
                total = result.Count();

                if (total != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<DiabisaItem>>("Get All Data Diabisa", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, result);

                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.OK, StatusMessage.Fail, "no user data available", total);
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
