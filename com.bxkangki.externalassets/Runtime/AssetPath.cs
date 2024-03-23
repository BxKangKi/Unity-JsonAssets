using UnityEditor.VersionControl;

namespace ExternalAssets
{
    public struct AssetPath
    {
        public static string Prefab = null;

        public static string GetPrefabPath(string UUID)
        {
            return string.Format("{0}{1}.{2}", UUID, AssetExtension.Prefab);
        }
    }
}
