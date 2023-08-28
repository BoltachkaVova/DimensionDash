using System;
using Cysharp.Threading.Tasks;
using Enums;
using Obstacles;
using Rewards;
using Triggers;
using UnityEngine;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
         private float _timeSpawn;
         private float _speed;

         private BaseReward _coin;
         private BaseObstacles _obstacle;
         private BaseTrigger _finishTrigger;
         
         private Transform[] _points;

         public BaseTrigger FinishTrigger => _finishTrigger;

         private void Awake()
        {
            _points = GetComponentsInChildren<Transform>();
            
            _finishTrigger = GetComponentInChildren<FinishTrigger>(true);
        }

        public void SetSpeeds(float speed, float time)
        {
            _speed = speed;
            _timeSpawn = time;
        }

        public void SetObstacles(params BaseObstacles[] obstacles)
        {
            foreach (var obstacle in obstacles)
            {
                _obstacle = obstacle;
            }
        }

        public void SetRewards(params BaseReward[] rewards)
        {
            foreach (var reward in rewards)
            {
                switch (reward)
                {
                    case Coin:
                        _coin = reward;
                        break;
                }
            }
        }

        public async UniTask CreateCoinsVertical(int count, PointType type)
        {
            for (int i = 0; i < count; i++)
            {
                var baseReward = Instantiate(_coin, _points[(int)type].position, Quaternion.identity);
                baseReward.Init(_speed);
                
                await UniTask.Delay(TimeSpan.FromSeconds(_timeSpawn));
            }
        }
        
        public async UniTask CreateRewardsHorizontal(int countHorizontal)
        {
            for (int i = 0; i < countHorizontal; i++)
            {
                foreach (var point in _points)
                {
                    var baseReward = Instantiate(_coin, point.position, Quaternion.identity);
                    baseReward.Init(_speed);
                }
                await UniTask.Delay(TimeSpan.FromSeconds(_timeSpawn));
            }
        }
        
        public void CreateRewardsByArc(Vector3 point, int count) 
        {
            
        }
    }
}