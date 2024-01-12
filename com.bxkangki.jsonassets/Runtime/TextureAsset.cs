using UnityEngine;

namespace JsonAssets {
    [System.Serializable]
    public class TextureAsset : JsonAsset {
        public string name = null;
        public string extension = TextureAssetUtility.BaseExtension;
        public int width = 2048;
        public int height = 2048;
        public TextureFormat textureFormat = TextureFormat.RGBA32;
        public int mipCount = -1;
        public bool linear = false;

        public TextureAsset (string n, string ext = TextureAssetUtility.BaseExtension, int w = TextureAssetUtility.BaseTextureSize, int h = TextureAssetUtility.BaseTextureSize, TextureFormat f = TextureFormat.RGBA32, int m = -1, bool l = false) {
            this.name = n;
            this.extension = ext;
            this.width = w;
            this.height = h;
            this.textureFormat = f;
            this.mipCount = m;
            this.linear = l;
        }
    }
}
