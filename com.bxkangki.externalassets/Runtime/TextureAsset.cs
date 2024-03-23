using UnityEngine;

namespace ExternalAssets
{
    [System.Serializable]
    public class TextureAsset : ExternalAsset
    {
        public string name = null;
        public byte[] data = null;
        public string extension = TextureAssetUtility.BaseExtension;
        public int width = 1024;
        public int height = 1024;
        public TextureFormat textureFormat = TextureFormat.RGBA32;
        public int mipCount = -1;
        public bool linear = false;
    }
}
