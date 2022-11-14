using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Mapper;

using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs.ExamDTOs;
using EntityLayer.DTOs.LessonDTOs;
using EntityLayer.DTOs.StudentDTOs;
using ExamProject.ValidationRules;
using FluentValidation;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using ValidationRules;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("Db");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(connection);

});


builder.Services.AddIdentity<AppUser, AppRole>(opts =>
{
   
   // opts.Password.RequireNonAlphanumeric = false;
   // opts.Password.RequireDigit = false;
   // opts.Password.RequireLowercase = false;
  //  opts.Password.RequireUppercase = false;
   // opts.Password.RequiredLength = 1;

}).AddEntityFrameworkStores<DatabaseContext>();

builder.Services.AddScoped<IGenericRepository<Exam>, GenericRepository<Exam>>();
builder.Services.AddScoped<IGenericRepository<Lesson>, GenericRepository<Lesson>>();
builder.Services.AddScoped<IGenericRepository<Student>, GenericRepository<Student>>();

builder.Services.AddScoped<ILessonService, LessonManager>();
builder.Services.AddScoped<IStudentService, StudentManager>();
builder.Services.AddScoped<IExamService, ExamManager>();

builder.Services.AddAutoMapper(typeof(Automapper));


builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                                       .Build();
    config.Filters.Add(new AuthorizeFilter(policy));

});
builder.Services.ConfigureApplicationCookie(options =>
{
    
    options.LoginPath = "/login/index";
   

  
});



builder.Services.AddScoped<IValidator<StudentToAddorUpdateDTO>, StudentValidatior>();
builder.Services.AddScoped<IValidator<LessonToAddorUpdateDTO>, LessonValidatior>();
builder.Services.AddScoped<IValidator<ExamToAddorUpdateDTO>, ExamValidatior>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=lesson}/{action=index}/{id?}");

app.Run();
