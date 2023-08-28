using UnityEngine;

namespace Rewards
{
    public class Coin : BaseReward
    {
        [SerializeField] private uint countReward;
        [SerializeField] private ParticleSystem particle;

        protected override void CollidedPlayer()
        {
            Debug.Log("Add reward");
            gameObject.SetActive(false);
        }
    }
}