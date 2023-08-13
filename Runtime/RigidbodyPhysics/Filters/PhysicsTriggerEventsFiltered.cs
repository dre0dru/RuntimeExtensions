using Dre0Dru.Filters;
using UnityEngine;

namespace Dre0Dru.RigidbodyPhysics.Filters
{
    public class PhysicsTriggerEventsFiltered<TFilter> : PhysicsTriggerEvents
        where TFilter : IFilter<Collider>
    {
        [SerializeField]
        protected TFilter _filter;

        public TFilter Filter => _filter;

        protected override void OnTriggerEnter(Collider other)
        {
            if (!IsValid(other))
            {
                return;
            }

            base.OnTriggerEnter(other);
        }

        protected override void OnTriggerStay(Collider other)
        {
            if (!IsValid(other))
            {
                return;
            }

            base.OnTriggerStay(other);
        }

        protected override void OnTriggerExit(Collider other)
        {
            if (!IsValid(other))
            {
                return;
            }

            base.OnTriggerExit(other);
        }
        
        private bool IsValid(Collider other)
        {
            return _filter.Filter(other);
        }
    }

    public class PhysicsTriggerEventsFiltered<TData, TFilter> : PhysicsTriggerEvents<TData>
        where TFilter : IFilter<ColliderData<TData>>
    {
        [SerializeField]
        protected TFilter _filter;

        public TFilter Filter => _filter;

        protected override void OnTriggerEnter(Collider other)
        {
            if (!IsValid(other))
            {
                return;
            }

            base.OnTriggerEnter(other);
        }

        protected override void OnTriggerStay(Collider other)
        {
            if (!IsValid(other))
            {
                return;
            }

            base.OnTriggerStay(other);
        }

        protected override void OnTriggerExit(Collider other)
        {
            if (!IsValid(other))
            {
                return;
            }

            base.OnTriggerExit(other);
        }

        private bool IsValid(Collider other)
        {
            return _filter.Filter(new ColliderData<TData>()
            {
                Collider = other,
                Data = Data
            });
        }
    }
}
