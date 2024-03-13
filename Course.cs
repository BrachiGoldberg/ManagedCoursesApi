public enum LearningWayEum { FRONTAL, ZOOM }

public class Course
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int CategoryId { get; set; }

    public int Duration { get; set; }

    public DateTime StartDate { get; set; }

    public string[] Syllabus { get; set; }

    public LearningWayEum LearningWay { get; set; }

    public int LecturerId { get; set; }

    public string Image { get; set; }
}