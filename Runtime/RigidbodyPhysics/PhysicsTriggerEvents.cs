using System;
using UnityEngine;

namespace Dre0Dru.RigidbodyPhysics
{
    public class PhysicsTriggerEvents : MonoBehaviour
    {
        public event Action<Collider> TriggerEntered;
        public event Action<Collider> TriggerStayed;
        public event Action<Collider> TriggerExited;
        
        protected virtual void OnTriggerEnter(Collider other)
        {
            TriggerEntered?.Invoke(other);
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            TriggerStayed?.Invoke(other);
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            TriggerExited?.Invoke(other);
        }
    }
    
    public class PhysicsTriggerEvents<TData> : MonoBehaviour
    {
        [SerializeField]
        protected TData _data;
        
        public TData Data => _data;
        
        public event Action<ColliderData<TData>> TriggerEntered;
        public event Action<ColliderData<TData>> TriggerStayed;
        public event Action<ColliderData<TData>> TriggerExited;
        
        protected virtual void OnTriggerEnter(Collider other)
        {
            TriggerEntered?.Invoke(new ColliderData<TData>()
            {
                Collider = other,
                Data = _data
            });
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            TriggerStayed?.Invoke(new ColliderData<TData>()
            {
                Collider = other,
                Data = _data
            });
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            TriggerExited?.Invoke(new ColliderData<TData>()
            {
                Collider = other,
                Data = _data
            });
        }
    }
}
