using UnityEngine;

namespace ExternalAssets
{
    [System.Serializable]
    public class PrefabAsset : ExternalAsset
    {
        public string UUID = "";
        public string name = "";
        public string layer = "";
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 localScale;
        public LODGroupAsset lodGroup = null;
        public PhysicsAsset physics = null;
        public ColliderAsset[] colliders = null;
        public PrefabAsset[] children;
    }
}