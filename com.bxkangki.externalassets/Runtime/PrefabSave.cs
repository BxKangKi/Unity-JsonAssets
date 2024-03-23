using UnityEngine;


namespace ExternalAssets
{
    public struct PrefabSave
    {
        public static void SaveLODGroup(GameObject go, PrefabAsset asset)
        {
            if (go.TryGetComponent<LODGroup>(out var group))
            {
                asset.lodGroup = new LODGroupAsset
                {
                    LODs = new LODAsset[group.lodCount],
                    lodCounts = group.lodCount
                };
                var lods = group.GetLODs();
                for (int i = 0; i < lods.Length; i++)
                {
                    var renderers = lods[i].renderers;
                    asset.lodGroup.LODs[i] = new LODAsset
                    {
                        level = i,
                        screenRelativeTransitionHeight = lods[i].screenRelativeTransitionHeight,
                        fadeTransitionWidth = lods[i].fadeTransitionWidth,
                        renderers = new RendererAsset[renderers.Length],
                        rendererCounts = renderers.Length
                    };

                    for (int j = 0; j < renderers.Length; j++)
                    {
                        asset.lodGroup.LODs[i].renderers[j] = SaveRenderers(renderers[j]);
                    }
                }
            }
        }



        public static RendererAsset SaveRenderers(Renderer renderer)
        {
            RendererAsset result = null;
            if (renderer.gameObject.TryGetComponent<MeshFilter>(out var filter))
            {
                result = new RendererAsset
                {
                    mesh = MeshAssetUtility.SaveMesh(filter.sharedMesh),
                    materials = new MaterialAsset[renderer.sharedMaterials.Length]
                };
                for (int i = 0; i < renderer.sharedMaterials.Length; i++)
                {
                    result.materials[i] = MaterialAssetUtility.SaveMaterial(renderer.sharedMaterials[i]);
                }
            }

            return result;
        }




        public static void SavePhysics(GameObject go, PrefabAsset asset)
        {
            if (go.TryGetComponent<Rigidbody>(out var rb))
            {
                asset.physics = new PhysicsAsset
                {
                    mass = rb.mass,
                    isKinematic = rb.isKinematic,
                    useGravity = rb.useGravity,
                    drag = rb.drag,
                    angularDrag = rb.angularDrag,
                    water = false
                };
            }
            else
            {
                asset.physics = null;
            }
        }



        public static void SaveColliders(GameObject go, PrefabAsset asset)
        {
            var colls = go.GetComponentsInChildren<Collider>();
            asset.colliders = new ColliderAsset[colls.Length];
            for (int i = 0; i < colls.Length; i++)
            {
                asset.colliders[i] = new ColliderAsset
                {
                    name = colls[i].gameObject.name
                };
                colls[i].transform.GetLocalPositionAndRotation(out asset.colliders[i].localPosition, out asset.colliders[i].localRotation);
                if (colls[i] is BoxCollider)
                {
                    var box = colls[i] as BoxCollider;
                    asset.colliders[i].type = ColliderType.Box;
                    asset.colliders[i].size = box.size;
                    asset.colliders[i].center = box.center;
                }
                else if (colls[i] is CapsuleCollider)
                {
                    var capsule = colls[i] as CapsuleCollider;
                    asset.colliders[i].type = ColliderType.Capsule;
                    asset.colliders[i].radius = capsule.radius;
                    asset.colliders[i].center = capsule.center;
                    asset.colliders[i].height = capsule.height;
                }
                else if (colls[i] is SphereCollider)
                {
                    var sphere = colls[i] as SphereCollider;
                    asset.colliders[i].type = ColliderType.Sphere;
                    asset.colliders[i].radius = sphere.radius;
                    asset.colliders[i].center = sphere.center;
                }
                else if (colls[i] is MeshCollider)
                {
                    var mesh = colls[i] as MeshCollider;
                    asset.colliders[i].type = ColliderType.Mesh;
                    asset.colliders[i].mesh = MeshAssetUtility.SaveMesh(mesh.sharedMesh);
                }
                else
                {
                    asset.colliders[i] = null;
                }
            }
        }
    }
}