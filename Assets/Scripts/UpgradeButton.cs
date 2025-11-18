using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] TMP_Text[] buttonText;
    [SerializeField] string[] TextButton;

    float stateDuration = 1f;
    float[] resetTimers;


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
                {
                    buttonText[i].text = TextButton[i];
                }
            }
        }
    }

    public void Upgrade(int x)
    {
        switch (x)
        {
            case 1: DecreaseMoney(10, 0, 5f); break;
            case 2: DecreaseMoney(50, 1, 25f); break;
            case 3: DecreaseMoney(1000, 2, 100f);break;
        }
    }

    void ResetMoneyState(){
        moneyManager.currentState = MoneyManager.MoneyState.MoneyAdded;
    }
    

    void DecreaseMoney(int cost, int buttonIndex, float upgradedmoney)
    {
        if (moneyManager.currentMoney >= cost)
        {
            moneyManager.deacreasedMoney = cost;
            moneyManager.currentState = MoneyManager.MoneyState.MoneyDecreased;
            moneyManager.combinedDecrease += cost;
            moneyManager.currentMoney -= cost;
            moneyManager.addedMoney = upgradedmoney; 
            CancelInvoke(nameof(ResetMoneyState));
            Invoke(nameof(ResetMoneyState), stateDuration);
        }
        else
        {
            buttonText[buttonIndex].text = "Not enough money!";
            resetTimers[buttonIndex] = 1f; 
        }
    }
    

}