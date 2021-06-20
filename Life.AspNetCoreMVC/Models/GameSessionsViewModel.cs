using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Life.DAL.Models;

namespace Life.AspNetCoreMVC.Models
{
    public class GameSessionsViewModel
    {
        public List<Session> SessionsInfo { get; set; }
    }
}
