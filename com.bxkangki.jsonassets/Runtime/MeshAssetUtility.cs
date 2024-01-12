using System.Collections.Generic;
using UnityEngine;

namespace JsonAssets {
    public static class MeshAssetUtility {
        private static readonly Dictionary<string, MeshCache> caches = new Dictionary<string, MeshCache>();

        public static void Clear() {
            caches.Clear();
        }

        public static MeshAsset SaveMesh(Mesh value) {
            MeshAsset result = new MeshAsset
            {
                vertices = value.vertices,
                normals = value.normals,
                tangents = value.tangents,
                triangles = value.triangles,
                uv = value.uv,
                uv2 = value.uv2,
                uv3 = value.uv3,
                uv4 = value.uv4,
                uv5 = value.uv5,
                uv6 = value.uv6,
                uv7 = value.uv7,
                uv8 = value.uv8,
                colors = value.colors,
                colors32 = value.colors32,
                name = value.name,
                UUID = System.Guid.NewGuid().ToString()
            };
            return result;
        }

        public static Mesh LoadMesh(MeshAsset value) {
            Mesh result = null;
            if (caches.ContainsKey(value.UUID)) {
                caches[value.UUID].Refer();
                result = caches[value.UUID].Value;
            } else {
                result = new Mesh
                {
                    name = value.name
                };
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
                caches.Add(value.UUID, new MeshCache(result));
            }
            return result;
        }
    }
}