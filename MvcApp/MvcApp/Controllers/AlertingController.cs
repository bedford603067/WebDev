using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApp.Controllers
{
    public class AlertingController : ApiController
    {
        // GET: api/Alerting
        public IEnumerable<Models.AlertType> Get()
        {
            DAL.AlertingRepository repository = new DAL.AlertingRepository("mongodb://localhost:27017");

            return repository.GetAlertTypes(); ;
        }

        // GET: api/Alerting/5
        public Models.AlertType Get(int id)
        {
            return null;
        }

        // POST: api/Alerting
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Alerting/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Alerting/5
        public void Delete(int id)
        {
        }
    }
}
