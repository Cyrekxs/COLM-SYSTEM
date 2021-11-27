﻿using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Interfaces
{
    public interface IApplicationRepository
    {
        Task<bool> IsSettingsSetted();
        Task<SystemSettings> GetSystemSettings();

        Task<int> SaveSystemSettings(SystemSettings settings);
    }
}
