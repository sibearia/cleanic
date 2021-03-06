﻿using System;
using System.Collections.Generic;

namespace Cleanic.Core
{
    public class Entity : DomainObject
    {
        public String Id { get; }

        public Entity(String id)
        {
            Id = id;
        }

        protected override IEnumerable<Object> GetIdentityComponents()
        {
            yield return Id;
        }
    }
}