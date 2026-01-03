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
    
     public enum UpgradeButtonType
    {
        CoinUpgrade, 
        ManSpawner,
        ClickUpgrade
    }
}
