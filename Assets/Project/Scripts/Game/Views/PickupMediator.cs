using strange.extensions.mediation.impl;
using WonderGame.Game.Signals;

namespace WonderGame.Game.Views {
    public class PickupMediator : Mediator {
        [Inject]
        public Pickup Pickup { get; set; }
        
        [Inject]
        public CollectPickupSignal CollectPickupSignal { get; set; }

        public override void OnRegister() {
            Pickup.PickupCollectedSignal.AddListener(OnPickupCollected);
        }

        public override void OnRemove() {
            Pickup.PickupCollectedSignal.RemoveListener(OnPickupCollected);
        }
        
        private void OnPickupCollected() {
            CollectPickupSignal.Dispatch();
        }
    }
}