using strange.extensions.mediation.impl;
using UnityEngine.UI;

namespace WonderGame.Game.UI {
    public class UIPoints : View {
        private Slider _slider;

        protected override void Awake() {
            base.Awake();
            _slider = GetComponent<Slider>();
        }

        public int Points {
            set { _slider.value = value; }
        }
    }
}