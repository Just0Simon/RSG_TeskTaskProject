namespace Content.Features.StorageModule.Scripts
{
    public class WeightStorageFactory : IStorageFactory
    {
        private readonly WeightStorageConfiguration _weightStorageConfiguration;
        
        public WeightStorageFactory(WeightStorageConfiguration weightStorageConfiguration)
        {
            _weightStorageConfiguration = weightStorageConfiguration;
        }

        public IStorage GetStorage()
        {
            return new WeightStorage(_weightStorageConfiguration.MaxWeight);
        }
    }
}