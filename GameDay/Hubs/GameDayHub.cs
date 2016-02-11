﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace GameDay.Hubs
{
    public class GameDayHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}