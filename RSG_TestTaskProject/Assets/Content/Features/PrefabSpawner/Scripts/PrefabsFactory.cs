using Core.AssetLoaderModule.Core.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.PrefabSpawner {
    public class PrefabsFactory : IPrefabsFactory {
        private readonly IAddressablesAssetLoaderService _addressablesAssetLoaderService;
        private readonly DiContainer _diContainer;

        public PrefabsFactory(IAddressablesAssetLoaderService addressablesAssetLoaderService, DiContainer diContainer) {
            _addressablesAssetLoaderService = addressablesAssetLoaderService;
            _diContainer = diContainer;
        }

        public GameObject Create(string prefabName) {
            GameObject prefab = _addressablesAssetLoaderService.LoadAsset<GameObject>(prefabName);
            return _diContainer.InstantiatePrefab(prefab);
        }

        public GameObject Create(string prefabName, Transform parent) {
            GameObject prefab = _addressablesAssetLoaderService.LoadAsset<GameObject>(prefabName);
            return _diContainer.InstantiatePrefab(prefab, parent);
        }

        public GameObject Create(string prefabName, Vector3 position) {
            GameObject prefab = _addressablesAssetLoaderService.LoadAsset<GameObject>(prefabName);
            return _diContainer.InstantiatePrefab(prefab, position, Quaternion.identity, null);
        }

        public GameObject Create(string prefabName, Vector3 position, Quaternion rotation) {
            GameObject prefab = _addressablesAssetLoaderService.LoadAsset<GameObject>(prefabName);
            return _diContainer.InstantiatePrefab(prefab, position, rotation, null);
        }

        public GameObject Create(string prefabName, Vector3 position, Quaternion rotation, Transform parent) {
            GameObject prefab = _addressablesAssetLoaderService.LoadAsset<GameObject>(prefabName);
            return _diContainer.InstantiatePrefab(prefab, position, rotation, parent);
        }
    }
}