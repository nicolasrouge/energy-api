using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using dotnetEnsekTechChallenge.Dtos.MeterReading;
using dotnetEnsekTechChallenge.Models;

namespace dotnetEnsekTechChallenge.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try{
                await next(context);
            }catch (Exception e){
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                //var serviceResponse = new ServiceResponse<List<GetMeterReadingDto>>();
                //serviceResponse.Message

                await context.Response.WriteAsync(e.Message);
                /*if(e.InnerException is not null){
                await context.Response.WriteAsync(e.InnerException.Message);
                }*/
            }
        }
    }
}