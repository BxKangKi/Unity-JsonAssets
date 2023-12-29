using UnityEngine;
using FileSystem;

namespace JsonAssets {
    [System.Serializable]
    public class TextureAsset {
        public string name = null;
        public int width = 2048;
        public int height = 2048;
        public TextureFormat textureFormat = TextureFormat.RGBA32;
        public int mipCount = -1;
        public bool linear = false;

        public TextureAsset (string n, int w = TextureAssetUtility.BaseTextureSize, int h = TextureAssetUtility.BaseTextureSize, TextureFormat f = TextureFormat.RGBA32, int m = -1, bool l = false) {
            this.name = n;
            this.width = w;
            this.height = h;
            this.textureFormat = f;
            this.mipCount = m;
            this.linear = l;
        }

        public Texture2D Load(string path) {
            Texture2D tex = null;
            byte[] data;
            if (FileIO.CheckFile(path, false)) {
                data = FileIO.ReadAllBytes(path);
                tex = new Texture2D(this.width, this.height, this.textureFormat, this.mipCount, this.linear);
                ImageConversion.LoadImage(tex, data); //..this will auto-resize the texture dimensions.
            }
            return tex;
        }
    }
}
