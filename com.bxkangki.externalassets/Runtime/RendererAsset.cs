namespace ExternalAssets
{
    [System.Serializable]
    public class RendererAsset : ExternalAsset
    {
        public MeshAsset mesh = null;
        public MaterialAsset[] materials = null;
    }
}