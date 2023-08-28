using System;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
       
        
        private void OnTriggerEnter(Collider other)
        {
            
        }
        
        
        [Serializable]
        public class MainSettings
        { 
           [SerializeField] private uint countCoins;
           [SerializeField] private uint powerLevel; // мощь игрока на разбитие объектов нужно еще продумать как будет добовляться (countBreakObstacle)
           [SerializeField] private uint shards; // осколки (может они будут храниться в BreakObstacle?) 
           [SerializeField] private uint countBreakObstacle;
        }
    }
}