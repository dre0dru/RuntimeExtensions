using System;
using DG.Tweening;
using UnityEngine;

namespace Dre0Dru.Tweening
{
    [Serializable, AddTypeMenu("Append Interval")]
    public class Interval : ITween
    {
        [SerializeField]
        private float _interval;
        
        public void AddTo(Sequence sequence) => 
            sequence.AppendInterval(_interval);

        public void ResetToInitialValues()
        {
        }
    }
}
