using UnityEngine;

namespace JsonAssets {
    [System.Serializable]
    public class MeshAsset {
        public int index;
        public Vector3[] vertices;
        public Vector3[] normals;
        public Vector4[] tangents;
        public int[] triangles;
        public Vector2[] uv;
        public Vector2[] uv2;
        public Vector2[] uv3;
        public Vector2[] uv4;
        public Vector2[] uv5;
        public Vector2[] uv6;
        public Vector2[] uv7;
        public Vector2[] uv8;
        public Color[] colors;
        public Color32[] colors32;
    }
}
