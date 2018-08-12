using UnityEngine;
using Zenject;
#pragma warning disable 649

namespace WonderGame.HighScores {
    public class HighScoresInstaller : MonoInstaller<HighScoresInstaller> {
        [Inject] private HighScoresSettings _highScoresSettings;
        
        public override void InstallBindings() {
            Container.BindInterfacesAndSelfTo<HighScoresUIController>().AsSingle();
            
            Container.BindFactory<Transform, ScoreRecord, UIScoreRecord, UIScoreRecord.Factory>()
                .FromComponentInNewPrefab(_highScoresSettings.UIScoreRecordPrefab);
        }
    }
}