using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;
using WonderGame.UI.Common;

namespace WonderGame.Game.UI {
    public class EnterNameUIWindow : UIWindow {
        [SerializeField] private Text _scoreText;
        [SerializeField] private InputField _nameInputField;

        public Signal<string> OnSubmitClickSignal = new Signal<string>();
        
        public void Show(int score) {
            base.Show();
            _scoreText.text = $"You have gained {score} points.";
        }

        public void OnSubmitClick() {
            var playerName = _nameInputField.text;

            // ha nem üres string a játékos neve, akkor létrehozunk egy bejegyzést a high scores listába
            if (!string.IsNullOrEmpty(playerName)) {
                OnSubmitClickSignal.Dispatch(playerName);
            } 
        }
    }
}
