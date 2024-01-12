namespace JsonAssets {
    public static class AssetUtility {
        public static void CleanUp() {
            MaterialAssetUtility.Clear();
            MeshAssetUtility.Clear();
            TextureAssetUtility.Clear();
        }
    }
}