namespace Content.Features.ItemEffectsModule.Scripts
{
    public interface IEffectsFactory
    {
        T GetItemEffect<T>() where T : Effect;
    }
}