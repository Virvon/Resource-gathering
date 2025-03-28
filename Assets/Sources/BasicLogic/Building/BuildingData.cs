using System;
using Sources.Infrastructure;
using UnityEngine;

namespace Sources.BasicLogic.Building
{
    [Serializable]
    public struct BuildingData
    {
        public Vector3 Position;
        public Building Prefab;
    }
}