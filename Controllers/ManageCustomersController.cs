using SwiftPayCore.Implementation;
using SwiftPayCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwiftPayCore.Controllers
{
    public class ManageCustomersController : ApiController
    {
        [Route("api/SwiftPayCore/GetCustomers")]
        public IHttpActionResult GetCustomers()
        {
            List<zib_mobil_custom_custs> customers = new List<zib_mobil_custom_custs>();
            customers = CustomerImplementation.GetCustomers();

            if (customers.Count == 0)
            {
                return NotFound();
            }

            return Ok(customers);
            

        }
    }
}
