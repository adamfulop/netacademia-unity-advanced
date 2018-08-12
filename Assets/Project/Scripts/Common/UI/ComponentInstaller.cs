using UnityEngine.UI;
using Zenject;

namespace WonderGame.Common.UI {
    public class ComponentInstaller : MonoInstaller<ComponentInstaller> {
        public override void InstallBindings() {
            Container.Bind<Button>().FromComponentSibling();
        }
    }
}