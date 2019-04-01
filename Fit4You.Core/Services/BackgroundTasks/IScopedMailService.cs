using System;
using System.Collections.Generic;
using System.Text;
using Fit4You.Core.Utilities;

namespace Fit4You.Core.BackgroundTasks
{
    public interface IScopedMailService
    {
        void DoWork();
    }
}
