global using BusinessLogicLayer.SI.DTO;
global using Microsoft.AspNetCore.Identity;
global using System.ComponentModel.DataAnnotations;
global using BusinessLogicLayer.SI.Services;
global using Microsoft.Extensions.DependencyInjection;
global using BusinessLogicLayer.SI.Profiles;
global using DataAccessLayer.Repository;
global using System.Linq.Expressions;
global using Domain.Entities.OrderEntities;
global using IKEA.DAL.Models.Identity;
global using System.Net;
global using System.Net.Mail;
global using System.Text.Json;
global using AutoMapper;
global using DataAccessLayer.Data.Entities;
global using DataAccessLayer.Exceptions;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using Domain.Contracts;
global using Services.Specifications;
global using BusinessLogicLayer.SI.Specifications;
global using BusinessLogicLayer.SI.Common.Services.EmailSettings;
global using Domain.Entities;
global using Services.Abstractions;
global using Stripe;
global using Product = DataAccessLayer.Data.Entities.Product;




