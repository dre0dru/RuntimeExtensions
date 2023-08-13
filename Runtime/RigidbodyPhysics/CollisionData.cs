using System;
using UnityEngine;

namespace Dre0Dru.RigidbodyPhysics
{
    [Serializable]
    public struct CollisionData<TData>
    {
        public Collision Collision;
        public TData Data;
    }
}
