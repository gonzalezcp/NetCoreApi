using BusinessEntities;
using DataModel.Service;
using FiscaWebApiRestService.Results;
using Newtonsoft.Json.Linq;
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
        //public HttpResponseMessage Get()
        public IHttpActionResult Get()
        {
            var personas = _service.GetPersonaApellido(null);
            if (personas != null)
            {

                var personasModel = personas as List<PersonaModel> ?? personas.ToList();
                if (personasModel.Any())
                    //return Request.CreateResponse(HttpStatusCode.OK, personasModel);
                    return Ok(new ResponseApi<List<PersonaModel>>(true, "Lista de Personas", personasModel));
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
            return Ok(new ResponseApi<List<PersonaModel>>(false));
        }

        // GET: api/Persona/5
        public string GetById(int id)
        {
            //var personas = _service.get("Del Coco");
            return "value";
        }

        // POST: api/Persona
        public IHttpActionResult Post([FromBody]PersonaModel personaModel)
        {
            int idPersona;
            JObject respose;
            try
            {
                idPersona = _service.CreatePersonas(personaModel);
            }
            catch (InvalidOperationException ex)
            {
                respose = JObject.Parse("{\"Mensaje Error:\"" + ex.Message + "}");
                return Ok(new ResponseApi<JObject>(true, "Ocurrio un error", respose));
            }
            respose = JObject.Parse("{\"idPersona\":" + idPersona.ToString() + "}");
            return Ok(new ResponseApi<JObject>(true, "persona insertada correctamente", respose));

        }

        // PUT: api/Persona/5
        public IHttpActionResult Put(int id, [FromBody]PersonaModel personaModel)
        {
            var wasInserted = false;
            try {
                wasInserted = _service.UpdatePersona(id, personaModel);
            }
            catch(InvalidOperationException ex)
            {
                var respose = JObject.Parse("{\"Mensaje Error:\"" + ex.Message + "}");
                return Ok(new ResponseApi<JObject>(true, "Ocurrio un error", respose));
            }
            if (wasInserted)
            {
                return Ok(new ResponseApi<Object>(true, "Se inserto una persona correctamente"));
            }
            return Ok(new ResponseApi<Object>(true, "No se puedo insertar una persona"));
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
