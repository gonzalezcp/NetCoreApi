using BusinessEntities;
using DataModel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FiscaWebApiRestService.Controllers
{
    public class PersonaController : ApiController
    {
        private readonly IService _service;
        public PersonaController(IService service)
        {
            _service = service;//_service = new EntityFrameworkService<DataModel.fiscaliaEntities>(new DataModel.fiscaliaEntities());
        }

        // GET: api/Persona
        public HttpResponseMessage Get()
        {
            var personas = _service.GetPersonaApellido("Negro");
            if (personas != null)
            {
                var personasModel = personas as List<PersonaModel> ?? personas.ToList();
                if (personasModel.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, personasModel);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
        }

        // GET: api/Persona/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Persona
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Persona/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Persona/5
        public void Delete(int id)
        {
        }
    }
}
