using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NobelApi.Controllers
{
    public class DocumentationsController : ApiController
    {
        //GET api/documentation
        /// <summary>
        /// This is how we create a documentation
        /// </summary>

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
