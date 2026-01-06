using UnityEngine;

[CreateAssetMenu(fileName = "Upgrades", menuName = "Upgrades", order = 0)]
public class UpgradeData : ScriptableObject
{
    public string displayName;
    public UpgradeButtonType upgradeType;

    [Header("Cost Settings")]
    public int baseCost;
    public int costIncrease;

    [Header("Upgrade Settings")]
    public float valuePerLevel;
    public int maxLevel;
    public int currentLevel;

    [Tooltip("Upgrade becomes available only after player rebirths.")]//that's a new thing
    public bool unlockAfterRebirth = false;
    public int unitGroupIndex; // index in MinerManager.groups

    public enum UpgradeButtonType
    {
        CoinUpgrade,
        UnitSpawner,
        ClickUpgrade,
        Rebirth,
        Evolve
    }
}
