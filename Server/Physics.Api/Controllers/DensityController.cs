using Physics.Api.Application.Service;
using Physics.Api.Application.Service.Entity;
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

namespace Physics.Api.Controllers
{
    [RoutePrefix("api")]
    public class DensityController : BaseController
    {
        public DensityController(IServices services) : base(services)
        {
        }
        const int maxPageSize = 5;

        [Route("density", Name = "densityList")]
        [HeaderAllowPaginationFilter()]
        public IEnumerable<Density> Get(int page = 1, int pageSize = maxPageSize)
        {
            var densities = Services.Density.GetAll();
            var urlHelper = new UrlHelper(Request);

            var pagination = new Pagination<Density>(densities, page, pageSize, urlHelper.Link, "densityList");

            HttpContext.Current.Response.Headers.Add("X-Pagination", pagination.ToJson());
            
            return densities
                     .Skip(pagination.PageSize * (pagination.CurrentPage - 1))
                     .Take(pagination.PageSize);
        }
        [Route("density/weight/{weight}/volume/{volume}")]
        public Density Get(decimal weight, decimal volume)
        {
            return Services.Density.GetByWeightAndVolume(weight, volume);
        }
        [Route("density")]
        public Density Get(string id)
        {
            if (!Services.Density.Exists(id)) throw new HttpResponseException(HttpStatusCode.NotFound);
            return Services.Density.GetById(id);
        }
        [HttpPost]
        [Route("density", Name = "addDensity")]
        public void Post([FromBody]Density density)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);
            Services.Density.Save(density);
        }
        [HttpPut]
        public void Put(string id, [FromBody]Density density)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);
            Services.Density.Save(density);
        }
        [Route("density")]
        [HttpDelete]
        public void Delete(string id)
        {
            Services.Density.Delete(id);
        }
    }
}
