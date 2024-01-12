using UnityEngine;

namespace JsonAssets {
    public class MaterialCache : AssetCache {
        private Material value;

        public MaterialCache(Material material) {
            this.value = material;
            Refer();
        }
        public Material Value { get { return value; } }

        protected override void Unload() {
            this.value = null;
        }
    }
}