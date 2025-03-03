using System;
using System.Collections.Generic;

namespace VisitkaUCR.Models;

public partial class Qualification
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string EducationalInstitution { get; set; } = null!;

    public string CourseName { get; set; } = null!;

    public string? FormOfEducation { get; set; }

    public int? Volume { get; set; }

    public string? Document { get; set; }

    public string? TrainingPeriod { get; set; }

    public virtual ICollection<Teacher> IdTeachers { get; set; } = new List<Teacher>();
}
