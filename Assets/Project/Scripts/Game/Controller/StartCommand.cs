using strange.extensions.command.impl;
using UnityEngine;
using WonderGame.Settings;

namespace WonderGame.Game.Controller {
    public class StartCommand : Command {
        [Inject]
        public GameSettings GameSettings { get; set; }
        
        public override void Execute() {
            Debug.Log("Initializing graphics...");
            QualitySettings.SetQualityLevel(2 * GameSettings.GraphicsQuality, true);
            if (GameSettings.IsAdvancedGraphicsEnabled) {
                QualitySettings.antiAliasing = GameSettings.AntiAliasingLevel;
            }
        }
    }
}