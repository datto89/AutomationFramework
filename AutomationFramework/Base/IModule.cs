using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Base
{
    public interface IModule
    {
        void InitializeWebDriver(object driver, params IModule[] modules);
    }
}
