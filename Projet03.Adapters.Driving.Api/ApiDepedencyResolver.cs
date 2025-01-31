﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet03.Adapters.Driving.Api
{
    public static class ApiDependencyResolver
    {
        public static void AddApiConfiguration(this IServiceCollection services)
        {
            #region CORS

            services.AddCors(
                s => s.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                })
                );

            #endregion

            #region Swagger

            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Treinamento NET CORE - C# Avançado",
                    Description = "Treinamento NET CORE API Swagger",
                    Contact = new OpenApiContact { Name = "COTI Informática", Email = "contato@cotiinformatica.com.br", Url = new Uri("http://www.cotiinformatica.com.br") }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

            });

            #endregion
        }

        public static void UseApiConfiguration(this IApplicationBuilder app)
        {
            #region CORS

            app.UseCors("DefaultPolicy");

            #endregion

            #region Swagger

            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyProject");
            });

            #endregion
        }
    }
}
