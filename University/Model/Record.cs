namespace University.Model
{
    public class Record
    {
        public int Id { get; set; }
        public int? SpecializationId { get; set; }
        public Specialization? Specialization { get; set; }
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
