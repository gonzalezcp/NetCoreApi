using AutoMapper;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Service
{
    class EntityFrameworkService<TContext> : IService where TContext : DbContext
    {

        protected readonly TContext context;
        //protected DbSet<TContext> DbSet;
        public EntityFrameworkService(TContext context)
        {
            this.context = context;
        }
        public IEnumerable<colaDistribucion> GetCola()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessEntities.PersonaModel> GetPersonaApellido(String apellido)
        {
            var EFPersonas = context.Set<persona>();
            var personasConApellidoX = (from a in EFPersonas
                                        where a.apellido == apellido
                                            select a).ToList();

            if (personasConApellidoX.Any())
            {
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<IEnumerable<persona>, IEnumerable<BusinessEntities.PersonaModel>>();
                });

                var personasConApellidoXModel = Mapper.Map<IEnumerable<persona>, IEnumerable<BusinessEntities.PersonaModel>>(personasConApellidoX);
                return personasConApellidoXModel;
            }
            return null;
        }

        //public int CreatePersonas(BusinessEntities.ProductEntity productEntity)
        //{
        //    using (var scope = new TransactionScope())
        //    {
        //        var product = new Product
        //        {
        //            ProductName = productEntity.ProductName
        //        };
        //        _unitOfWork.ProductRepository.Insert(product);
        //        _unitOfWork.Save();
        //        scope.Complete();
        //        return product.ProductId;
        //    }
        //}





        public IEnumerable<BusinessEntities.ColaDistribucionModel>  GetColaByIdTipoDistribucion(int idTipoDistribucion)
        {
            var EFColaDistribucion = context.Set<colaDistribucion>();
            var colaDeUnTipoDistribucion = (from a in EFColaDistribucion
                                            where a.idTipoDistribucion == idTipoDistribucion &&
                                                a.fechaBorrado!= null
                                            select a).ToList();

            if (colaDeUnTipoDistribucion.Any())
            {
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<IEnumerable<colaDistribucion>, IEnumerable<BusinessEntities.ColaDistribucionModel>>();
                });

                var colasDistribucionModel = Mapper.Map<IEnumerable<colaDistribucion>, IEnumerable<BusinessEntities.ColaDistribucionModel>>(colaDeUnTipoDistribucion);
                return colasDistribucionModel;
            }
            return null;
        }

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null) where TEntity : class
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }



        ///// <summary>
        ///// Fetches all the products.
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<BusinessEntities.ProductEntity> GetAllProducts()
        //{
        //    var products = _unitOfWork.ProductRepository.GetAll().ToList();
        //    if (products.Any())
        //    {
        //        Mapper.CreateMap<Product, ProductEntity>();
        //        var productsModel = Mapper.Map<List<Product>, List<ProductEntity>>(products);
        //        return productsModel;
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// Creates a product
        ///// </summary>
        ///// <param name="productEntity"></param>
        ///// <returns></returns>
        //public int CreateProduct(BusinessEntities.ProductEntity productEntity)
        //{
        //    using (var scope = new TransactionScope())
        //    {
        //        var product = new Product
        //        {
        //            ProductName = productEntity.ProductName
        //        };
        //        _unitOfWork.ProductRepository.Insert(product);
        //        _unitOfWork.Save();
        //        scope.Complete();
        //        return product.ProductId;
        //    }
        //}

        ///// <summary>
        ///// Updates a product
        ///// </summary>
        ///// <param name="productId"></param>
        ///// <param name="productEntity"></param>
        ///// <returns></returns>
        //public bool UpdateProduct(int productId, BusinessEntities.ProductEntity productEntity)
        //{
        //    var success = false;
        //    if (productEntity != null)
        //    {
        //        using (var scope = new TransactionScope())
        //        {
        //            var product = _unitOfWork.ProductRepository.GetByID(productId);
        //            if (product != null)
        //            {
        //                product.ProductName = productEntity.ProductName;
        //                _unitOfWork.ProductRepository.Update(product);
        //                _unitOfWork.Save();
        //                scope.Complete();
        //                success = true;
        //            }
        //        }
        //    }
        //    return success;
        //}

        ///// <summary>
        ///// Deletes a particular product
        ///// </summary>
        ///// <param name="productId"></param>
        ///// <returns></returns>
        //public bool DeleteApoderadoFromCola(int productId)
        //{
        //    var success = false;
        //    if (productId > 0)
        //    {
        //        using (var scope = new TransactionScope())
        //        {
        //            var product = _unitOfWork.ProductRepository.GetByID(productId);
        //            if (product != null)
        //            {

        //                _unitOfWork.ProductRepository.Delete(product);
        //                _unitOfWork.Save();
        //                scope.Complete();
        //                success = true;
        //            }
        //        }
        //    }
        //    return success;
        //}
    }
}
