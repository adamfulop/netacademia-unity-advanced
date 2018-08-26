namespace WonderGame.Game.Models {
    public class GameState {
        public int RemainingPickupsCount { get; set; }
        public int WinThreshold { get; set; }

        public GameState() {
            WinThreshold = 8;
        }
    }
}