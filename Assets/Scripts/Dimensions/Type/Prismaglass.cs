using System;
using Cysharp.Threading.Tasks;
using Enums;
using Interfaces;
using Obstacles;
using Rewards;
using UnityEngine;
using Zenject;

namespace Dimensions.Type
{
    // отвечает за построение уровня, спаун объектов (бонусы и препятсвия), эффекты и все.. 
    public class Prismaglass : IDimensions
    {
        private float _counter;
        private bool _isSpawn;
        
        private Spawner.Spawner _spawner;

        private readonly Settings _settings;
        private readonly DiContainer _diContainer;
        private readonly SignalBus _signal;

        public Prismaglass(Settings settings, DiContainer diContainer, SignalBus signal)
        {
            _settings = settings;
            _diContainer = diContainer;
            _signal = signal;
        }

        public void Loading() // загрузка прафабов получение нужных объектов и т.д
        {
            var prefab = _diContainer.InstantiatePrefab(_settings.DimensionsPrefab);
            _spawner = prefab.GetComponentInChildren<Spawner.Spawner>();
            
            _spawner.SetSpeeds(_settings.StartSpeed, _settings.TimeSpawn);
            _spawner.SetRewards(_settings.CoinPrefab);
            _spawner.SetObstacles();
        }

        public async void StartSpawn()
        {
            _isSpawn = true;
            await UniTask.Delay(TimeSpan.FromSeconds(_settings.DelayStartSpawn));
            
            while (_isSpawn)
            {
                await _spawner.CreateCoinsVertical(5, PointType.Center);
                await _spawner.CreateCoinsVertical(5, PointType.Right);
                await _spawner.CreateCoinsVertical(5, PointType.Left);

                if (!_isSpawn)
                    _spawner.FinishTrigger.Init(_settings.StartSpeed);
            }
        }

        public void Update() // подсчет пройденого time, увеличение скорости и т.д
        {
            _counter += Time.deltaTime;

            if (!(_counter >= _settings.LevelPlayTime)) return;
            
            Debug.Log("Spawn FinishTrigger");
            _isSpawn = false;
        }
        

        public void Close() // чистка
        {
            
        }
        
        
        [Serializable]
        public class Settings
        {
            [Header("Main Settings")]
            [SerializeField] private float levelPlayTime; // приблизительное время когда уровень будет закончен 
            [SerializeField] private float startSpeed; // начальная скорость уровня 
            [SerializeField] private int countShards; // сколько нужно собрать осколков чтоб закончить уровень
            [SerializeField] private int countAddSpeed; // сколько раз будет увечиливаться скорость 

            [Header("Spawner Settings")] // тут нужно придумать последовательность спауна объектов или это будет тип под рандом или какае-то последовательность 
            [SerializeField] private float delayStartSpawn;
            [SerializeField] private float timeSpawn;

            [Header("Prefabs")]
            [SerializeField] private GameObject dimensionsPrefab;
            [SerializeField] private BaseReward coinPrefab;
            [SerializeField] private BaseObstacles obstaclesPrefab;
            
            public GameObject DimensionsPrefab => dimensionsPrefab;
            public BaseObstacles ObstaclesPrefab => obstaclesPrefab;
            public BaseReward CoinPrefab => coinPrefab;

            public float StartSpeed => startSpeed;
            public float TimeSpawn => timeSpawn;
            public float DelayStartSpawn => delayStartSpawn;
            public int CountShards => countShards;
            public float LevelPlayTime => levelPlayTime;
            public int CountAddSpeed => countAddSpeed;

            
        }
    }
}