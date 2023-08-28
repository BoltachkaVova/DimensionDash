using UnityEngine;

namespace Rewards
{
    public abstract class BaseReward : MonoBehaviour // todo будут наслодоваться объкты: reward, obstacle
    {
        private float _speed; 
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player.Player>())
            {
                CollidedPlayer();
            }
        }

        private void Update()
        {
            MovementIsSmooth();
        }

        protected abstract void CollidedPlayer();

        private void MovementIsSmooth()
        {
            transform.Translate(Vector3.back * (_speed * Time.deltaTime));
        }

        public void Init(float speed)
        {
            _speed = speed;
            gameObject.SetActive(true);
        }
    }
}