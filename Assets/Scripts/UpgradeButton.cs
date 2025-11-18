using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] TMP_Text[] buttonText;
    [SerializeField] TMP_Text[] cotText;

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
            case 1: BuyUpgrade(25, 0, 1f, 1, ref i); break;
            case 2: BuyUpgrade(1000, 1, 45f, 2, ref j); break;
            case 3: BuyUpgrade(50000, 2, 750f, 3, ref k); ;break;
        }
        

    }
    void ResetMoneyState(){
        moneyManager.currentState = MoneyManager.MoneyState.MoneyAdded;
    }
    

    void BuyUpgrade(int cost, int buttonIndex, float upgradedmoney, int priceincirse, ref int counter)
    {
        if (moneyManager.currentMoney >= cost + counter)
        {
            moneyManager.combinedDecrease += cost + counter;
            counter += cost;
            
            moneyManager.currentState = MoneyManager.MoneyState.MoneyDecreased;
            moneyManager.currentMoney -= moneyManager.combinedDecrease;
            moneyManager.addedMoney += upgradedmoney; 

            CancelInvoke(nameof(ResetMoneyState));
            Invoke(nameof(ResetMoneyState), stateDuration);

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