// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

// app.Run();





WebApplication app = WebApplication.Create(args);

List<Teacher> teachers = [
    new() {Name = "eddi", Subject = "dö", Wage = 10},
    new() {Name = "sandor", Subject = "surfa", Wage = 271},
    new() {Name = "Abbe", Subject = "rita", Wage = 100000},
];


app.MapGet("/", Hello);
app.MapGet("/gustav", Gustav);
app.MapGet("/teachers", GiveTeacher);
app.MapGet("/teacher/{n}", GiveaTeacher);
app.MapPost("/teacher/new", AddTeacher);

app.Urls.Add("http://localhost:5043");
app.Urls.Add("http://*:5043");

app.Run();

IResult AddTeacher(Teacher t)
{
    teachers.Add(t);
    return Results.Ok();
}

List<Teacher> GiveTeacher()
{
    
    return teachers;
}

IResult GiveaTeacher(int n)
{
    if (n < 0 || n >= teachers.Count)
    {
        return Results.NotFound();
    }

    
    return Results.Ok(teachers[n]);
}

static string Hello()
{
    return "Hello";
}

static string Gustav()
{
    return "my name is jeff";
}
