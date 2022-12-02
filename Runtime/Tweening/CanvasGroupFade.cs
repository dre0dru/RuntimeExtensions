using System;
using DG.Tweening;
using UnityEngine;

namespace Dre0Dru.Tweening
{
    [Serializable, AddTypeMenu("Canvas Group/Fade")]
    public class CanvasGroupFade : TweenBase
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private float _initialAlpha = 0.0f;

        [SerializeField]
        private float _targetAlpha = 1.0f;

        public override void ResetToInitialValues()
        {
            _canvasGroup.alpha = _initialAlpha;
        }

        protected override Tween Create() =>
            _canvasGroup.DOFade(_targetAlpha, _duration);
    }
}
