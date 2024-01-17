using UnityEngine;

namespace JsonAssets
{
    [System.Serializable]
    public class MaterialAsset : JsonAsset
    {
        public string UUID;
        public string name = "";
        public string shader;
        public bool instancing;
        public TextureProperty[] textures;
        public FloatProperty[] floats;
        public ColorProperty[] colors;
        public VectorProperty[] vectors;
        public IntegerProperty[] integers;
        public MatrixProperty[] matrices;
    }

    [System.Serializable]
    public class Property
    {
        public string keyword;
    }

    [System.Serializable]
    public class TextureProperty : Property
    {
        public TextureAsset value;
        public TextureProperty(string k, string name)
        {
            this.keyword = k;
            this.value = new TextureAsset(name);
        }
    }

    [System.Serializable]
    public class FloatProperty : Property
    {
        public float value;
        public FloatProperty(string k, float f)
        {
            this.keyword = k;
            this.value = f;
        }
    }

    [System.Serializable]
    public class IntegerProperty : Property
    {
        public int value;
        public IntegerProperty(string k, int i)
        {
            this.keyword = k;
            this.value = i;
        }
    }

    [System.Serializable]
    public class MatrixProperty : Property
    {
        public Matrix4x4 value;
        public MatrixProperty(string k, Matrix4x4 m)
        {
            this.keyword = k;
            this.value = m;
        }
    }

    [System.Serializable]
    public class ColorProperty : Property
    {
        public Color value;
        public ColorProperty(string k, Color c)
        {
            this.keyword = k;
            this.value = c;
        }
    }

    [System.Serializable]
    public class VectorProperty : Property
    {
        public Vector4 value;
        public VectorProperty(string k, Vector4 v)
        {
            this.keyword = k;
            this.value = v;
        }
    }
}