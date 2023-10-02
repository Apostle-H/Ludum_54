using Core.Games.Data;
using Input;
using Input.Interactors;
using Input.Interactors.Data;
using Memories;
using Memories.Meta;
using Memories.Puzzle.Data;
using MiniGames.Connect;
using MiniGames.Connect.Data;
using MiniGames.Flipper.Data;
using MiniGames.Repeater;
using MiniGames.Repeater.Data;
using MiniGames.Repeater.Logic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.DI
{
    public class MainScope : LifetimeScope
    {
        [SerializeField] private InteractionsScope interactionsScope;
        [SerializeField] private PuzzleScope puzzleScope;
        [SerializeField] private RepeaterGameScope repeaterGameScope;
        [SerializeField] private ConnectGameScope connectGameScope;
        [SerializeField] private FlipperScope flipperScope;
        [SerializeField] private MiniGamesScope miniGamesScope;

        [SerializeField] private MemoriesGame memoriesGame;
        [SerializeField] private MemoryShower _shower;
        [SerializeField] private MemoryPool _pool;
        
        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureInput(builder);
            ConfigurePuzzle(builder);
            ConfigureRepeaterGame(builder);
            ConfigureConnectGame(builder);
            ConfigureFlipperGame(builder);
            ConfigureMemories(builder);

            builder.RegisterInstance(miniGamesScope.MiniGamesManager);
        }

        private void ConfigureInput(IContainerBuilder builder)
        {
            var inputActions = new MainActions();

            builder.RegisterInstance(inputActions);
            builder.RegisterInstance(inputActions.MouseMap);

            builder.RegisterInstance(interactionsScope.MouseHandlerConfigSO);
            
            builder.Register<MouseHandler>(Lifetime.Singleton);
        }

        private void ConfigurePuzzle(IContainerBuilder builder)
        {
            builder.RegisterInstance(puzzleScope.PuzzlePartConfigSO);
        }

        private void ConfigureRepeaterGame(IContainerBuilder builder)
        {
            builder.RegisterInstance(repeaterGameScope.RepeatedGameSceneConfig);
            builder.RegisterInstance(repeaterGameScope.SequenceManagerConfigSO);
            builder.RegisterInstance(repeaterGameScope.SequenceElementFlasherConfigSO);
            builder.RegisterInstance(repeaterGameScope.ProgressShower);

            builder.Register<SequenceManager>(Lifetime.Singleton);
            builder.Register<RepeaterGame>(Lifetime.Singleton);
        }

        private void ConfigureConnectGame(IContainerBuilder builder)
        {
            builder.RegisterInstance(connectGameScope.ConnectGameSceneConfig);
            builder.RegisterInstance(connectGameScope.ConnectionEndConfigSO);

            builder.Register<ConnectGame>(Lifetime.Singleton);
        }

        private void ConfigureFlipperGame(IContainerBuilder builder)
        {
            builder.RegisterInstance(flipperScope.FlipperGameSceneConfig.FlipperGame);
        }

        private void ConfigureMemories(IContainerBuilder builder)
        {
            builder.RegisterInstance(memoriesGame);
            builder.RegisterInstance(_shower);
            builder.RegisterInstance(_pool);
        }
    }
}