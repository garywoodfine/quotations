var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var quotations = new List<Quotation>
{
    new("Minimal Api's are cool", "Gary Woodfine"),
    new("Independent money limits wars", "Dominic Frisby"),
    new("Our system is broken, our laws don't work, our regulators are weak, our governments don't understand what's happening, and our technology is usurping our democracy", "Christopher Wylie"),
    new("1% of the population controls 42% of the wealth", "David Graeber"),
    new("DRY more accurately means that we want to avoid duplicating our system behaviour and knowledge", "Sam Newman"),
    new("Dapr Requires state stores to support eventual consistency by default", "Haishi Bai & Yaron Schneider")
};

app.MapGet("/quote", () =>
    {
        return quotations.OrderBy(_ => new Random().Next()).Take(1);
    })
.WithName("quote");

app.Run();

record Quotation(string Quote, string Citation);
