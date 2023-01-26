using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;
using System.Text.Json;
using Web_api_tour.Data;
using Web_api_tour.SQL;

Client client = new Client() { Fname = "hey", id = 0, Lname = "sss", mail = "asdasd", passport = "sadsdasd", phone = "asdasd"};
Client client2 = new Client() { Fname = "hey", id = 0, Lname = "sss", mail = "asdasd", passport = "sadsdasd", phone = "asdasd"};

List<string> lients = new List<string>();

lients.Add("1");
lients.Add("2");

var strClient = JsonSerializer.Serialize(client);

var clientss = JsonSerializer.Deserialize<Client>(strClient);

ContractOrder client1 = new ContractOrder() { clientID = lients, cost = "0", tourID = "0", date_of_issue = "" };

var strClient1 = JsonSerializer.Serialize(client1);

var clientss1 = JsonSerializer.Deserialize<Client>(strClient1);


Users.users.Add(new User() {name = "admin", password = "kali" });

Users.LeverTrust.Add("admin");
Users.LeverTrust.Add("user");
Users.LeverTrust.Add("undenfindet");

Users.AvalaibleTables.Add("allclientOrders");

StaticSQL.SQL = new PGSQL("192.168.1.110", "admin", "kali", "travel_agency");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
