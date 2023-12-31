﻿using System;
using System.Collections.Generic;

namespace LWBack.Model;

public partial class Permission
{
    public int PermissionId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<PosPerm> PosPerms { get; set; } = new List<PosPerm>();
}
