﻿using Cleanic.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cleanic.Application
{
    public class WriteRepository : IWriteRepository
    {
        public WriteRepository(IEventStore store)
        {
            _store = store;
        }

        public async Task<T> Load<T>(IIdentity id) where T : IEntity
        {
            return (T)await Load(id, typeof(T));
        }

        public async Task<IEntity> Load(IIdentity id, Type type)
        {
            var agg = (IAggregate)Activator.CreateInstance(type, id);
            var persistedEvents = await _store.Load(id);
            agg.LoadFromHistory(persistedEvents);
            return agg as IEntity;
        }

        public async Task<IEvent[]> Save(IEntity entity)
        {
            var agg = (IAggregate)entity;
            if (!agg.ProducedEvents.Any()) throw new Exception("There is nothing to save!");
            var persistedVersion = Convert.ToUInt32(agg.Version - agg.ProducedEvents.Count);
            await _store.Save(agg.Id, persistedVersion, agg.ProducedEvents);
            return agg.ProducedEvents.ToArray();
        }

        private readonly IEventStore _store;
    }
}