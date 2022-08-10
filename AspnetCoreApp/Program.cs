var builder = WebApplication.CreateBuilder(args); //WebServer 
var app = builder.Build();

//Cofigure DI Container


//Pipeline Configuration
//app.UseAuthentication();
//app.UseHttpsRedirection();
//app.UseHsts();

//app.UseStaticFiles();
//Middleware -> RouteEndpoint
app.MapGet("/", context => {

    return context.Response.WriteAsync("Hello");

});
app.MapGet("/greet", () => "Hello World!");

app.Run();
