using System;
using DG.Tweening;
using UnityEngine;

namespace Dre0Dru.Tweening
{
    [Serializable, AddTypeMenu("Canvas Group/Blocks Raycasts")]
    public class CanvasGroupBlocksRaycasts : TweenBase
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private bool _initialBlocksRaycasts = false;

        [SerializeField]
        private bool _targetBlocksRaycasts = true;

        public override void ResetToInitialValues()
        {
            _canvasGroup.blocksRaycasts = _initialBlocksRaycasts;
        }

        protected override Tween Create() =>
            DOVirtual.DelayedCall(_duration, () => _canvasGroup.blocksRaycasts = _targetBlocksRaycasts);
    }
}
