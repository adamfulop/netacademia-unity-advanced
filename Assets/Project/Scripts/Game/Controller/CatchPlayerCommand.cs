using strange.extensions.command.impl;
using UnityEngine;
using WonderGame.Game.Models;
using WonderGame.Game.Signals;

namespace WonderGame.Game.Controller {
    public class CatchPlayerCommand : Command {
        [Inject]
        public GameState GameState { get; set; }
        
        [Inject]
        public PlayerInventory PlayerInventory { get; set; }
        
        [Inject]
        public PlayerLostSignal PlayerLostSignal { get; set; }
        
        public override void Execute() {
            if (PlayerInventory.PickupCount > 0) {
                PlayerInventory.PickupCount--;
            }

            if (GameState.RemainingPickupsCount < GameState.WinThreshold - PlayerInventory.PickupCount) {
                var score = Mathf.Max(0, 
                    Mathf.RoundToInt(PlayerInventory.PickupCount * 1000 - Time.timeSinceLevelLoad * 10));
                PlayerLostSignal.Dispatch(score);
            }
        }
    }
}