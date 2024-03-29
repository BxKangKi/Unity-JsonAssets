using System.Collections.Generic;
using UnityEngine;

namespace ExternalAssets
{
    public struct TextureAssetUtility
    {
        public const int BaseTextureSize = 2048;
        public const string BaseExtension = "png";

        private static readonly Dictionary<string, TextureCache> caches = new Dictionary<string, TextureCache>();

        public static void Clear()
        {
            caches.Clear();
        }


        public static void Log()
        {
            var keys = new string[caches.Count];
            caches.Keys.CopyTo(keys, 0);
            Debug.Log("Current Refer Counts");
            for (int i = 0; i < caches.Count; i++)
            {
                int count = caches[keys[i]].ReferCount;
                Debug.Log(string.Format("{0}: {1}", keys[i], count));
            }
        }


        public static Texture2D LoadTexture(TextureAsset asset)
        {
            if (caches.ContainsKey(asset.name))
            {
                caches[asset.name].Refer();
                return caches[asset.name].Value;
            }
            var tex = new Texture2D(asset.width, asset.height, asset.textureFormat, asset.mipCount, asset.linear);
            ImageConversion.LoadImage(tex, asset.data); //..this will auto-resize the texture dimensions.
            tex.Compress(false);
            tex.Apply(true, true);
            caches.Add(asset.name, new TextureCache(tex));
            return tex;
        }


        public static TextureAsset SaveTexture(Texture2D tex, TextureFormat f = TextureFormat.RGBA32, int m = -1, bool l = false)
        {
            var result = new TextureAsset
            {
                name = tex.name,
                data = tex.GetRawTextureData(),
                width = tex.width,
                height = tex.height,
                textureFormat = f,
                mipCount = m,
                linear = l
            };
            return result;
        }


        public static void ReferTexture(string name)
        {
            if (caches.ContainsKey(name))
            {
                caches[name].Refer();
            }
        }


        public static void RemoveTexture(string name)
        {
            if (caches.ContainsKey(name))
            {
                var cache = caches[name];
                caches.Remove(name);
                cache.Return();
            }
        }
    }
}
