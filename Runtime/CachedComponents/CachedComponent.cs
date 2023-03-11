using UnityEngine;

namespace Dre0Dru.CachedComponents
{
    public class CachedComponent<TComponent>
        where TComponent : class
    {
        private readonly GameObject _source;
        private TComponent _component;

        public TComponent Component => _component ??= _source.GetComponent<TComponent>();

        public CachedComponent(GameObject source)
        {
            _source = source;
        }
        
        public static implicit operator TComponent(CachedComponent<TComponent> cachedComponent)
        {
            return cachedComponent.Component;
        }
    }
}
