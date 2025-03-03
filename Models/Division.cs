using System;
using System.Collections.Generic;

namespace VisitkaUCR.Models;

public partial class Division
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? IdFaculty { get; set; }

    public virtual Faculty? IdFacultyNavigation { get; set; }

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}
