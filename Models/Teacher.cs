using System;
using System.Collections.Generic;

namespace VisitkaUCR.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public byte[]? Photo { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<TeachersDiscipline> TeachersDisciplines { get; set; } = new List<TeachersDiscipline>();

    public virtual ICollection<Achievement> IdAchievements { get; set; } = new List<Achievement>();

    public virtual ICollection<Education> IdEducations { get; set; } = new List<Education>();

    public virtual ICollection<Position> IdPositions { get; set; } = new List<Position>();

    public virtual ICollection<Publication> IdPublications { get; set; } = new List<Publication>();

    public virtual ICollection<Qualification> IdQualifications { get; set; } = new List<Qualification>();
}
