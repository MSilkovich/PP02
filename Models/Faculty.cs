using System;
using System.Collections.Generic;

namespace VisitkaUCR.Models;

public partial class Faculty
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();
}
