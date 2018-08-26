using strange.extensions.mediation.impl;
using WonderGame.Game.Signals;
using WonderGame.Settings;

namespace WonderGame.Game.Views.Character {
    public class CharacterAudioMediator : Mediator {
        [Inject]
        public CharacterAudio CharacterAudio { get; set; }
        
        [Inject]
        public MoveUpdateSignal MoveUpdateSignal { get; set; }
        
        [Inject]
        public GameSettings GameSettings { get; set; }

        public override void OnRegister() {
            MoveUpdateSignal.AddListener(OnMoveUpdate);
            CharacterAudio.Initialize(GameSettings.Volume, GameSettings.IsAudioEnabled);
        }

        public override void OnRemove() {
            MoveUpdateSignal.RemoveListener(OnMoveUpdate);
        }
        
        private void OnMoveUpdate(bool isMoving) {
            CharacterAudio.UpdateAnimation(isMoving);
        }
    }
}