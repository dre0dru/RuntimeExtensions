using System;
using UnityEngine;

namespace Dre0Dru.RigidbodyPhysics
{
    public class PhysicsCollisionEvents : MonoBehaviour
    {
        public event Action<Collision> CollisionEntered;
        public event Action<Collision> CollisionStayed;
        public event Action<Collision> CollisionExited;
        
        protected virtual void OnCollisionEnter(Collision other)
        {
            CollisionEntered?.Invoke(other);
        }

        protected virtual void OnCollisionStay(Collision other)
        {
            CollisionStayed?.Invoke(other);
        }

        protected virtual void OnCollisionExit(Collision other)
        {
            CollisionExited?.Invoke(other);
        }
    }
    
    public class PhysicsCollisionEvents<TData> : MonoBehaviour
    {
        [SerializeField]
        protected TData _data;

        public TData Data => _data;
        
        public event Action<CollisionData<TData>> CollisionEntered;
        public event Action<CollisionData<TData>> CollisionStayed;
        public event Action<CollisionData<TData>> CollisionExited;

        protected virtual void OnCollisionEnter(Collision other)
        {
            CollisionEntered?.Invoke(new CollisionData<TData>()
            {
                Collision = other,
                Data = _data
            });
        }

        protected virtual void OnCollisionStay(Collision other)
        {
            CollisionStayed?.Invoke(new CollisionData<TData>()
            {
                Collision = other,
                Data = _data
            });
        }

        protected virtual void OnCollisionExit(Collision other)
        {
            CollisionExited?.Invoke(new CollisionData<TData>()
            {
                Collision = other,
                Data = _data
            });
        }
    }
}
