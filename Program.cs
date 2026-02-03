var builder = WebApplication.CreateBuilder(args);           //createbuilder:contains a logic to create and build kastrol web server , It also contains login for calling appsettings and launchsettings.json
//builder instance is used to add feutures to the web server
// Add services to the container.
//controller can return json,string and content , with views allows the server to return views
builder.Services.AddControllersWithViews();
//addsession service is used to support session feutures
builder.Services.AddSession();
//add cache feuture
builder.Services.AddOutputCache();
//after adding feutures build the application , no other feutures can be added after this.
var app = builder.Build();
//--------------------------

//middlewares : piece of code that needs to be executed before calling controller method
//piece of code : authentication,logging,caching,static files
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");     //custom error page
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}
    app.UseStatusCodePages();


//app.UseStatusCodePagesWithRedirects("method path");        //to show contents of error page as we wanted url will be method name
//app.UseStatusCodePagesWithReExecute();                     //to show contents of error page as we wanted url will be wrongly given url
app.UseHttpsRedirection();          //never use http ptotocal always use https
app.UseStaticFiles();               //client sides pages never executes
app.UseOutputCache();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MyPizza}/{action=Login}/{id?}");

app.Run();          //after run method , you cannot add a middleware
