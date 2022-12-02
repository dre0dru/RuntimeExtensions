using System;
using DG.Tweening;
using UnityEngine;

namespace Dre0Dru.Tweening
{
    //TODO ResetTargetValues перед началом анимации
    public abstract class TweenBase : ITween
    {
        [SerializeField]
        protected float _delay = 0.0f;

        [SerializeField]
        protected float _duration = 1.0f;

        [SerializeField]
        protected Ease _ease = Ease.Linear;

        [SerializeField]
        protected AddType _addType = AddType.Append;

        [SerializeField]
        protected UpdateType _updateType = UpdateType.Normal;

        [SerializeField]
        protected bool _ignoreTimeScale = false;
        
        public void AddTo(Sequence sequence)
        {
            switch (_addType)
            {
                case AddType.Append:
                    sequence.Append(Create()
                        .SetDelay(_delay)
                        .SetEase(_ease)
                        .SetUpdate(_updateType, _ignoreTimeScale));
                    break;
                case AddType.Join:
                    sequence.Join(Create()
                        .SetDelay(_delay)
                        .SetEase(_ease)
                        .SetUpdate(_updateType, _ignoreTimeScale));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_addType));
            }
        }

        public abstract void ResetToInitialValues();

        protected abstract Tween Create();
    }
}
