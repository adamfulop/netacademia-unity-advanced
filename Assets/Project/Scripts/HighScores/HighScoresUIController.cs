using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;
using WonderGame.UI.Common;
using Zenject;
#pragma warning disable 649

namespace WonderGame.HighScores {
    [UsedImplicitly]
    public class HighScoresUIController : IInitializable {
        [Inject] private UIScoreRecord.Factory _scoreRecordFactory;
        [Inject(Id = "Content")] private Transform _content;
        [Inject] private UIWindow _window;

        // megjelenítjuk az ablakot, betöltjük és megjelenítjük a pontszámokat
        public void Initialize() {
            _window.Show();
            ShowScores(Scores);
        }

        // pontszámok megjelenítése (1 prefab példány 1 pontszámot jelenít meg)
        private void ShowScores(IEnumerable<ScoreRecord> scores) {
            foreach (var scoreRecord in scores) {
                _scoreRecordFactory.Create(_content, scoreRecord);
            }
        }

        // pontszámok betöltése a PlayerPrefsből (ha még nincs ilyen kulcs, akkor üres JSON tömbre inicializáljuk)
        private List<ScoreRecord> Scores => JsonConvert.DeserializeObject<List<ScoreRecord>>(PlayerPrefs.GetString("highScores", "[]"));
    }
}