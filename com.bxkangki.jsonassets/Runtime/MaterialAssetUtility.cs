using UnityEngine;

namespace JsonAssets {
    public static class MaterialAssetUtility {

        public static MaterialAsset SaveMaterial(Material mat) {
            MaterialAsset result = new MaterialAsset();
            result.textures = GetTextureProperties(mat);
            result.floats = GetFloatProperties(mat);
            result.integers = GetIntegerProperties(mat);
            result.vectors = GetVectorProperties(mat);
            result.matrices = GetMatrixProperties(mat);
            result.shader = mat.shader.name;
            result.instancing = mat.enableInstancing;

            return result;
        }


        private static FloatProperty[] GetFloatProperties (Material mat) {
            var names = mat.GetPropertyNames(MaterialPropertyType.Float);
            var properties = new FloatProperty[names.Length];
            for (int i = 0; i < names.Length; i++) {
                properties[i] = new FloatProperty(names[i], mat.GetFloat(names[i]));
            }
            return properties;
        }

        private static IntegerProperty[] GetIntegerProperties (Material mat) {
            var names = mat.GetPropertyNames(MaterialPropertyType.Int);
            var properties = new IntegerProperty[names.Length];
            for (int i = 0; i < names.Length; i++) {
                properties[i] = new IntegerProperty(names[i], mat.GetInteger(names[i]));
            }
            return properties;
        }


        private static VectorProperty[] GetVectorProperties (Material mat) {
            var names = mat.GetPropertyNames(MaterialPropertyType.Vector);
            var properties = new VectorProperty[names.Length];
            for (int i = 0; i < names.Length; i++) {
                properties[i] = new VectorProperty(names[i], mat.GetVector(names[i]));
            }
            return properties;
        }


        private static MatrixProperty[] GetMatrixProperties (Material mat) {
            var names = mat.GetPropertyNames(MaterialPropertyType.Matrix);
            var properties = new MatrixProperty[names.Length];
            for (int i = 0; i < names.Length; i++) {
                properties[i] = new MatrixProperty(names[i], mat.GetMatrix(names[i]));
            }
            return properties;
        }


        private static TextureProperty[] GetTextureProperties (Material mat) {
            var names = mat.GetPropertyNames(MaterialPropertyType.Texture);
            var properties = new TextureProperty[names.Length];
            for (int i = 0; i < names.Length; i++) {
                if (mat.GetTexture(names[i]) != null)
                    properties[i] = new TextureProperty(names[i], mat.GetTexture(names[i]).name);
            }
            return properties;
        }


        public static Material LoadMaterial(MaterialAsset asset, string texPath) {
            Material result = new Material(Shader.Find(asset.shader));
            for (int i = 0; i < asset.textures.Length; i++) {
                result.SetTexture(asset.textures[i].keyword, asset.textures[i].value.Load(texPath));
            }
            for (int i = 0; i < asset.floats.Length; i++) {
                result.SetFloat(asset.floats[i].keyword, asset.floats[i].value);
            }
            for (int i = 0; i < asset.vectors.Length; i++) {
                result.SetVector(asset.vectors[i].keyword, asset.vectors[i].value);
            }
            for (int i = 0; i < asset.integers.Length; i++) {
                result.SetInteger(asset.integers[i].keyword, asset.integers[i].value);
            }
            for (int i = 0; i < asset.matrices.Length; i++) {
                result.SetMatrix(asset.matrices[i].keyword, asset.matrices[i].value);
            }
            result.enableInstancing = asset.instancing;
            return result;
        }
    }
}