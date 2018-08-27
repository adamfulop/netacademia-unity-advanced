using System;
using UnityEngine;
using UnityEngine.UI;

namespace WonderGame.Game.UI {
    public class UITimer : MonoBehaviour {
        [SerializeField] private Text _text;

        // kiírjuk az időt PP : MM formátumban
        private void Update() {
            var time = TimeSpan.FromSeconds(Time.timeSinceLevelLoad);
            _text.text = $"{time.Minutes:D2} : {time.Seconds:D2}";
        }
    }
}