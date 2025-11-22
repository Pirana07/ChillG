using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] TMP_Text[] buttonText;
    [SerializeField] TMP_Text[] cotText;
    [SerializeField] GameObject[] pickaxeArray;
    [SerializeField] Sprite[] coinSprites;
    [SerializeField] Button buttonCoinSprite;




    [SerializeField] string[] TextButton;

    float stateDuration = 1f;
    float[] resetTimers;
        int i = 0;
        int j = 0;
        int k = 0;

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
                  buttonText[i].text = TextButton[i];  
            }
        }
    }

    public void Upgrade(int x)
    {

        switch (x)
        {
            case 1: BuyUpgrade(25, 0, 1f, ref i); break;
            case 2:
                BuyUpgrade(1000, 1, 0f, ref j);
                moneyManager.moneyButton.onClickMoneyAdded += 1f; 
            break;
            case 3: BuyUpgrade(10, 2, 750f,ref k); break;
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

        pickaxeArray[i/25].SetActive(true);
        buttonCoinSprite.image.sprite = coinSprites[k/10];

        cotText[0].text = "Cost: " + (25 + i) + "$";
        cotText[1].text = "Cost: " + (1000 + j) + "$";
        cotText[2].text = "Cost: " + (50000 + k) + "$";
    }
    else
    {
        buttonText[buttonIndex].text = "Not enough money!";
        resetTimers[buttonIndex] = 1f;
    }
}


}