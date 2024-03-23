namespace ExternalAssets
{
    public class AssetCache
    {
        private int referCount;
        public int ReferCount { get { return referCount; } }
        public void Refer()
        {
            this.referCount++;
        }

        public void Return()
        {
            --this.referCount;
            if (this.referCount <= 0)
            {
                Unload();
            }
        }

        protected virtual void Unload() { }
    }
}