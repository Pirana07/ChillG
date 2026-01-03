using UnityEngine;

public class RebirthManager : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] UpgradeData[] allUpgrades;
    [SerializeField] SpawnMan spawnMan;
    UpgradeButton[] allUpgradeButtons;

    void Awake()
    {
        allUpgradeButtons = GameObject.FindObjectsByType<UpgradeButton>(FindObjectsSortMode.None);
    }
    public void Rebirth()
    {
        moneyManager.rebirthCounter++;
        moneyManager.rebirthMultiplier++;
        // Reset money
        moneyManager.currentMoney = 0;
        moneyManager.addedMoney = 1;
        // Reset upgrades (levels only)
        foreach (var upgrade in allUpgrades)
            upgrade.currentLevel = 0;

        foreach (var btn in allUpgradeButtons)
            btn.RefreshUI();
        
        //Reset miners
        spawnMan.ResetMiners();
        
    }
}

