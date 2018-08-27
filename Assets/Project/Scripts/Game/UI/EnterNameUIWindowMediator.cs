using strange.extensions.mediation.impl;
using WonderGame.Game.Signals;

namespace WonderGame.Game.UI {
    public class EnterNameUIWindowMediator : Mediator {
        [Inject]
        public EnterNameUIWindow EnterNameUIWindow { get; set; }
        
        [Inject]
        public PlayerLostSignal PlayerLostSignal { get; set; }
        
        [Inject]
        public PlayerNameSubmittedSignal PlayerNameSubmittedSignal { get; set; }

        public override void OnRegister() {
            EnterNameUIWindow.OnSubmitClickSignal.AddListener(OnSubmitClick);
            PlayerLostSignal.AddListener(OnPlayerLost);
        }

        public override void OnRemove() {
            EnterNameUIWindow.OnSubmitClickSignal.RemoveListener(OnSubmitClick);
            PlayerLostSignal.RemoveListener(OnPlayerLost);
        }

        private void OnPlayerLost(int score) {
            EnterNameUIWindow.Show(score);
        }

        private void OnSubmitClick(string playerName) {
            PlayerNameSubmittedSignal.Dispatch(playerName);
        }
    }
}