using System.Net;
using System.Runtime.InteropServices;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace MyEcommerce.Products
{
    public class Products
    {
        private readonly ILogger _logger;

        public Products(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Products>();
        }

        [Function("Products")]
        public ProductBindings Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req, ProductDTO product)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            if(req.Method == "POST") { return Create(req, product); }

            return new ProductBindings
            {
                HttpResponse = response,
            };
        }

        private static ProductBindings Create(HttpRequestData req, ProductDTO product)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            product.Id = Guid.NewGuid().ToString();
            response.WriteString($"{product.Id}");

            return new ProductBindings
            {
                HttpResponse = response,
                Product = product
            };
        }
    }
}
