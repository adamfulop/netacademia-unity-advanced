using strange.extensions.mediation.impl;
using UnityEngine;

// zombi hangjáért felelős komponens
namespace WonderGame.Game.Views.Enemy {
    public class EnemyAudio : View {
        [SerializeField] private int _audioInterval = 5;        // milyen sűrűn játszódjon le a hang

        private float _lastAudioPlayTime;    // mikor játszódott le utoljára a hang
        private AudioSource _audioSource;
        private bool _isAudioEnabled;

        protected override void Awake() {
            base.Awake();
            _audioSource = GetComponent<AudioSource>();
        }
        
        public void Initialize(float volume, bool isAudioEnabled) {
            _audioSource.volume = volume;
            _isAudioEnabled = isAudioEnabled;
        }

        private void Update() {
            // ha a jelenlegi idő - utolsó lejátszási idő nagyobb, mint a lejátszási időköz, akkor lejátsszuk újra a hangot
            if (Time.time - _lastAudioPlayTime > _audioInterval && _isAudioEnabled) {
                _lastAudioPlayTime = Time.time;
                _audioSource.Play();
            }
        }
    }
}
