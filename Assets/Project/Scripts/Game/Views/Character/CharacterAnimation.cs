using strange.extensions.mediation.impl;
using UnityEngine;

namespace WonderGame.Game.Views.Character {
    public class CharacterAnimation : View {
        private Animator _animator;

        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Animator>();
        }

        public void UpdateAnimation(bool isMoving) {
            _animator.SetBool("IsRunning", isMoving);
        }
    }
}