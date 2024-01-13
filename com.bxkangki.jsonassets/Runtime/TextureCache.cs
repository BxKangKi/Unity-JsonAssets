using UnityEngine;

namespace JsonAssets {
    public class TextureCache : AssetCache {
        private Texture2D value;

        public TextureCache(Texture2D tex) {
            this.value = tex;
        }
        public Texture2D Value { get { return value; } }

        protected override void Unload() {
            this.value = null;
        }
    }
}