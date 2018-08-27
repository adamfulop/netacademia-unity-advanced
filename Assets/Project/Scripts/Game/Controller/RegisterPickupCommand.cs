using strange.extensions.command.impl;
using WonderGame.Game.Models;

namespace WonderGame.Game.Controller {
    public class RegisterPickupCommand : Command {
        [Inject]
        public GameState GameState { get; set; }
        
        public override void Execute() {
            GameState.RemainingPickupsCount++;
        }
    }
}