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
                cfg.CreateMap<persona, BusinessEntities.PersonaModel>();
                cfg.CreateMap<BusinessEntities.PersonaModel, persona>();
            });

        }
        public IEnumerable<colaDistribucion> GetCola()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessEntities.PersonaModel> GetPersonaApellido(String apellido)
        {
            var EFPersonas = context.Set<persona>();
            var personasConApellidoEF = (from p in EFPersonas
                                        where p.apellido == apellido
                                            select p).ToList();
            
            if (personasConApellidoEF.Any())
            {
                var personasConApellidoModel = Mapper.Map<List<persona>, List<BusinessEntities.PersonaModel>>(personasConApellidoEF);
                return personasConApellidoModel;
            }
            return null;
        }


        public bool UpdatePersona(int idPersona, BusinessEntities.PersonaModel personaModel)
        {
            var success = false;
            var EFPersonas = context.Set<persona>();
            if (personaModel != null)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var EFPersona = EFPersonas.Where(p => p.id == idPersona).FirstOrDefault<persona>();
                    if (EFPersona != null)
                    {

                        Mapper.Map<BusinessEntities.PersonaModel, persona>(personaModel, EFPersona);
                        context.SaveChanges();
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
                    var EFPersonas = context.Set<persona>();
                    var EFPersonaToDelte = EFPersonas.SingleOrDefault(p => p.id == idPersona);
                    if (EFPersonaToDelte != null)
                    {
                        if (context.Entry(EFPersonaToDelte).State == EntityState.Detached)
                        {
                            EFPersonas.Attach(EFPersonaToDelte);
                        }
                        EFPersonas.Remove(EFPersonaToDelte);
                        context.SaveChanges();
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
                var persona = Mapper.Map<BusinessEntities.PersonaModel, persona>(personaModel);
                var EFPersonas = context.Set<persona>();
                try
                {
                    EFPersonas.Add(persona);
                    context.SaveChanges();
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
