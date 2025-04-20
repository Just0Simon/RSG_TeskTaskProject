namespace Content.Features.LootModule.Scripts
{
    [System.Serializable]
    public struct RandomLoot
    {
        public Loot Loot;
        [UnityEngine.Range(0f, 1f)]
        public float Chance;
    }
}