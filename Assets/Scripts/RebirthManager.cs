using UnityEngine;

public class RebirthManager : MonoBehaviour
{
    public static RebirthManager Instance { get; private set; } //Singleton

    [SerializeField] MoneyManager moneyManager;
    [SerializeField] UpgradeData[] allUpgrades;
    [SerializeField] MinerManager minerManager;
    UpgradeButton[] allUpgradeButtons;
    int evolutionInedx = 1;
    

    void Awake()
    {
        //if there is more than one instance then destroy
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        //
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
        minerManager.ResetMiners();
    }

    public void Evolve()
    {
            minerManager.ResetMiners(); //Reset miners
            minerManager.EvolveMan(evolutionInedx);// Update artwork for the new evolution tier
            allUpgrades[1].currentLevel = 0;
            evolutionInedx++;
          foreach (var btn in allUpgradeButtons)
            btn.RefreshUI();
    }

    
}

