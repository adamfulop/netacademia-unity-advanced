using strange.extensions.command.impl;
using WonderGame.Game.Models;
using WonderGame.Game.Signals;

namespace WonderGame.Game.Controller {
    public class CollectPickupCommand : Command {
        [Inject]
        public GameState GameState { get; set; }
        
        [Inject]
        public PlayerInventory PlayerInventory { get; set; }
        
        [Inject]
        public PlayerWonSignal PlayerWonSignal { get; set; }

        public override void Execute() {
            PlayerInventory.PickupCount++;

            if (PlayerInventory.PickupCount > GameState.WinThreshold) {
                PlayerWonSignal.Dispatch();
            }
        }
    }
}