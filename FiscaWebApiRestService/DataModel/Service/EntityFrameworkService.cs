using AutoMapper;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Service
{
    public class EntityFrameworkService<TContext> : IService where TContext : DbContext
    {

        protected readonly TContext context;
        public EntityFrameworkService(TContext context)
        {
            this.context = context;
            autoMapperCfg();
        }

        private void autoMapperCfg()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<EFPersona, BusinessEntities.PersonaModel>();
                cfg.CreateMap<BusinessEntities.PersonaModel, EFPersona>();
            });

        }
        public IEnumerable<colaDistribucion> GetCola()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessEntities.PersonaModel> GetPersonaApellido(String apellido = null)
        {
            var EFPersonas = context.Set<EFPersona>();

            List<EFPersona> personasConApellidoEF;
            if (apellido == null)
                personasConApellidoEF = (from p in EFPersonas select p).Take(10).ToList();
            else
                personasConApellidoEF = (from p in EFPersonas where p.apellido == apellido select p).ToList();

            if (personasConApellidoEF.Any())
            {
                var personasConApellidoModel = Mapper.Map<List<EFPersona>, List<BusinessEntities.PersonaModel>>(personasConApellidoEF);
                return personasConApellidoModel;
            }
            return null;
        }


        public bool UpdatePersona(int idPersona, BusinessEntities.PersonaModel personaModel)
        {
            var success = false;
            var EFPersonas = context.Set<EFPersona>();
            if (personaModel != null)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var EFPersona = EFPersonas.Where(p => p.id == idPersona).FirstOrDefault<EFPersona>();
                    if (EFPersona != null)
                    {

                        EFPersona.apellido = personaModel.apellido;
                        EFPersona.nombre = personaModel.nombre;
                        EFPersona.numeroDocumento = personaModel.numeroDocumento;
                        EFPersona.cuit = personaModel.cuit;
                        EFPersona.idTipoPersona = EFPersona.idTipoPersona;
                        EFPersona.idTipoDocumento = personaModel.idTipoDocumento;
                        EFPersona.idTipoSociedad = EFPersona.idTipoSociedad;
                        EFPersona.fechaAlta = personaModel.fechaAlta;
                        //Mapper.Map<BusinessEntities.PersonaModel, EFPersona>(personaModel, EFPersona);
                        try
                        {
                            context.SaveChanges();
                        }
                        catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                        {
                            Exception raise = dbEx;
                            foreach (var validationErrors in dbEx.EntityValidationErrors)
                            {
                                foreach (var validationError in validationErrors.ValidationErrors)
                                {
                                    string message = string.Format("{0}:{1}",
                                        validationErrors.Entry.Entity.ToString(),
                                        validationError.ErrorMessage);
                                    // raise a new exception nesting
                                    // the current instance as InnerException
                                    raise = new InvalidOperationException(message, raise);
                                }
                            }
                            throw raise;
                        }
                        transaction.Commit();
                        success = true;
                    }
                }
            }
            return success;
        }
        public bool DeletePersonaById(int idPersona)
        {
            var success = false;
            if (idPersona > 0)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var EFPersonas = context.Set<EFPersona>();
                    var EFPersonaToDelte = EFPersonas.SingleOrDefault(p => p.id == idPersona);
                    if (EFPersonaToDelte != null)
                    {
                        if (context.Entry(EFPersonaToDelte).State == EntityState.Detached)
                        {
                            EFPersonas.Attach(EFPersonaToDelte);
                        }
                        EFPersonas.Remove(EFPersonaToDelte);
                        try
                        {
                            context.SaveChanges();
                        }
                        catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                        {
                            Exception raise = dbEx;
                            foreach (var validationErrors in dbEx.EntityValidationErrors)
                            {
                                foreach (var validationError in validationErrors.ValidationErrors)
                                {
                                    string message = string.Format("{0}:{1}",
                                        validationErrors.Entry.Entity.ToString(),
                                        validationError.ErrorMessage);
                                    // raise a new exception nesting
                                    // the current instance as InnerException
                                    raise = new InvalidOperationException(message, raise);
                                }
                            }
                            throw raise;
                        }
                        transaction.Commit();
                        success = true;
                    }
                }
            }
            return success;
        }
        public int CreatePersonas(BusinessEntities.PersonaModel personaModel)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                var persona = Mapper.Map<BusinessEntities.PersonaModel, EFPersona>(personaModel);
                var EFPersonas = context.Set<EFPersona>();
                try
                {
                    EFPersonas.Add(persona);
                                            try
                        {
                            context.SaveChanges();
                        }
                        catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                        {
                            Exception raise = dbEx;
                            foreach (var validationErrors in dbEx.EntityValidationErrors)
                            {
                                foreach (var validationError in validationErrors.ValidationErrors)
                                {
                                    string message = string.Format("{0}:{1}",
                                        validationErrors.Entry.Entity.ToString(),
                                        validationError.ErrorMessage);
                                    // raise a new exception nesting
                                    // the current instance as InnerException
                                    raise = new InvalidOperationException(message, raise);
                                }
                            }
                            throw raise;
                        }
                    transaction.Commit();
                    return persona.id;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    
                    transaction.Rollback();
                }
                return 0;
            }
        }


        //protected virtual IQueryable<TEntity> getQueryable<TEntity>(Expression<Func<TEntity, bool>> filter = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    string includeProperties = null,
        //    int? skip = null,
        //    int? take = null) where TEntity : class
        //{
        //    includeProperties = includeProperties ?? string.Empty;
        //    IQueryable<TEntity> query = context.Set<TEntity>();

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    if (orderBy != null)
        //    {
        //        query = orderBy(query);
        //    }

        //    if (skip.HasValue)
        //    {
        //        query = query.Skip(skip.Value);
        //    }

        //    if (take.HasValue)
        //    {
        //        query = query.Take(take.Value);
        //    }

        //    return query;
        //}
    }
}
