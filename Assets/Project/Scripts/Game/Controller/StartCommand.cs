using strange.extensions.command.impl;
using UnityEngine;
using WonderGame.Game.Models;
using WonderGame.Settings;

namespace WonderGame.Game.Controller {
    public class StartCommand : Command {
        [Inject]
        public GameState GameState { get; set; }
        
        [Inject]
        public GameSettings GameSettings { get; set; }
        
        public override void Execute() {
            GameState.IsPlayerAlive = true;
            
            Debug.Log("Initializing graphics...");
            QualitySettings.SetQualityLevel(2 * GameSettings.GraphicsQuality, true);
            if (GameSettings.IsAdvancedGraphicsEnabled) {
                QualitySettings.antiAliasing = GameSettings.AntiAliasingLevel;
            }
        }
    }
}