﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient.Services
{
    public interface IGrpcListener
    {
        Task StartAsync();
    }
}
