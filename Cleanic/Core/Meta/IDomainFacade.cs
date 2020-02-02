﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cleanic.Core
{
    public interface IDomainFacade
    {
        IReadOnlyCollection<EventMeta> ApplyingEvents { get; }

        IReadOnlyCollection<IProjectionMeta> ApplyingEvent(EventMeta eventMeta);

        void ApplyEvent(IProjection projection, IEvent @event);

        IReadOnlyCollection<EventMeta> ReactingEvents { get; }

        Task<ICommand[]> ReactToEvent(IEvent @event);

        void ModifyEntity(IEntity entity, ICommand command);

        CommandMeta GetCommandMeta(ICommand command);

        EventMeta GetEventMeta(IEvent @event);

        IProjectionMeta GetProjectionMeta(IProjection projection);
    }
}