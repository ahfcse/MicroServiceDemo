using System.Linq.Expressions;
using System.Net;
using Catalog.API.Interface.Manager;
using Catalog.API.Manager;
using Catalog.API.Models;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : BaseController
    {
        IProductManager _ProductManager;
        public CatalogController(IProductManager ProductManager)
        {
            _ProductManager = ProductManager;
                
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ResponseCache(Duration = 30)]
        public IActionResult GetProducts()
        {
            try 
            {
                var products = _ProductManager.GetAll();
                if (products == null)
                {
                    return CustomResult((int)HttpStatusCode.NotFound);
                }
                else
                {
                    return CustomResult(products);
                }
            }
            catch (Exception ex)
            {
                return CustomResult((int)HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public IActionResult GetById(string Id)
        {
            try
            {
                var product = _ProductManager.GetById(Id);
                if (product == null)
                {
                    return CustomResult((int)HttpStatusCode.NotFound);
                }
                else
                {
                    return CustomResult(product);
                }
            }
            catch (Exception ex)
            {
                return CustomResult((int)HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ResponseCache(Duration =10)]
        public IActionResult GetByCategory(string cayrgory)
        {
            try
            {
                var product = _ProductManager.GetByCategory(cayrgory);
                if (product == null)
                {
                    return CustomResult((int)HttpStatusCode.NotFound);
                }
                else
                {
                    return CustomResult(product);
                }
            }
            catch (Exception ex)
            {
                return CustomResult((int)HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        public IActionResult CreateProducts([FromBody] Product product)
        {
            try
            {
                product.Id=ObjectId.GenerateNewId().ToString();
                var IsSaved = _ProductManager.Add(product);
                if (IsSaved)
                {
                    return CustomResult("Product Has been Saved Successfully",product);
                }
                else
                {
                    return CustomResult("Product Saved Failed",(int)HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return CustomResult((int)HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public IActionResult UpdateProducts([FromBody] Product product)
        {
            try
            {
               
                var IsUpdate = _ProductManager.Update(product.Id,product);
                if (IsUpdate)
                {
                    return CustomResult("Product Has been Updated Successfully", product);
                }
                else
                {
                    return CustomResult("Product Updated Failed", (int)HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return CustomResult((int)HttpStatusCode.BadRequest);
            }
        }
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult DeleteProducts(string id)
        {
            try
            {

                var IsDeleted = _ProductManager.Delete(id);
                if (IsDeleted)
                {
                    return CustomResult("Product Has been Deleted Successfully");
                }
                else
                {
                    return CustomResult("Product Deleted Failed", (int)HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return CustomResult((int)HttpStatusCode.BadRequest);
            }
        }
    }
}
