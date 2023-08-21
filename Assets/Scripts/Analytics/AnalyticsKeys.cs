using System.Collections.Generic;
using UnityEngine;

namespace Metrics
{
    public class AnalyticsKeys : MonoBehaviour
    {
        [SerializeField] 
        private GameOver _gameOver;
        [SerializeField]
        private AbstractMetrics _metrics;

        public void GameOverAnalytic()
        {
            var eventOptions = new Dictionary<string, string>
            {
                { "DeathCount", _gameOver.deadCount.ToString() }
            };
            _metrics.Send("gameOver" + eventOptions);
        }
        
    }
}