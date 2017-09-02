using System.Web.Http;

namespace EP.CursoMvc.Services.ClienteAPI.Controllers
{
    public class ApiBase : ApiController
    {
        public IHttpActionResult Response(object obj)
        {
            if (ModelState.IsValid)
            {
                return Ok(new
                {
                    success = true,
                    obj = obj
                });
            }

            return BadRequest();
        }
    }
}