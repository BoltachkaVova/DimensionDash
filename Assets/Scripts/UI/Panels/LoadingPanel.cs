using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace UI.Panels
{
    public class LoadingPanel : BasePanel
    {
        public override async UniTask Open()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(delay));
            gameObject.SetActive(true);
            await _canvasGroup.DOFade(1, timeOpen);
        }

        public override async UniTask Close()
        {
            gameObject.SetActive(false);
        }
    }
}