using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreProject.Middlewares
{
    public class LoggerMiddleware
    {
        private  readonly RequestDelegate next;

        public LoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == "GET")
            {
                // Add logging in to DB here 
                Debug.WriteLine("Logging GET request");
                await next.Invoke(context);
            }

        }
    }
}
