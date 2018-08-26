using UnityEngine;
using UnityEngine.AI;
using WonderGame.Common;

namespace WonderGame.Game.Views.Enemy {
    public class EnemyMove : MonoBehaviour {
        private NavMeshAgent _navMeshAgent;
        private Transform _player;

        private void Awake() {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    
        private void Start() {
            var gameSettingsManager = FindObjectOfType<GameSettingsManager>();
            var difficulty = gameSettingsManager.GameSettings.Difficulty;
            _navMeshAgent.speed *= 1 + 0.1f * difficulty;
        }

        private void Update() {
            // minden pillanatban a játékos pozíciója a célja a zombinak
            _navMeshAgent.SetDestination(_player.position);
        }
    }
}
