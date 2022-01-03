﻿using System;
using TesteCQRS.Application.Domain.Enums;

namespace TesteCQRS.Application.Commands
{
    public abstract class QueueCommandResponse
    {
        public Guid CorrelationId { get; set; }
        public string ProcessName { get => GetType().Name; }
        public ProcessStatusEnum ProcessStatus { get; set; }
    }
}
