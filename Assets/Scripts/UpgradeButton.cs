using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] SpawnMan spawnManScript;

    [Header("CoinButton Settings")]
    [SerializeField] Sprite[] coinSprites;
    [SerializeField] Button buttonCoinSprite;

    [Header("Upgrade Button Settings")]
    [SerializeField] TMP_Text[] upgradeButtonText;
    [SerializeField] string[] textForUpgradeButton;

    // [SerializeField] TMP_Text[] upgradeButtonCostText;
    // [SerializeField] GameObject[] pickaxeArray;
    [Header("UpgradeType Settings")]
    float stateDuration = 1f;
    int i = 0;
    int j = 0;
    int k = 0;
    float[] resetTimers;
     public enum UpgradeButtonType
    {
        CoinUpgrade, 
        ManSpawner,
        ClickUpgrade
    }
   void Awake()
    {
        resetTimers = new float[3]; 
    }
  void Update()
    {
        for (int i = 0; i < resetTimers.Length; i++)
        {
            if (resetTimers[i] > 0f)
            {
                resetTimers[i] -= Time.deltaTime;
                
                if (resetTimers[i] <= 0f)
                  upgradeButtonText[i].text = textForUpgradeButton[i];  
            }
        }
    }
    public void Upgrade(int index)
    {
        UpgradeButtonType buttonTypeIndex = (UpgradeButtonType)index;
        switch (buttonTypeIndex)
        {
            case UpgradeButtonType.ManSpawner: BuyUpgrade(25, 0, 1f, ref i); break;
            case UpgradeButtonType.CoinUpgrade: BuyUpgrade(200, 1, 10f, ref j); break;
            case UpgradeButtonType.ClickUpgrade: BuyUpgrade(20000, 2, 150f,ref k); break;
        }
    }
    void ResetMoneyState(){
        moneyManager.currentState = MoneyManager.MoneyState.MoneyAdded;
    }
    
void BuyUpgrade(int cost, int buttonIndex, float upgradedmoney, ref int counter)
{
     moneyManager.finalCost = cost + counter;

    if (moneyManager.currentMoney >= moneyManager.finalCost)
    {
        moneyManager.currentMoney -= moneyManager.finalCost;
        counter += cost;

        moneyManager.currentState = MoneyManager.MoneyState.MoneyDecreased;
        CancelInvoke(nameof(ResetMoneyState));
        Invoke(nameof(ResetMoneyState), stateDuration);

        moneyManager.addedMoney += upgradedmoney;
        spawnManScript.OnClickMinerButton();
        
        if(k/20000 < 7)
        buttonCoinSprite.image.sprite = coinSprites[k/20000];
        
        if (buttonIndex == 1)
        moneyManager.moneyButton.onClickMoneyAddedText += 1f;
        // if(i/25 < 21)
        // pickaxeArray[i/25].SetActive(true);
        // costText[0].text = "Cost: " + (25 + i) + "$";
        // costText[1].text = "Cost: " + (200 + j) + "$";
        // costText[2].text = "Cost: " + (20000 + k) + "$";
    }
    else
    {
       
        if(buttonIndex == 0)
            Debug.Log("nope");
        else{
            upgradeButtonText[buttonIndex].text = "Not enough money!";
            resetTimers[buttonIndex] = 1f; 
        }
    }
}

}