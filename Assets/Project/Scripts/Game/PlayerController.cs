using Cinemachine;
using UnityEngine;

namespace WonderGame.Game {
    public class PlayerController : MonoBehaviour {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private GameObject _playerPrefab;
        
        private void Start() {
            // játékos létrehozása, kamera beállítása a játékosra
            var player = Instantiate(_playerPrefab);
            _virtualCamera.Follow = player.transform;
            _virtualCamera.LookAt = player.transform;
        }
    }
}