using System;
using DG.Tweening;
using UnityEngine;

namespace Dre0Dru.Tweening
{
    [Serializable, AddTypeMenu("Sequence")]
    public class TweenSequence : ITween
    {
        [SerializeReference, SubclassSelector]
        protected ITween[] _tweens;

        [SerializeField]
        protected AddType _addType = AddType.Append;

        public Sequence Build()
        {
            var sequence = DOTween.Sequence();

            foreach (var tween in _tweens)
            {
                tween.AddTo(sequence);
            }

            return sequence;
        }

        public void AddTo(Sequence sequence)
        {
            switch (_addType)
            {
                case AddType.Append:
                    sequence.Append(Build());
                    break;
                case AddType.Join:
                    sequence.Join(Build());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_addType));
            }
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
