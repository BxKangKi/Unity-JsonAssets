using UnityEngine;

namespace JsonAssets {
    public static class MeshAssetUtility {

#if UNITY_EDITOR
        public static MeshAsset SaveMesh(Mesh value) {
            MeshAsset result = new MeshAsset();
            result.vertices = value.vertices;
            result.normals = value.normals;
            result.tangents = value.tangents;
            result.triangles = value.triangles;
            result.uv = value.uv;
            result.uv2 = value.uv2;
            result.uv3 = value.uv3;
            result.uv4 = value.uv4;
            result.uv5 = value.uv5;
            result.uv6 = value.uv6;
            result.uv7 = value.uv7;
            result.uv8 = value.uv8;
            result.colors = value.colors;
            result.colors32 = value.colors32;
            return result;
        }
#endif

        public static Mesh LoadMesh(MeshAsset value) {
            Mesh result = new Mesh();
            if (value.vertices != null) result.vertices = value.vertices;
            if (value.normals != null) result.normals = value.normals;
            if (value.tangents != null) result.tangents = value.tangents;
            if (value.triangles != null) result.triangles = value.triangles;
            if (value.uv != null) result.uv = value.uv;
            if (value.uv2 != null) result.uv2 = value.uv2;
            if (value.uv3 != null) result.uv3 = value.uv3;
            if (value.uv4 != null) result.uv4 = value.uv4;
            if (value.uv5 != null) result.uv5 = value.uv5;
            if (value.uv6 != null) result.uv6 = value.uv6;
            if (value.uv7 != null) result.uv7 = value.uv7;
            if (value.uv8 != null) result.uv8 = value.uv8;
            if (value.colors != null) result.colors = value.colors;
            if (value.colors32 != null) result.colors32 = value.colors32;
            result.Optimize();
            result.RecalculateBounds();
            result.RecalculateNormals();
            result.RecalculateTangents();
            result.UploadMeshData(true);
            return result;
        }
    }
}