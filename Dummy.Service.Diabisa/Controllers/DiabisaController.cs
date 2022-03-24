using Dummy.Service.Diabisa.Common;
using Dummy.Service.Diabisa.Models;
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
