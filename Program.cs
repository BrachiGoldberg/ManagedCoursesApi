var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Context>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }));

var app = builder.Build();
app.UseCors("MyPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

int courseId = 5;
int userId = 6;
int categiryId = 4;

app.MapGet("/", () => "Hello World!");

/*--------------- Course controllers -------------------------*/

app.MapGet("/courses/all-courses", (Context context) =>
{
    return Results.Ok(context.Courses);
});

app.MapGet("/courses/{id}", (Context context, int id) =>
{
    var course = context.Courses.FirstOrDefault(c => c.Id == id);
    if (course is null)
        return Results.NotFound();
    return Results.Ok(course);
});

app.MapPost("/courses/add-course", (Context context, Course course) =>
{
    if (course is not null)
    {
        course.Id = courseId++;
        context.Courses.Add(course);
        return Results.Ok(course);
    }
    return Results.Ok();
});

app.MapPut("/courses/course/{id}", (Context context, Course course, int id) =>
{
    var myCourse = context.Courses.Where(c => c.Id == id).FirstOrDefault();
    if (myCourse is not null)
    {
        myCourse.Name = course.Name;
        myCourse.StartDate = course.StartDate;
        myCourse.Duration = course.Duration;
        myCourse.Syllabus = course.Syllabus;
        myCourse.LearningWay = course.LearningWay;
        myCourse.CategoryId = course.CategoryId;

        return Results.Ok(myCourse);
    }
    return Results.NotFound();
});


app.MapDelete("/courses/course/{id}", (Context context, int id) =>
{
    var myCourse = context.Courses.FirstOrDefault(c => c.Id == id);
    if (myCourse is not null)
    {
        context.Courses.Remove(myCourse);
        return Results.Ok(myCourse);
    }

    return Results.NotFound();
});



/*--------------- User controllers -------------------------*/


app.MapPost("/user/login", (Context context, UserPostModel user) =>
{
    if (user.Name is not null && user.Password is not null)
    {
        var myUser = context.Users.FirstOrDefault(u => u.Name == user.Name && u.Password == user.Password);
        if (myUser is not null)
        {
            return Results.Ok(myUser);
        }
    }
    return Results.StatusCode(401);
});

app.MapPost("/user/register", (Context context, User user) =>
{
    var users = context.Users.Where(u => u.Name == user.Name || u.Email == user.Email);
    if (users.Count() > 0)
    {
        return Results.StatusCode(412);
    }
    user.Id = userId++;
    context.Users.Add(user);
    return Results.Ok(user);
});

app.MapGet("/lecturer/{id}", (Context context, int id) =>
{
    var lecturer = context.Users.FirstOrDefault(u => u.Id == id && u.IsLecturer);
    if (lecturer is not null)
        return Results.Ok(lecturer.Name);
    return Results.NotFound();
});


/*--------------- Category controllers -------------------------*/

app.MapGet("/categories", (Context context) =>
{
    return Results.Ok(context.Categories);
});

app.MapGet("/categories/{id}", (Context context, int id) =>
{
    var category = context.Categories.FirstOrDefault(c => c.Id == id);
    if (category is null)
        return Results.NotFound();
    return Results.Ok(category);
});

app.MapPost("/categories/new-category", (Context context , Category category)=>{
    var myCategory = context.Categories.FirstOrDefault(c=>c.Name == category.Name);
    if(myCategory is not null){
        category.Id = categiryId++;
        context.Categories.Add(category);
        return Results.Ok(category);
    }
    return Results.NotFound();
});


app.Run();
