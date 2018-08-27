using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using strange.extensions.command.impl;
using UnityEngine;
using WonderGame.Game.Models;
using WonderGame.UI.HighScores;

namespace WonderGame.Game.Controller {
    public class RegisterPlayerHighScoreCommand : Command {
        [Inject]
        public GameState GameState { get; set; }

        [Inject]
        public string PlayerName { get; set; }

        public override void Execute() {
            var newRecord = new ScoreRecord {Name = PlayerName, Score = GameState.FinalScore};
            var highScores = JsonConvert
                .DeserializeObject<List<ScoreRecord>>(PlayerPrefs.GetString("highScores", "[]"));
            highScores.Add(newRecord);
            highScores = highScores
                .OrderByDescending(r => r.Score)
                .ToList();

            PlayerPrefs.SetString("highScores", JsonConvert.SerializeObject(highScores));
        }
    }
}