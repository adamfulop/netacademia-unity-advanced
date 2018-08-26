using strange.extensions.context.impl;

namespace WonderGame.Game {
    public class GameRoot : ContextView {
        private void Awake() {
            context = new GameContext(this);
        }
    }
}