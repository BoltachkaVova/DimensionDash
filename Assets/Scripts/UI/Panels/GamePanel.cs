using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;


namespace UI.Panels
{
    public class GamePanel : BasePanel
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