using System;
using UnityEngine;

namespace Dre0Dru.RigidbodyPhysics
{
    public class PhysicsTriggerEvents : MonoBehaviour
    {
        public event Action<Collider> TriggerEnter;
        public event Action<Collider> TriggerStay;
        public event Action<Collider> TriggerExit;
        
        protected virtual void OnTriggerEnter(Collider other)
        {
            TriggerEnter?.Invoke(other);
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            TriggerStay?.Invoke(other);
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            TriggerExit?.Invoke(other);
        }
    }
    
    public class PhysicsTriggerEvents<TData> : MonoBehaviour
    {
        [SerializeField]
        protected TData _data;
        
        public TData Data => _data;
        
        public event Action<ColliderData<TData>> TriggerEnter;
        public event Action<ColliderData<TData>> TriggerStay;
        public event Action<ColliderData<TData>> TriggerExit;
        
        protected virtual void OnTriggerEnter(Collider other)
        {
            TriggerEnter?.Invoke(new ColliderData<TData>()
            {
                Collider = other,
                Data = _data
            });
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            TriggerStay?.Invoke(new ColliderData<TData>()
            {
                Collider = other,
                Data = _data
            });
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            TriggerExit?.Invoke(new ColliderData<TData>()
            {
                Collider = other,
                Data = _data
            });
        }
    }
}
