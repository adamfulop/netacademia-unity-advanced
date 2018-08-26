using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace WonderGame.Game {
	public class Pickup : View {
		public Signal PickupCollectedSignal = new Signal();
		
		// ha egy játékos felveszi (= ütközik vele), akkor a játékos pontszámát növeljük, és deaktiváljuk a pickupot
		private void OnTriggerEnter(Collider other) {
			if (other.CompareTag("Player")) {
				gameObject.SetActive(false);
				PickupCollectedSignal.Dispatch();
			}
		}
	}
}
