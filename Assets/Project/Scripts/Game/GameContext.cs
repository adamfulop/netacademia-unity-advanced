﻿using Newtonsoft.Json;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;
using WonderGame.Game.Controller;
using WonderGame.Game.Models;
using WonderGame.Game.Signals;
using WonderGame.Game.Views;
using WonderGame.Game.Views.Character;
using WonderGame.Game.Views.Enemy;
using WonderGame.Settings;

namespace WonderGame.Game {
    public class GameContext : MVCSContext {
        public GameContext(MonoBehaviour view) : base(view) { }

        protected override void addCoreComponents() {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        public override IContext Start() {
            base.Start();

            var startSignal = injectionBinder.GetInstance<StartSignal>();
            startSignal.Dispatch();
            
            return this;
        }

        protected override void mapBindings() {
            commandBinder.Bind<CatchPlayerSignal>().To<CatchPlayerCommand>();
            commandBinder.Bind<CollectPickupSignal>().To<CollectPickupCommand>();
            commandBinder.Bind<StartSignal>().To<StartCommand>().Once();

            injectionBinder.Bind<GameSettings>()
                .ToValue(JsonConvert.DeserializeObject<GameSettings>(PlayerPrefs.GetString("GameSettings", "{}")))
                .ToSingleton();

            injectionBinder.Bind<GameState>().ToSingleton();
            injectionBinder.Bind<PlayerInventory>().ToSingleton();

            injectionBinder.Bind<MoveUpdateSignal>().ToSingleton();
            injectionBinder.Bind<PlayerLostSignal>().ToSingleton();
            injectionBinder.Bind<PlayerWonSignal>().ToSingleton();

            mediationBinder.Bind<CharacterAnimation>().To<CharacterAnimationMediator>();
            mediationBinder.Bind<CharacterAudio>().To<CharacterAudioMediator>();
            mediationBinder.Bind<CharacterMove>().To<CharacterMoveMediator>();
            
            mediationBinder.Bind<EnemyCatchPlayer>().To<EnemyCatchPlayerMediator>();
            mediationBinder.Bind<EnemyAudio>().To<EnemyAudioMediator>();

            mediationBinder.Bind<Pickup>().To<PickupMediator>();
        }
    }
}