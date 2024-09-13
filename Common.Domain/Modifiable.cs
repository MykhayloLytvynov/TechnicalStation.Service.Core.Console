using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain
{
    public interface Modifiable
    {
        DateTime CreateTime { get; }
        DateTime ModifyTime { get; }
    }
}
