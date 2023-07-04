using System;
using System.Collections.Generic;

namespace LWBack.Model;

public partial class PosPerm
{
    public int PosPermId { get; set; }

    public int? PermissionId { get; set; }

    public int? PositionId { get; set; }

    public virtual Permission Permission { get; set; }

    public virtual Position Position { get; set; }
}
