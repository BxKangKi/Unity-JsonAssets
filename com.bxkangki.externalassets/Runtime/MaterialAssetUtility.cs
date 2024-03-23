using UnityEngine;

namespace ExternalAssets
{
    public struct MaterialAssetUtility
    {
        public static MaterialAsset SaveMaterial(Material mat)
        {
            MaterialAsset result = new MaterialAsset
            {
                textures = GetTextureProperties(mat),
                floats = GetFloatProperties(mat),
                integers = GetIntegerProperties(mat),
                vectors = GetVectorProperties(mat),
                matrices = GetMatrixProperties(mat),
                shader = mat.shader.name,
                instancing = mat.enableInstancing,
                name = mat.name,
                UUID = System.Guid.NewGuid().ToString()
            };
            return result;
        }


        private static FloatProperty[] GetFloatProperties(Material mat)
        {
            var names = mat.GetPropertyNames(MaterialPropertyType.Float);
            var properties = new FloatProperty[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                properties[i] = new FloatProperty(names[i], mat.GetFloat(names[i]));
            }
            return properties;
        }

        private static IntegerProperty[] GetIntegerProperties(Material mat)
        {
            var names = mat.GetPropertyNames(MaterialPropertyType.Int);
            var properties = new IntegerProperty[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                properties[i] = new IntegerProperty(names[i], mat.GetInteger(names[i]));
            }
            return properties;
        }


        private static VectorProperty[] GetVectorProperties(Material mat)
        {
            var names = mat.GetPropertyNames(MaterialPropertyType.Vector);
            var properties = new VectorProperty[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                properties[i] = new VectorProperty(names[i], mat.GetVector(names[i]));
            }
            return properties;
        }


        private static MatrixProperty[] GetMatrixProperties(Material mat)
        {
            var names = mat.GetPropertyNames(MaterialPropertyType.Matrix);
            var properties = new MatrixProperty[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                properties[i] = new MatrixProperty(names[i], mat.GetMatrix(names[i]));
            }
            return properties;
        }


        private static TextureProperty[] GetTextureProperties(Material mat)
        {
            var names = mat.GetPropertyNames(MaterialPropertyType.Texture);
            var properties = new TextureProperty[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                if (mat.GetTexture(names[i]) != null)
                    properties[i] = new TextureProperty(names[i], mat.GetTexture(names[i]) as Texture2D);
            }
            return properties;
        }


        public static Material LoadMaterial(MaterialAsset asset, out string[] textureNames)
        {
            var result = new Material(Shader.Find(asset.shader))
            {
                name = asset.name
            };
            textureNames = new string[asset.textures.Length];
            for (int i = 0; i < asset.textures.Length; i++)
            {
                result.SetTexture(asset.textures[i].keyword, TextureAssetUtility.LoadTexture(asset.textures[i].value));
                textureNames[i] = asset.textures[i].value.name;
            }
            for (int i = 0; i < asset.floats.Length; i++)
            {
                result.SetFloat(asset.floats[i].keyword, asset.floats[i].value);
            }
            for (int i = 0; i < asset.vectors.Length; i++)
            {
                result.SetVector(asset.vectors[i].keyword, asset.vectors[i].value);
            }
            for (int i = 0; i < asset.integers.Length; i++)
            {
                result.SetInteger(asset.integers[i].keyword, asset.integers[i].value);
            }
            for (int i = 0; i < asset.matrices.Length; i++)
            {
                result.SetMatrix(asset.matrices[i].keyword, asset.matrices[i].value);
            }
            result.enableInstancing = asset.instancing;
            return result;
        }
    }
}