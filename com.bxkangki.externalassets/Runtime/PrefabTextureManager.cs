using System.Collections.Generic;
using UnityEngine;

namespace ExternalAssets
{
    public class PrefabTextureManager : MonoBehaviour
    {
        public readonly List<string> textures = new List<string>();

        private void Start()
        {
            for (int i = 0; i < textures.Count; i++)
            {
                TextureAssetUtility.ReferTexture(textures[i]);
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < textures.Count; i++)
            {
                TextureAssetUtility.RemoveTexture(textures[i]);
            }
        }
    }
}