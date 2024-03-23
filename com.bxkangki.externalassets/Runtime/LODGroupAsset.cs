namespace ExternalAssets
{
    [System.Serializable]
    public class LODGroupAsset : ExternalAsset
    {
        public int lodCounts;
#if IMPOSTERS
        public ImposterAsset imposter = null;
#endif
        public LODAsset[] LODs = null;
    }
}