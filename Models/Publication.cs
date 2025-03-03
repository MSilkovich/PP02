using System;
using System.Collections.Generic;

namespace VisitkaUCR.Models;

public partial class Publication
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Category { get; set; }

    public string? Description { get; set; }

    public string? Document { get; set; }

    public virtual ICollection<Teacher> IdTeachers { get; set; } = new List<Teacher>();
}
