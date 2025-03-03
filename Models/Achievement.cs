using System;
using System.Collections.Generic;

namespace VisitkaUCR.Models;

public partial class Achievement
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Category { get; set; }

    public virtual ICollection<Teacher> IdTeachers { get; set; } = new List<Teacher>();
}
