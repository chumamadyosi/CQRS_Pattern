using CommandPattern.Commands.Interfaces;
using CommandPattern.Models;
using CommonData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CommandPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductCommand _cmd;
        public ProductController(IProductCommand cmd)
        {
            _cmd = cmd;
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct(ProductCommandModel model)
        {

            try
            {
                var product = await _cmd.InsertProduct(model);
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductCommandModel model)
        {

            try
            {
                var status = await _cmd.UpdateProduct(model);
                if (status == true)
                    return StatusCode(StatusCodes.Status200OK, status);
                return StatusCode(StatusCodes.Status304NotModified);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int Id)
        {

            try
            {
                var status = await _cmd.DeleteProduct(Id);
                if (status == true)
                    return StatusCode(StatusCodes.Status200OK, status);
                return StatusCode(StatusCodes.Status304NotModified);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
