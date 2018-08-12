using UnityEngine;
using WonderGame.HighScores;
using Zenject;

namespace WonderGame.Common.Settings {
    [CreateAssetMenu(fileName = "App Settings", menuName = "WonderGame/App Settings")]
    public class AppSettings : ScriptableObjectInstaller<AppSettings> {
        public HighScoresSettings HighScoresSettings;
        
        public override void InstallBindings() {
            Container.BindInstance(HighScoresSettings);
        }
    }
}