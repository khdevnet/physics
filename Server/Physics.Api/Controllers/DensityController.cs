
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Physics.Api.Application;
using System.Web.Http.Cors;
using System.Web;
using System.Web.Http.Routing;

using Physics.Api.Models;
using Physics.Api.Filters;

using Physics.Domain.Service;
using Physics.Domain;
using System.Threading.Tasks;

namespace Physics.Api.Controllers
{
    [RoutePrefix("api")]
    public class DensityController : BaseController
    {
        public DensityController(IServices services) : base(services)
        {
        }
        const int maxPageSize = 5;

        [Route("density", Name = "DensityList")]
        [HeaderAllowPaginationFilter()]
        public async Task<IEnumerable<DensityViewModel>> Get(int page = 1, int pageSize = maxPageSize)
        {
            var densities = await Services.Density.GetAllAsync();
            var urlHelper = new UrlHelper(Request);

            var pagination = new Pagination<Density>(densities, page, pageSize, urlHelper.Link, "DensityList");

            HttpContext.Current.Response.Headers.Add("X-Pagination", pagination.ToJson());

            return densities
                     .Skip(pagination.PageSize * (pagination.CurrentPage - 1))
                     .Take(pagination.PageSize).Select(density => density.ToViewModel());
        }
        [Route("density/weight/{weight}/volume/{volume}")]
        public async Task<DensityViewModel> Get(float weight, float volume)
        {
            return await Services.Density.GetByWeightAndVolumeAsync(weight, volume).ToViewModelAync();
        }
        [Route("density/{id}")]
        public async Task<DensityViewModel> Get(string id)
        {
            if (!Services.Density.Exists(id)) throw new HttpResponseException(HttpStatusCode.NotFound);
            return await Services.Density.GetByIdAsync(id).ToViewModelAync();
        }
        [HttpPost]
        [Route("density")]
        public async Task<IHttpActionResult> Post([FromBody]DensityViewModel density)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await Services.Density.SaveAsync(density.ToDomainModel());
            return Ok();
        }
        [HttpPut]
        [Route("density/{id}")]
        public async Task<IHttpActionResult> Put(string id, [FromBody]DensityViewModel density)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await Services.Density.SaveAsync(density.ToDomainModel());
            return Ok();
        }
        [HttpDelete]
        [Route("density/{id}")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            await Services.Density.DeleteAsync(id);
            return Ok();
        }
    }
}
