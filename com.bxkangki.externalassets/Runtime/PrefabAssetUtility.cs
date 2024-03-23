using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExternalAssets
{
    public readonly struct PrefabAssetUtility
    {
        public static readonly Dictionary<string, PrefabCache> Caches = new Dictionary<string, PrefabCache>();

        public static void Clear()
        {
            Caches.Clear();
        }


        public static void CreateLODGroup(GameObject go, PrefabAsset prefab)
        {
            var group = go.AddComponent<LODGroup>();
            var manager = go.AddComponent<PrefabTextureManager>();
            var lods = new LOD[prefab.lodGroup.lodCounts];
            for (int i = 0; i < lods.Length; i++)
            {
                lods[i].screenRelativeTransitionHeight = prefab.lodGroup.LODs[i].screenRelativeTransitionHeight;
                lods[i].fadeTransitionWidth = prefab.lodGroup.LODs[i].fadeTransitionWidth;
                var renderers = new MeshRenderer[prefab.lodGroup.LODs[i].rendererCounts];
                var rendererAssets = prefab.lodGroup.LODs[i].renderers;
                for (int j = 0; j < renderers.Length; j++)
                {
                    var child = new GameObject(string.Format("{0}_LOD_{1}_{2}", go.name, i, j))
                    {
                        layer = LayerMask.NameToLayer(prefab.layer)
                    };
                    child.transform.SetParent(go.transform);
                    AddMeshFilter(child, rendererAssets[j]);
                    renderers[j] = AddMeshRenderer(child, rendererAssets[j], manager);
                }
                lods[i].renderers = renderers;
            }
            group.SetLODs(lods);
        }



        public static MeshRenderer AddMeshRenderer(GameObject go, RendererAsset asset, PrefabTextureManager manager)
        {
            var renderer = go.AddComponent<MeshRenderer>();
            var materials = new Material[asset.materials.Length];
            for (int i = 0; i < asset.materials.Length; i++)
            {
                materials[i] = MaterialAssetUtility.LoadMaterial(asset.materials[i], out var textureNames);
                manager.textures.AddRange(textureNames);
            }
            renderer.materials = materials;
            return renderer;
        }



        public static void AddMeshFilter(GameObject go, RendererAsset asset)
        {
            var filter = go.AddComponent<MeshFilter>();
            var mesh = MeshAssetUtility.LoadMesh(asset.mesh);
            filter.mesh = mesh;
        }



        public static void CreateRigidbody(PhysicsAsset asset, GameObject go)
        {
            var rb = go.AddComponent<Rigidbody>();
            rb.mass = asset.mass;
            rb.isKinematic = asset.isKinematic;
            rb.drag = asset.drag;
            rb.angularDrag = asset.drag;
            rb.useGravity = asset.useGravity;
        }


        public static void CreateCollider(PrefabAsset asset, GameObject go)
        {
            for (int i = 0; i < asset.colliders.Length; i++)
            {
                var coll = new GameObject()
                {
                    name = asset.colliders[i].name,
                    layer = LayerMask.NameToLayer(asset.layer)
                };
                switch (asset.colliders[i].type)
                {
                    case ColliderType.Box:
                        var box = coll.AddComponent<BoxCollider>();
                        box.size = asset.colliders[i].size;
                        box.center = asset.colliders[i].center;
                        break;
                    case ColliderType.Capsule:
                        var capsule = coll.AddComponent<CapsuleCollider>();
                        capsule.radius = asset.colliders[i].radius;
                        capsule.height = asset.colliders[i].height;
                        capsule.center = asset.colliders[i].center;
                        break;
                    case ColliderType.Sphere:
                        var sphere = coll.AddComponent<SphereCollider>();
                        sphere.radius = asset.colliders[i].radius;
                        sphere.center = asset.colliders[i].center;
                        break;
                    case ColliderType.Mesh:
                        var mesh = coll.AddComponent<MeshCollider>();
                        mesh.sharedMesh = MeshAssetUtility.LoadMesh(asset.colliders[i].mesh);
                        break;
                }
                coll.transform.SetLocalPositionAndRotation(asset.colliders[i].localPosition, asset.colliders[i].localRotation);
                coll.transform.SetParent(go.transform);
            }

        }
    }
}