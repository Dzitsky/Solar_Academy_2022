﻿using Microsoft.EntityFrameworkCore;
using ShoppingCart.AppServices.Product.Repositories;
using ShoppingCart.AppServices.Product.Services;
using ShoppingCart.AppServices.Services;
using ShoppingCart.AppServices.ShoppingCart.Repositories;
using ShoppingCart.AppServices.ShoppingCart.Services;
using ShoppingCart.DataAccess.EntityConfigurations.Product;
using ShoppingCart.DataAccess.EntityConfigurations.ShoppingCart;
using ShoppingCart.DataAccess.Interfaces;
using ShoppingCart.DataAccess;
using ShoppingCart.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using ShoppingCart.Contracts;

namespace ShoppingCart.Api
{
    /// <summary>
    /// 
    /// </summary>
    public static class SwaggerModule
    {
        public static IServiceCollection AddSwaggerModule(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Shopping Cart Api", Version = "V1" });
                options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory,
                    $"{typeof(ShoppingCartDto).Assembly.GetName().Name}.xml")));
                options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory, "Documentation.xml")));
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
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

            return services;
        }
    }
}
