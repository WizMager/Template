using Providers.GameFieldProvider;
using Providers.GameFieldProvider.Impl;
using Utils;
using Zenject;

namespace Level
{
    public class LevelInstaller : MonoInstaller
    {
        public GameField gameField;

        public override void InstallBindings()
        {
            var gameFieldProvider = new GameFieldProvider(gameField);

            Container.Bind<IGameFieldProvider>().FromInstance(gameFieldProvider).AsSingle();
        }
    }
}