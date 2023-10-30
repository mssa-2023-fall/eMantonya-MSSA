var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Run(async context =>
//{
//    string? path = context.Request.Path.Value;
//    string[] parts = path.Split('/');
//    if (int.TryParse(parts[1], out int a) && int.TryParse(parts[2], out int b))
//    {
//        await context.Response.WriteAsync($"{a + b}");
//    }
//    else { await context.Response.WriteAsync("Hello World!"); }
//});

// https://localhost:xxxx/some-prompt => https://letmegooglethat.com/?q=[prompt]
// context.REsponse.Redirect
//prompt must be encoded correctly -- how to encode a query string properly

app.Run(async context =>
{
    string? path = context.Request.Path.Value;
    if (path.Length > 1)
    {
        string prompt = Uri.EscapeDataString(path).Substring(3);

        string newPath = $"https://letmegooglethat.com/?q={prompt}";
        context.Response.Redirect(newPath);
    }
    else
    {
        await context.Response.WriteAsync($"<h1> Hello.. <a href='https://http.cat/status/204'> Click here </a></h1>");
    }
});

app.Run();


//localhost:7254/num/num1
//takes two nums from path add them together replacing hello world
