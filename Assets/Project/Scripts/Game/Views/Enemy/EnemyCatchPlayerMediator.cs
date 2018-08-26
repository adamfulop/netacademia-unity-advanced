using strange.extensions.mediation.impl;
using WonderGame.Game.Signals;

namespace WonderGame.Game.Views.Enemy {
    public class EnemyCatchPlayerMediator : Mediator {
        [Inject]
        public EnemyCatchPlayer EnemyCatchPlayer { get; set; }
        
        [Inject]
        public CatchPlayerSignal CatchPlayerSignal { get; set; }

        public override void OnRegister() {
            EnemyCatchPlayer.CatchPlayerSignal.AddListener(OnCatchPlayer);
        }
        
        public override void OnRemove() {
            EnemyCatchPlayer.CatchPlayerSignal.RemoveListener(OnCatchPlayer);
        }
        
        private void OnCatchPlayer() {
            CatchPlayerSignal.Dispatch();
        }
    }
}