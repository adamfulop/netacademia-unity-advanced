using strange.extensions.mediation.impl;
using WonderGame.Settings;

namespace WonderGame.Game.Views.Enemy {
    public class EnemyAudioMediator : Mediator {
        [Inject]
        public EnemyAudio EnemyAudio { get; set; }
        
        [Inject]
        public GameSettings GameSettings { get; set; }

        public override void OnRegister() {
            EnemyAudio.Initialize(GameSettings.Volume, GameSettings.IsAudioEnabled);
        }
    }
}