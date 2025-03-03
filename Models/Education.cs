using System;
using System.Collections.Generic;

namespace VisitkaUCR.Models;

public partial class Education
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string EducationInstitution { get; set; } = null!;

    public string? Institute { get; set; }

    public string? FormOfEducation { get; set; }

    public string? Level { get; set; }

    public string? Speciality { get; set; }

    public virtual ICollection<Teacher> IdTeachers { get; set; } = new List<Teacher>();
}
