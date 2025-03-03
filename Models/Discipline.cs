using System;
using System.Collections.Generic;

namespace VisitkaUCR.Models;

public partial class Discipline
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<TeachersDiscipline> TeachersDisciplines { get; set; } = new List<TeachersDiscipline>();
}
