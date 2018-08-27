using strange.extensions.mediation.impl;
using WonderGame.Game.Signals;

namespace WonderGame.Game.UI {
    public class UIPointsMediator : Mediator {
        [Inject]
        public PlayerScoreChangedSignal PlayerScoreChangedSignal { get; set; }
        
        [Inject]
        public UIPoints UIPoints { get; set; }

        public override void OnRegister() {
            PlayerScoreChangedSignal.AddListener(OnPlayerScoreChanged);
        }

        public override void OnRemove() {
            PlayerScoreChangedSignal.RemoveListener(OnPlayerScoreChanged);
        }

        private void OnPlayerScoreChanged(int score) {
            UIPoints.Points = score;
        }
    }
}