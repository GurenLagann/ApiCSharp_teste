using System.Threading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testerf.Data;
using testerf.Models;


namespace testerf.Controllers
{

    [ApiController]
    [Route("v1/categories")]

    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return categories;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context,
            [FromBody] Category model)
            {
                if (ModelState.IsValid)
                {
                    ContextBoundObject.Categories.Add(model);
                    await ContextCallback.SaveChangesAsync();
                    return model;
                }
                else
                {
                    return BaafRequest(ModelState);
                }
            }
        
    }
}