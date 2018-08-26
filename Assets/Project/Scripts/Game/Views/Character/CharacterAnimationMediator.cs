using strange.extensions.mediation.impl;
using WonderGame.Game.Signals;

namespace WonderGame.Game.Views.Character {
    public class CharacterAnimationMediator : Mediator {
        [Inject]
        public CharacterAnimation CharacterAnimation { get; set; }
        
        [Inject]
        public MoveUpdateSignal MoveUpdateSignal { get; set; }

        public override void OnRegister() {
            MoveUpdateSignal.AddListener(OnMoveUpdate);
        }

        public override void OnRemove() {
            MoveUpdateSignal.RemoveListener(OnMoveUpdate);
        }
        
        private void OnMoveUpdate(bool isMoving) {
            CharacterAnimation.UpdateAnimation(isMoving);
        }
    }
}