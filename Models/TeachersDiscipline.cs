using System;
using System.Collections.Generic;

namespace VisitkaUCR.Models;

public partial class TeachersDiscipline
{
    public int IdTeacher { get; set; }

    public int IdDiscipline { get; set; }

    public int? Grade { get; set; }

    public virtual Discipline IdDisciplineNavigation { get; set; } = null!;

    public virtual Teacher IdTeacherNavigation { get; set; } = null!;
}
