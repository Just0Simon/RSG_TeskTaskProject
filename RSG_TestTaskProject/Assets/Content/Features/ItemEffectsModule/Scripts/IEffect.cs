namespace Content.Features.ItemEffectsModule.Scripts
{
    public interface IEffect
    {
        bool ConsumeItem { get; }
        
        public void Apply();
    }
}