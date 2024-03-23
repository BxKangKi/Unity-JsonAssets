namespace ExternalAssets
{
    [System.Serializable]
    public class PhysicsAsset : ExternalAsset
    {
        public float mass = 1f;
        public bool isKinematic = true;
        public float drag = 0f;
        public float angularDrag = 0.05f;
        public bool useGravity = false;
        public bool water = false;
        public float density = 1000f;
        public float offset = 0f;
    }
}