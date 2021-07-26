using Ecom.Domain.Models;
using Ecom.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.CustomerUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //[BindProperty]
        public ProductViewModel Product { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            //new CreateProduct().Do();
            return RedirectToPage("Index");
        }

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public string? Description { get; set; }
            public string Price { get; set; }            
            public DateTime CreatedDate { get; set; }           

        }
    }
}
