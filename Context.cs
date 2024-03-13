public class Context
{
    public List<Course> Courses { get; set; }

    public List<User> Users { get; set; }

    public List<Category> Categories { get; set; }

    public Context()
    {
        Courses = new List<Course>();

        Courses.AddRange(new List<Course>(){
            new Course(){
            Id=1, Name="Python", CategoryId= 1, Duration= 10, StartDate= new DateTime(2024,03,12),
            Syllabus= new string[]{"python basic", "libraries", "maching learning"},
            LearningWay= LearningWayEum.FRONTAL, LecturerId= 1, Image= "https://miro.medium.com/v2/resize:fit:1400/1*m0H6-tUbW6grMlezlb52yw.png"
            },
            new Course(){
            Id=2, Name="Real Time", CategoryId= 1, Duration= 8, StartDate= new DateTime(2024,03,20),
            Syllabus= new string[]{"communication", "real time system", "freeRTOS"},
            LearningWay= LearningWayEum.ZOOM, LecturerId= 2, Image= "https://estuary.dev/static/fde13056c70783b74f41b10d9649f74a/3a40c/dd278b_03_Real_Time_Processing_Benefits_d8291dd351.jpg"
             },
            new Course(){
            Id=3, Name="Photoshop", CategoryId= 2, Duration= 20, StartDate= new DateTime(2024,03,01),
            Syllabus= new string[]{"introduction", "clips"},
            LearningWay= LearningWayEum.FRONTAL, LecturerId= 3, Image= "https://img-c.udemycdn.com/course/750x422/5346430_f677.jpg"
             },
            new Course(){
            Id=4, Name="Statistic", CategoryId= 3, Duration= 5, StartDate= new DateTime(2024,04,12),
            Syllabus= new string[]{"basic statistic", "external"},
            LearningWay= LearningWayEum.ZOOM, LecturerId= 4, Image= "https://www.thoughtco.com/thmb/vPZchuBNtuGgiChRefakysv1saQ=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/bar-chart-build-of-multi-colored-rods-114996128-5a787c8743a1030037e79879.jpg"
            },
         });

        Categories = new List<Category>();

        Categories.AddRange(new List<Category>(){
            new Category(){
                Id=1, Name="computers", IconPath="icon path to computers"
            },
            new Category(){
                Id=3, Name="design", IconPath="icon path to design"
            },
            new Category(){
                Id=3, Name="mathematic", IconPath="icon path to mathematic"
            },
         });


        Users = new List<User>();

        Users.AddRange(new List<User>(){
            new User(){
                Id=1, Identity="123456789", Name= "brachi", Address= "brachi address",Email= "brachi@gmail.com",
                Password= "brachi", IsLecturer= true
            },
            new User(){
                Id=2, Identity="987654321", Name= "ayala", Address= "ayala address",Email= "ayala@gmail.com",
                Password= "ayala", IsLecturer= true
            },
            new User(){
                Id=3, Identity="456798123", Name= "sari", Address= "sari address",Email= "sari@gmail.com",
                Password= "sari", IsLecturer= true
            },
            new User(){
                Id=4, Identity="456123789", Name= "shosi", Address= "shosi address",Email= "shosi@gmail.com",
                Password= "shosi", IsLecturer= true
            },
            new User(){
                Id=5, Identity="444444444", Name= "someone", Address= "someone address",Email= "someone@gmail.com",
                Password= "someone", IsLecturer= false
            },
         });

    }
}