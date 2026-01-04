using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] RebirthManager rebirthManager;
    [SerializeField] FloatingText floatingText;
    [SerializeField] MinerManager minerManager;
    [SerializeField] UpgradeData upgrade; //UpgradeButton scriptableObject 

    [Header("Upgrade UI")]
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text costText;

    // [SerializeField] TMP_Text levelText;
    void Start()
    {
        upgrade.currentLevel = 0;
        upgrade.baseCost *= moneyManager.rebirthCounter + 1;
        RefreshUI();
    }
    public void BuyUpgrade()
    {
        if (upgrade.currentLevel >= upgrade.maxLevel) //Checks if I can upgrade more, or is it some kind of max(like in miners, u can do max 5)
            return;

        int cost = GetCost(); //upgrade.baseCost + upgrade.currentLevel * upgrade.costIncrease

        if (moneyManager.currentMoney < cost)//checks if i can buy it, if not enough, then return and dont buy 
            return;

        moneyManager.currentMoney -= cost;//buys it and deacreses money
        upgrade.currentLevel++; //tracks how many times i upgraded

        MoneyDecreased(cost);//Displays Decrease
        ApplyUpgrades();
        RefreshUI();//changes cost display

        CancelInvoke(nameof(ResetMoneyState));
        Invoke(nameof(ResetMoneyState), 1f);
    }

    void ApplyUpgrades()
    {
        switch (upgrade.upgradeType) //Upgrades Based on Type:
        {
            case UpgradeData.UpgradeButtonType.ManSpawner: minerManager.OnClickMinerButton(); break;
            case UpgradeData.UpgradeButtonType.ClickUpgrade: moneyManager.moneyButton.onClickMoneyAddedText += upgrade.valuePerLevel; break;
            case UpgradeData.UpgradeButtonType.EvolutionRebirth: rebirthManager.Rebirth(); break;

                // case UpgradeData.UpgradeButtonType.CoinUpgrade: ; break; *i should delete this)
        }
    }
    int GetCost()
    {
        return upgrade.baseCost + upgrade.currentLevel * upgrade.costIncrease * moneyManager.rebirthMultiplier;
    }
    void ResetMoneyState()//uses FloatingTextScript
    {
        moneyManager.currentState = MoneyManager.MoneyState.MoneyAdded;
    }
    void MoneyDecreased(int cost)//displays money decrease(uses FloatingTextScript)
    {
        floatingText.costDisplay = cost;
        moneyManager.currentState = MoneyManager.MoneyState.MoneyDecreased;
    }
    public void RefreshUI()
    {
        nameText.text = upgrade.displayName;
        costText.text = GetCost() + "$";
    }
}