using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;

namespace Physics.Api.Models
{
    public class Pagination<TEntity>
    {
        Func<string, object, string> _linkBuilder;
        string _routeName;
        public Pagination(List<TEntity> entities, int currentPage, int pageSize, Func<string, object, string> _linkBuilder, string routeName)
        {
            this.CurrentPage = currentPage;
            this.PageSize = pageSize;
            this.TotalCount = entities.Count();
            this._linkBuilder = _linkBuilder;
            this._routeName = routeName;




        }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((float)this.TotalCount / this.PageSize);
            }
        }
        public string PreviousPageLink { get { return getPreviousLink(); } }

        string getPreviousLink()
        {
            return this.CurrentPage > 1 ? _linkBuilder(this._routeName,
             new
             {
                 page = this.CurrentPage - 1,
                 pageSize = this.PageSize
             }) : "";
        }

        public string NextPageLink { get { return getNextLink(); } }

        string getNextLink()
        {
            return this.CurrentPage < this.TotalPages ? _linkBuilder(this._routeName,
                new
                {
                    page = this.CurrentPage + 1,
                    pageSize = this.PageSize
                }) : "";
        }
    }

    public static class PaginationExtensions
    {

        public static string ToJson<TEntity>(this Pagination<TEntity> pagination)
        {
            var settings = new JsonSerializerSettings()
            {
                StringEscapeHandling = StringEscapeHandling.EscapeHtml,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.SerializeObject(pagination, settings: settings);
        }
    }

}