﻿using System;

namespace FrogsTalks.Domain
{
    /// <summary>
    /// Information about the state of the domain.
    /// </summary>
    public class Projection : Entity
    {
        public Projection(Guid id) : base(id) { }
    }
}