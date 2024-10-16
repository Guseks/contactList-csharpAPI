using contactList;

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


var contacts = new List<Contact>();

void init()
{
    var names = new string[3] {"Erik", "James", "Thomas"};
    var phoneNumbers = new string[3] {"0734-124102", "0721-128923", "0737-828191"};
    var emails = new string[3] {"test@gmail.com", "test2@gmail.com", "test3@gmail.com"};

    for(var i = 0; i < names.Length; i++)
    {
        contacts.Add(new Contact(names[i], phoneNumbers[i], emails[i]));
    }
}


app.MapGet("/", () =>
{
    return Results.Ok(contacts);
})
.WithName("Home")
.WithOpenApi();

app.MapPost("/new", (Contact contact) =>
{
 contacts.Add(contact);
 return Results.Created($"Contact with name: {contact.Name}", contact);
})
.WithName("newContact")
.WithOpenApi();

init();
app.Run();

