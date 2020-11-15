using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace GCI
{
    public class GCIMiddleware
    {
        RequestDelegate _next;

        public GCIMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Equals("/__gci"))
            {
                string header = context.Request.Headers["gci"];

                switch (header)
                {
                    case "ch":
                        await context.Response.WriteAsync(GC.GetTotalMemory(false).ToString());
                        break;

                    case "gc":
                        GC.Collect();
                        break;
                }

                await context.Response.CompleteAsync();
            }
            else
            {
                await _next(context);
            }
        }
    }
}

