using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var app = WebApplication.Create(args);

app.UseStaticFiles();

app.MapGet("/sse", async context =>
{
    context.Response.Headers.Append("Content-Type", "text/event-stream");
    context.Response.Headers.Append("Cache-Control", "no-cache");
    
    var counter = 0;
    while (!context.RequestAborted.IsCancellationRequested)
    {
        var message = $"data: Message {++counter} at {System.DateTime.Now:HH:mm:ss}\n\n";
        await context.Response.WriteAsync(message);
        await context.Response.Body.FlushAsync();
        await System.Threading.Tasks.Task.Delay(1000);
    }
});

app.MapGet("/", () => Results.Redirect("/index.html"));

app.Run("http://localhost:5000");