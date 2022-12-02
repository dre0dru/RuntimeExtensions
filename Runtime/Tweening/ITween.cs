using DG.Tweening;

namespace Dre0Dru.Tweening
{
    public interface ITween
    {
        void AddTo(Sequence sequence);

        void ResetToInitialValues();
    }
}
