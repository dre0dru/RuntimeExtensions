using Dre0Dru.Filters;
using UnityEngine;

namespace Dre0Dru.RigidbodyPhysics.Filters
{
    //TODO when ser ref is required we can create a decorator with ser ref inside?
    public class PhysicsCollisionEventsFiltered<TFilter> : PhysicsCollisionEvents
        where TFilter : IFilter<Collision>
    {
        [SerializeField]
        protected TFilter _filter;

        public TFilter Filter => _filter;

        protected override void OnCollisionEnter(Collision other)
        {
            if (!IsValid(other))
            {
                return;
            }

            base.OnCollisionEnter(other);
        }

        protected override void OnCollisionExit(Collision other)
        {
            if (!IsValid(other))
            {
                return;
            }

            base.OnCollisionExit(other);
        }

        protected override void OnCollisionStay(Collision other)
        {
            if (!IsValid(other))
            {
                return;
            }

            base.OnCollisionStay(other);
        }

        private bool IsValid(Collision other)
        {
            return _filter.Filter(other);
        }
    }

    public class PhysicsCollisionEventsFiltered<TData, TFilter> : PhysicsCollisionEvents<TData>
        where TFilter : IFilter<CollisionData<TData>>
    {
        [SerializeField]
        protected TFilter _filter;

        public TFilter Filter => _filter;

        protected override void OnCollisionEnter(Collision other)
        {
            if (!IsValid(other))
            {
                return;
            }

            base.OnCollisionEnter(other);
        }

        protected override void OnCollisionExit(Collision other)
        {
            if (!IsValid(other))
            {
                return;
            }

            base.OnCollisionExit(other);
        }

        protected override void OnCollisionStay(Collision other)
        {
            if (!IsValid(other))
            {
                return;
            }

            base.OnCollisionStay(other);
        }
        
        private bool IsValid(Collision other)
        {
            return _filter.Filter(new CollisionData<TData>()
            {
                Collision = other,
                Data = Data
            });
        }
    }
}
