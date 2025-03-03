using System;
using System.Collections.Generic;

namespace VisitkaUCR.Models;

public partial class Position
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? IdDivision { get; set; }

    public virtual Division? IdDivisionNavigation { get; set; }

    public virtual ICollection<Teacher> IdTeachers { get; set; } = new List<Teacher>();
}
