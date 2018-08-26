using strange.extensions.mediation.impl;
using UnityEngine;

namespace WonderGame.Game.Views.Character {
    public class CharacterAudio : View {
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

        public void UpdateAnimation(bool isMoving) {
            if (!_isAudioEnabled) return;
            
            // ha mozog a játékos, és épp nem megy a lépés hang, akkor lejátsszuk
            // ha nem mozog a játékos, és épp megy a lépés hang, akkor leállítjuk
            if (isMoving) {
                if (!_audioSource.isPlaying) _audioSource.Play();
            } else {
                if (_audioSource.isPlaying) _audioSource.Stop();
            }
        }
    }
}