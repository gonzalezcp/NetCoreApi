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
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var personas = _service.GetPersonaApellido("Del Coco");
            if (personas != null)
            {

                var personasModel = personas as List<PersonaModel> ?? personas.ToList();
                if (personasModel.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, personasModel);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
        }

        // GET: api/Persona/5
        public string GetById(int id)
        {
            //var personas = _service.get("Del Coco");
            return "value";
        }

        // POST: api/Persona
        public int Post([FromBody]PersonaModel personaModel)
        {
            return _service.CreatePersonas(personaModel);
        }

        // PUT: api/Persona/5
        public bool Put(int id, [FromBody]PersonaModel personaModel)
        {
            if (id > 0)
            {
                return _service.UpdatePersona(id, personaModel);
            }
            return false;
        }

        // DELETE: api/Persona/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _service.DeletePersonaById(id);
            return false;
        }
    }
}
