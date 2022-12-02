using System;
using DG.Tweening;
using UnityEngine;

namespace Dre0Dru.Tweening
{
    //TODO может помимо ресета в целом инкапсулировать тут все по анимациям?
    //TODO и сделать это как ITween
    [Serializable]
    public class TweenSequenceBuilder
    {
        [SerializeReference, SubclassSelector]
        private ITween[] _tweens;

        public Sequence Build()
        {
           var sequence = DOTween.Sequence();

           foreach (var tween in _tweens)
           {
               tween.AddTo(sequence);
           }

           return sequence;
        }

        public void ResetToInitialValues()
        {
            foreach (var tween in _tweens)
            {
                tween.ResetToInitialValues();
            }
        }
    }
}
