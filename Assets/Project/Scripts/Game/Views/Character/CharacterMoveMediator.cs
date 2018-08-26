using strange.extensions.mediation.impl;
using WonderGame.Game.Signals;

namespace WonderGame.Game.Views.Character {
    public class CharacterMoveMediator : Mediator {
        [Inject]
        public CharacterMove CharacterMove { get; set; }

        [Inject]
        public MoveUpdateSignal MoveUpdateSignal { get; set; }
        
        public override void OnRegister() {
            CharacterMove.MoveUpdateSignal.AddListener(OnMoveUpdate);
        }

        public override void OnRemove() {
            CharacterMove.MoveUpdateSignal.RemoveListener(OnMoveUpdate);
        }
        
        private void OnMoveUpdate(bool isMoving) {
            MoveUpdateSignal.Dispatch(isMoving);
        }
    }
}