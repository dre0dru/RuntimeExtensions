using System;
using Dre0Dru.Filters;
using UnityEngine;

namespace Dre0Dru.RigidbodyPhysics.Filters
{
    //TODO composite filter
    [Serializable]
    public class LayerMaskFilter : IFilter<Collision>, IFilter<Collider>
    {
        [SerializeField]
        protected LayerMask _layerMask;
        
        public bool Filter(Collision filtered)
        {
            return IsInLayerMask(filtered.gameObject);
        }

        public bool Filter(Collider filtered)
        {
            return IsInLayerMask(filtered.gameObject);
        }

        private bool IsInLayerMask(GameObject gameObject)
        {
            return _layerMask.IsInLayerMask(gameObject.layer);
        }
    }
}
