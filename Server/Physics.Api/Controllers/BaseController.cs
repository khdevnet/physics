using Physics.Api.Application.Service;
using Physics.Api.Application.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Physics.Api.Application;
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
