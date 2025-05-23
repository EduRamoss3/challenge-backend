﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore; 
using WL.Data.Context;
using WL.Data.Repository.Interfaces;
using WL.Data.Repository;
using WL.Data.UnitOfWork.Interfaces;
using WL.Data.UnitOfWork;
using WL.Application.Services.Interfaces;
using WL.Application.Services;
using FluentValidation;
using WL.Application.DTO;
using WL.Application.Validation;
using WL.Application.Model;

namespace WL.IoC
{
    public static class DI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(Data.Repository.Interfaces.IGeneric<>), typeof(Data.Repository.Generic<>));
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<IWallet, WalletRepository>();
            services.AddScoped<ITransfer, TransferRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITransferService, TransferService>();
            services.AddScoped<IWalletService, WalletService>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IValidator<NormalUserDTO>,UserDTOValidation>();
            services.AddScoped<IValidator<WalletDTO>, WalletDTOValidation>();
            services.AddScoped<IValidator<TransferDTO>, TransferDTOValidation>();
            services.AddScoped<IValidator<LoginModel>, LoginValidation>();


            return services;
        }

    }
}
