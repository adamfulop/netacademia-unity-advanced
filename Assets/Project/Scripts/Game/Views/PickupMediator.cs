using strange.extensions.mediation.impl;
using WonderGame.Game.Signals;

namespace WonderGame.Game.Views {
    public class PickupMediator : Mediator {
        [Inject]
        public Pickup Pickup { get; set; }
        
        [Inject]
        public CollectPickupSignal CollectPickupSignal { get; set; }
        
        [Inject]
        public RegisterPickupSignal RegisterPickupSignal { get; set; }

        public override void OnRegister() {
            Pickup.PickupCollectedSignal.AddListener(OnPickupCollected);
            Pickup.RegisterPickupSignal.AddListener(OnRegisterPickup);
        }

        private void OnRegisterPickup() {
            RegisterPickupSignal.Dispatch();
        }

        public override void OnRemove() {
            Pickup.PickupCollectedSignal.RemoveListener(OnPickupCollected);
        }
        
        private void OnPickupCollected() {
            CollectPickupSignal.Dispatch();
        }
    }
}