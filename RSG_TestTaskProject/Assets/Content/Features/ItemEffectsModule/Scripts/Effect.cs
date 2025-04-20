namespace Content.Features.ItemEffectsModule.Scripts
{
    public class Effect : IEffect
    {
        public bool ConsumeItem { get; private set; }
        
        public void SetConsumeItem(bool consumeItem) => 
            ConsumeItem = consumeItem;
        
        public virtual void Apply() { }
    }
}