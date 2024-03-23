using UnityEngine;

namespace ExternalAssets
{
    public class PrefabCache : AssetCache
    {
        private GameObject value;

        public PrefabCache(GameObject go)
        {
            this.value = go;
            Refer();
        }

        public GameObject Value { get { return value; } }

        protected override void Unload()
        {
            this.value = null;
        }
    }
}