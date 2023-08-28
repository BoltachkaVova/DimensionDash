using UnityEngine;
using Zenject;

namespace Triggers
{
    public abstract class BaseTrigger : MonoBehaviour
    {
        [SerializeField] private ParticleSystem effect;
        [SerializeField] private ParticleSystem playerEnter;
        
        protected float _speed;
        protected SignalBus _signal;
        
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signal = signalBus;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.GetComponent<Player.Player>()) return;
            PlayerEnter();
            
            effect.Stop();

            playerEnter.transform.position = other.transform.position;
            playerEnter.Play();
        }

        public void Init(float speed)
        {
            gameObject.SetActive(true);
            effect.Play();
            
            _speed = speed;
        }

        protected abstract void PlayerEnter();
    }
}