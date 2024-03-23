using UnityEngine;

namespace ExternalAssets
{
    [System.Serializable]
    public class ColliderAsset : ExternalAsset
    {
        public string name;
        public ColliderType type;
        public float height;
        public float radius;
        public Vector3 center;
        public Vector3 size;
        public Vector3 localPosition;
        public Quaternion localRotation;
        public MeshAsset mesh = null;
    }
}