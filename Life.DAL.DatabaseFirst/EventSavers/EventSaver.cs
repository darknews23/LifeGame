using System;
using Life.Core.Interfaces;
using Life.DAL.DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace Life.DAL.DatabaseFirst.EventSavers
{
    public abstract class EventSaver
    {
        public DbContext Context { get; }
        public abstract void Save(IEvent eventObj);
        public abstract Type SaveableEventType { get;}

        protected EventSaver(LifeGameDBContext context)
        {
            Context = context;
        }
    }
}
