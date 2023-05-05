﻿using UnityEngine;

namespace Dre0Dru.CachedComponents
{
    public class CachedTransform : CachedComponent<Transform>
    {
        public CachedTransform(GameObject source) : base(source)
        {
        }
        
        public CachedTransform(Component source) : base(source)
        {
        }
    }
}
