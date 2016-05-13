using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Physics.Domain.Service;
namespace Physics.Api.Controllers
{
    public class BaseController : ApiController
    {
        protected IServices Services;
        public BaseController(IServices services)
        {
            Services = services;
        }

    }
}
