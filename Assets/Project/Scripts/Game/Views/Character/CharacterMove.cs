using System;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace WonderGame.Game.Views.Character {
    public class CharacterMove : View {
        [SerializeField] private CharacterSettings _characterSettings;
        public Signal<bool> MoveUpdateSignal = new Signal<bool>();
        
        private Rigidbody _rigidbody;
        
        private Vector3 _movement;
        private const float Tolerance = 0.01f;
    
        // más komponensek referenciáinak inicializálása
        // (sima GetComponent<>() -> ugyanazon a GameObjecten keressük a komponenseket)
        protected override void Awake() {
            base.Awake();
            
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {
            // vízszintes és függőleges input tengely értékeinek elkérése (-1 és 1 közötti érték)
            // tengelyek leképzése alapból a nyilak vagy WASD
            // Lásd Edit -> Project Settings -> Input
            var inputVertical = Input.GetAxis("Vertical");
            var inputHorizontal = Input.GetAxis("Horizontal");

            Move(inputHorizontal, inputVertical);
            
            MoveUpdateSignal.Dispatch(IsMoving(inputHorizontal, inputVertical));
        }

        private void Move(float inputHorizontal, float inputVertical) {
            // a _movement az elmozdulás vektor az aktuális updateben
            // skálázzuk a sebességgel (Speed) és az előző update óta eltelt idővel (Time.deltaTime)
            _movement.Set(inputHorizontal, 0, inputVertical);
            _movement = _movement.normalized * _characterSettings.Speed * Time.deltaTime;
            // alkalmazzuk az elmozdulást
            _rigidbody.MovePosition(transform.position + _movement);

            if (IsMoving(inputHorizontal, inputVertical)) {    // "== 0" helyett "> tolerance", mert float
                // ha valamelyik input nem 0, akkor forgatunk is
                Rotate(inputHorizontal, inputVertical);
            }
        }

        // true, ha épp mozog a játékos (legalább egyik input nem 0), egyébként false
        private static bool IsMoving(float inputHorizontal, float inputVertical) {
            return Math.Abs(inputHorizontal) > Tolerance || Math.Abs(inputVertical) > Tolerance;
        }

        private void Rotate(float inputHorizontal, float inputVertical) {
            // Quaternion részletesebb információ: https://docs.unity3d.com/ScriptReference/Quaternion.html
            // Matematikai alapok: https://hu.wikipedia.org/wiki/Kvaterni%C3%B3k
            var targetDirection = new Vector3(inputHorizontal, 0, inputVertical);             // cél irány
            var targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);        // cél orientáció
            // interpolálunk a jelenlegi és cél orientáció között (3. paraméter 0-1 közötti szám kell legyen, hogy épp "hol tartunk" a fordulásban)
            var newRotation = Quaternion.Lerp(_rigidbody.rotation, targetRotation, Time.deltaTime * _characterSettings.TurnSmoothing);
            // alkalmazzuk az elfordulást
            _rigidbody.MoveRotation(newRotation);
        }
    }
}
