using MixarTest2.Configs;
using MixarTest2.Controllers;
using MixarTest2.Models;
using MixarTest2.Services;
using MixarTest2.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MixarTest2
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private MetroConfig _metroConfig;

        [SerializeField]
        private StationsChooseView _stationsChooseView;

        [SerializeField]
        private PathInfoView _pathInfoView;

        [SerializeField]
        private Transform _schemeParent;

        [SerializeField]
        private StationView _stationPrefab;

        [SerializeField]
        private LineRenderer _linePrefab;

        [SerializeField]
        private LineRenderer _pathLineRenderer;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_metroConfig);
            builder.RegisterInstance(_stationsChooseView);
            builder.RegisterInstance(_pathInfoView);
            builder.RegisterInstance(_stationPrefab);

            builder.Register<MetroModel>(Lifetime.Scoped);
            builder.Register<SchemeModel>(Lifetime.Scoped);
            builder.Register<StationsChooseModel>(Lifetime.Scoped);

            builder.Register<PathFinderService>(Lifetime.Scoped);

            builder.RegisterEntryPoint<MetroController>(Lifetime.Scoped);
            builder.RegisterEntryPoint<SchemeController>(Lifetime.Scoped)
                .WithParameter(_linePrefab)
                .WithParameter(_schemeParent);
            builder.RegisterEntryPoint<StationsChooseController>(Lifetime.Scoped);
            builder.RegisterEntryPoint<PathInfoController>(Lifetime.Scoped);
            builder.RegisterEntryPoint<PathDisplayController>(Lifetime.Scoped)
                .WithParameter(_pathLineRenderer);
            builder.RegisterEntryPoint<StationsHighlightController>(Lifetime.Scoped);
        }
    }
}