using System;
using UnityEngine;

namespace Dre0Dru.RigidbodyPhysics
{
    public class PhysicsCollisionEvents : MonoBehaviour
    {
        public event Action<Collision> CollisionEnter;
        public event Action<Collision> CollisionStay;
        public event Action<Collision> CollisionExit;
        
        protected virtual void OnCollisionEnter(Collision other)
        {
            CollisionEnter?.Invoke(other);
        }

        protected virtual void OnCollisionStay(Collision other)
        {
            CollisionStay?.Invoke(other);
        }

        protected virtual void OnCollisionExit(Collision other)
        {
            CollisionExit?.Invoke(other);
        }
    }
    
    public class PhysicsCollisionEvents<TData> : MonoBehaviour
    {
        [SerializeField]
        protected TData _data;

        public TData Data => _data;
        
        public event Action<CollisionData<TData>> CollisionEnter;
        public event Action<CollisionData<TData>> CollisionStay;
        public event Action<CollisionData<TData>> CollisionExit;

        protected virtual void OnCollisionEnter(Collision other)
        {
            CollisionEnter?.Invoke(new CollisionData<TData>()
            {
                Collision = other,
                Data = _data
            });
        }

        protected virtual void OnCollisionStay(Collision other)
        {
            CollisionStay?.Invoke(new CollisionData<TData>()
            {
                Collision = other,
                Data = _data
            });
        }

        protected virtual void OnCollisionExit(Collision other)
        {
            CollisionExit?.Invoke(new CollisionData<TData>()
            {
                Collision = other,
                Data = _data
            });
        }
    }
}
