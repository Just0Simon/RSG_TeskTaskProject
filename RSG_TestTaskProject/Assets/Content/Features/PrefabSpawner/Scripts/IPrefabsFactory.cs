using UnityEngine;

namespace Content.Features.PrefabSpawner {
    public interface IPrefabsFactory {
        public GameObject Create(string prefabName);
        public GameObject Create(string prefabName, Transform parent);
        public GameObject Create(string prefabName, Vector3 position);
        public GameObject Create(string prefabName, Vector3 position, Quaternion rotation);
        public GameObject Create(string prefabName, Vector3 position, Quaternion rotation, Transform parent);
    }
}