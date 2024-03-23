namespace ExternalAssets
{
    [System.Serializable]
    public class LODAsset : ExternalAsset
    {
        public int level;
        public int rendererCounts;
        public float screenRelativeTransitionHeight;
        public float fadeTransitionWidth;
        public RendererAsset[] renderers = null;
    }
}