using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System;
using WebApplication1;

var adminRole = new Role("admin");
var userRole = new Role("user");
var people = new List<Person>
{
    new Person("tom@gmail.com", "12345", adminRole),
    new Person("bob@gmail.com", "55555", userRole),
};

var builder = WebApplication.CreateBuilder();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/accessdenied";
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();   // ���������� middleware ����������� 

app.MapGet("/accessdenied", async (HttpContext context) =>
{
    context.Response.StatusCode = 403;
    await context.Response.WriteAsync("Access Denied");
});
app.MapGet("/login", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    // html-����� ��� ����� ������/������
    string loginForm = @"<!DOCTYPE html>
    <html>
    <head>
        <meta charset='utf-8' />
        <title>METANIT.COM</title>
    </head>
    <body>
        <h2>Login Form</h2>
        <form method='post'>
            <p>
                <label>Email</label><br />
                <input name='email' />
            </p>
            <p>
                <label>Password</label><br />
                <input type='password' name='password' />
            </p>
            <input type='submit' value='Login' />
        </form>
    </body>
    </html>";
    await context.Response.WriteAsync(loginForm);
});

app.MapPost("/login", async (string? returnUrl, HttpContext context) =>
{
    // �������� �� ����� email � ������
    var form = context.Request.Form;
    // ���� email �/��� ������ �� �����������, �������� ��������� ��� ������ 400
    if (!form.ContainsKey("email") || !form.ContainsKey("password"))
        return Results.BadRequest("Email �/��� ������ �� �����������");
    string email = form["email"];
    string password = form["password"];

    // ������� ������������ 
    Person? person = people.FirstOrDefault(p => p.Email == email && p.Password == password);
    // ���� ������������ �� ������, ���������� ��������� ��� 401
    if (person is null) return Results.Unauthorized();
    var claims = new List<Claim>
    {
        new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email),
        new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role.Name)
    };
    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
    await context.SignInAsync(claimsPrincipal);
    return Results.Redirect(returnUrl ?? "/");
});
// ������ ������ ��� ���� admin
app.Map("/admin", [Authorize(Roles = "admin")] () => "Admin Panel");

// ������ ������ ��� ����� admin � user
app.Map("/", [Authorize(Roles = "admin, user")] (HttpContext context) =>
{
    var login = context.User.FindFirst(ClaimsIdentity.DefaultNameClaimType);
    var role = context.User.FindFirst(ClaimsIdentity.DefaultRoleClaimType);
    return $"Name: {login?.Value}\nRole: {role?.Value}";
});
app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return "������ �������";
});

app.Run();