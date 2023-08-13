using System;
using UnityEngine;

namespace Dre0Dru.RigidbodyPhysics
{
    [Serializable]
    public struct ColliderData<TData>
    {
        public Collider Collider;
        public TData Data;
    }
}
