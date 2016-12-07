﻿using System.Reflection;

namespace OpenDomainModel
{
    public class CommandInfo : MessageInfo
    {
        public AggregateInfo Aggregate { get; }

        public override string DomainType => "Command";

        public CommandInfo(TypeInfo type, AggregateInfo aggregate) : base(type, aggregate.Context)
        {
            Aggregate = aggregate;
        }
    }
}