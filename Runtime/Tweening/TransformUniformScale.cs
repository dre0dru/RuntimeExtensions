using System;
using DG.Tweening;
using UnityEngine;

namespace Dre0Dru.Tweening
{
    [Serializable, AddTypeMenu("Transform/Uniform Scale")]
    public class TransformUniformScale : TweenBase
    {
        [SerializeField]
        private RectTransform _rectTransform;

        [SerializeField]
        private float _initialScale = 0.0f;

        [SerializeField]
        private float _targetScale = 1.0f;

        public override void ResetToInitialValues()
        {
            _rectTransform.localScale = new Vector3(_initialScale, _initialScale, _initialScale);
        }

        protected override Tween Create()
        {
            return _rectTransform.DOScale(new Vector3(_targetScale, _targetScale, _targetScale), _duration);
        }
    }
}
