using System;
using Life.Core.Interfaces;
using Life.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Life.DAL.EventSavers
{
    public abstract class EventSaver
    {
        public DbContext Context { get; }
        public abstract void Save(IEvent eventObj);
        public abstract Type SaveableEventType { get;}

        protected EventSaver(LifeGameDbContext context)
        {
            Context = context;
        }
    }
}
