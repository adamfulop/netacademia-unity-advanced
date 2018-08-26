using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace WonderGame.Game.Views.Enemy {
    public class EnemyCatchPlayer : View {
        public Signal CatchPlayerSignal = new Signal();
        
        private void OnTriggerEnter(Collider other) {
            // ha elkapott egy játékost (= ütközött egy játékos taggel rendelkező colliderrel)
            // a játékostól elveszünk egy pontot
            if (other.CompareTag("Player")) {
                CatchPlayerSignal.Dispatch();
                Debug.Log("Zombie elkapta a játékost!");
            }
        }
    }
}