﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR
{
    public interface IEngineService : IBaseService
    {
        IFactory ResourceAccessorFactory { get; set; }
    }
}
