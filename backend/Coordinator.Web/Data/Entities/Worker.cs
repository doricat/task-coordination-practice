﻿namespace Coordinator.Web.Data.Entities;

public class Worker : Entity
{
    public string? Name { get; set; }

    public WorkerType Type { get; set; }
}