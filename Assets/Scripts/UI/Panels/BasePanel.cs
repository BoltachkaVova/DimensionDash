using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI.Panels
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class BasePanel : MonoBehaviour
    {
        [SerializeField] protected float delay;
        [SerializeField] protected float timeOpen = 0.5f;
        
        protected CanvasGroup _canvasGroup;
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0;
        }

        public abstract UniTask Open();
        public abstract UniTask Close();
    }
}