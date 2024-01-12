using UnityEngine;

namespace JsonAssets {
    public class MeshCache : AssetCache {
        private Mesh value;

        public MeshCache(Mesh mesh) {
            this.value = mesh;
            Refer();
        }
        public Mesh Value { get { return value; } }

        protected override void Unload() {
            this.value = null;
        }
    }
}