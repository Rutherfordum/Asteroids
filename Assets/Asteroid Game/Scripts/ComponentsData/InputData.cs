﻿using Unity.Entities;
using Unity.Mathematics;

public struct InputData : IComponentData
{
    public float2 MoveVector;
    public bool MoveAction;
}
