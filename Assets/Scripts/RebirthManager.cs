using UnityEngine;

public class RebirthManager : MonoBehaviour
{
    public static RebirthManager Instance { get; private set; } //Singleton

    [Header("Managers")]
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] MinerManager minerManager;
    [SerializeField] UpgradeData[] allUpgrades;
    UpgradeButton[] allUpgradeButtons;

    [Header("Evolve")] 
    public int evolutionIndex = 0;

    [Header("Rebirth Settings")]
    public int rebirthCounter = 0;
    public int rebirthMultiplier = 1;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        allUpgradeButtons = FindObjectsByType<UpgradeButton>(FindObjectsSortMode.None);
    }
    public void Rebirth()
    {
        rebirthCounter++;
        rebirthMultiplier++;
        // Reset money
        moneyManager.currentMoney = 0;
        moneyManager.addedMoney = 1;
        // Reset upgrade levels
        foreach (var upgrade in allUpgrades)
            upgrade.currentLevel = 0;

        // Reset units
        minerManager.ResetAllUnits();

        // Reset evolution
        evolutionIndex = 0;
        minerManager.EvolveUnits(evolutionIndex);

        // Refresh UI
        foreach (var btn in allUpgradeButtons)
            btn.RefreshUI();
    }
    public void Evolve()
    {
        evolutionIndex++;
        minerManager.ResetAllUnits();
        minerManager.EvolveUnits(evolutionIndex);
        allUpgrades[1].currentLevel = 0;
        allUpgrades[4].currentLevel = 0;


        foreach (var btn in allUpgradeButtons)
            btn.RefreshUI();
    }

}
