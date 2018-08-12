using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
#pragma warning disable 649

namespace WonderGame.HighScores {
    public class UIScoreRecord : MonoBehaviour {
        [SerializeField] private Text _nameText;
        [SerializeField] private Text _scoreText;

        [Inject] private ScoreRecord _scoreRecord;
        [Inject] private Transform _parent;

        private void Start() {
            _nameText.text = _scoreRecord.Name;
            _scoreText.text = _scoreRecord.Score.ToString();
            transform.SetParent(_parent, false);
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<Transform, ScoreRecord, UIScoreRecord> { }
    }
}
