using System;
using System.Web.Http;
using WebActivatorEx;
using JCE.DataCenter.WebApi;
using Swashbuckle.Application;
using JCE.DataCenter.WebApi.SwaggerExtensions;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace JCE.DataCenter.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "JCE.DataCenter.WebApi");
                        c.ApiKey("Authorization").Description("OAuth2 Auth").In("header").Name("Bearer ");
                        c.IncludeXmlComments(string.Format("{0}/bin/JCE.DataCenter.WebApi.XML", AppDomain.CurrentDomain.BaseDirectory));
                        c.IncludeXmlComments(string.Format("{0}/bin/JCE.DataCenter.Domain.XML", AppDomain.CurrentDomain.BaseDirectory));
                        c.IncludeXmlComments(string.Format("{0}/bin/JCE.DataCenter.Infrastructure.XML", AppDomain.CurrentDomain.BaseDirectory));
                        c.OperationFilter<AddAuthorizationHeaderParameterOperationFilter>();
                        c.OperationFilter<AddUploadOperationFilter>();
                        c.DocumentFilter<AuthTokenOperation>();
                        c.CustomProvider((defaultProvider) => new CachingSwaggerProvider(defaultProvider));
                    })
                .EnableSwaggerUi(c =>
                    {                        
                    });
        }
    }
}
