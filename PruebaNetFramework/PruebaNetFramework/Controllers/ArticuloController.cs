using PruebaNetFramework.EntityModels;
using PruebaNetFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PruebaNetFramework.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ArticuloController : ApiController
    {

        private Data.InventarioDbContext _inventarioContext = new Data.InventarioDbContext();

        [HttpGet]
        // GET api/<controller>
        public async Task<IHttpActionResult> GetAll()
       {
            List<Articulo> personaEntity = await _inventarioContext.Articulo.ToListAsync();
            List<ArticuloViewModel> personaViewModels = personaEntity.ConvertAll(x => new ArticuloViewModel(x));
            return Ok(personaViewModels); 
        }

        // GET api/<controller>/5
        public async Task<IHttpActionResult> GetById(int? id)
        {
            try
            {
                if (id == null)
                {
                    return Content(HttpStatusCode.BadRequest, "Identificador de articulo nulo.");
                }

                List<Articulo> articuloEntity = await _inventarioContext.Articulo.Where(x => x.Sku_ID.Equals(id)).ToListAsync();
                if (articuloEntity == null || articuloEntity.Count() == 0)
                {
                    return Content(HttpStatusCode.NotFound, "No se encontro el articulo.");
                }
                List<ArticuloViewModel> articuloViewList = articuloEntity.ConvertAll(x => new ArticuloViewModel(x));
                ArticuloViewModel articuloView = articuloViewList.FirstOrDefault();
                return Content(HttpStatusCode.OK, articuloView);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post(ArticuloViewModel model)
        {
            Articulo ArticuloEntity = new Articulo();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Content(HttpStatusCode.BadRequest, "Modelo no válido.");
                }

                ArticuloEntity.Sku_NumeroSerie = model.Sku_NumeroSerie;
                ArticuloEntity.Sku_Descripcion = model.Sku_Descripcion;
                ArticuloEntity.Sku_Cantidad = model.Sku_Cantidad;
                ArticuloEntity.Sku_Cat_ID = model.Sku_Cat_ID;
                ArticuloEntity.Sku_Sub_Cat_ID = model.Sku_Sub_Cat_ID;
                ArticuloEntity.Sku_Latitud = model.Sku_Latitud;
                ArticuloEntity.Sku_Longitud = model.Sku_Longitud;
                _inventarioContext.Articulo.Add(ArticuloEntity);
                await _inventarioContext.SaveChangesAsync();
                return Content(HttpStatusCode.Created, ArticuloEntity);
            }
            catch (ApplicationException ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
            finally
            {
                ArticuloEntity = null;
                model = null;
            }
        }

        // PUT api/<controller>/5
        public async Task<IHttpActionResult> Update(ArticuloViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Content(HttpStatusCode.BadRequest, "Modelo no válido.");
                }
                Articulo articuloEntity = await _inventarioContext.Articulo.FindAsync(model.Sku_ID);
                if (articuloEntity == null)
                {
                    return Content(HttpStatusCode.NotFound, "Articulo no encontrado.");
                }
                articuloEntity.Sku_ID = model.Sku_ID;
                articuloEntity.Sku_NumeroSerie = model.Sku_NumeroSerie;
                articuloEntity.Sku_Descripcion = model.Sku_Descripcion;
                articuloEntity.Sku_Cantidad = model.Sku_Cantidad;
                articuloEntity.Sku_Cat_ID = model.Sku_Cat_ID;
                articuloEntity.Sku_Sub_Cat_ID = model.Sku_Sub_Cat_ID;
                articuloEntity.Sku_Latitud = model.Sku_Latitud;
                articuloEntity.Sku_Longitud = model.Sku_Longitud;
                await _inventarioContext.SaveChangesAsync();
                return Content(HttpStatusCode.OK, articuloEntity);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        // DELETE api/<controller>/5
        public async Task<IHttpActionResult> delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return Content(HttpStatusCode.BadRequest, "El identificador es nulo.");
                }
                Articulo articuloEntity = await _inventarioContext.Articulo.FindAsync(id);
                if (articuloEntity == null)
                {
                    return Content(HttpStatusCode.NotFound, "Articulo no encontrado.");

                }
                _inventarioContext.Articulo.Remove(articuloEntity);
                await _inventarioContext.SaveChangesAsync();
                return Content(HttpStatusCode.OK, "Elimado correctamente.");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}