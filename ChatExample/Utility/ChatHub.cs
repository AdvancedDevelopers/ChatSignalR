using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ChatExample
{
    public class ChatHub : Hub
    {
        public void Send(string Email, string Message,string Status)
        {
            Clients.All.AddNewMessageToPage(Email,Message,Status);
        }
    }
}