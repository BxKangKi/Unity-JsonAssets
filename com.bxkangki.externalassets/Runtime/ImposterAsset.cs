#if IMPOSTERS
namespace ExternalAssets
{
    [System.Serializable]
    public class ImposterAsset : ExternalAsset
    {
        public bool isStatic;
        public float imposterStartPoint;
    }
}
#endif