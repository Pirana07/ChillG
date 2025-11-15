using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] TMP_Text[] buttonText;
    [SerializeField] string TextButton;

    float stateDuration = 1f;
    int lastFailedIndex;


    public void Upgrade(int x)
    {
        switch (x)
        {
            case 1: DecreaseMoney(5, 0); break;
            case 2: DecreaseMoney(50, 1); break;
            case 3: DecreaseMoney(1000, 2); break;
        }
    }

    void ResetMoneyState(){
        moneyManager.currentState = MoneyManager.MoneyState.MoneyAdded;
    }

    void ResetButtonText(){
        buttonText[lastFailedIndex].text = TextButton;
    }

    void DecreaseMoney(int cost, int buttonIndex)
    {
        if (moneyManager.currentMoney >= cost)
        {
            moneyManager.currentState = MoneyManager.MoneyState.MoneyDecreased;
            moneyManager.currentMoney -= cost;

            CancelInvoke(nameof(ResetMoneyState));
            Invoke(nameof(ResetMoneyState), stateDuration);
        }
        else
        {
            buttonText[buttonIndex].text = "Not enough money!";

            lastFailedIndex = buttonIndex;

            CancelInvoke(nameof(ResetButtonText));
            Invoke(nameof(ResetButtonText), 1f);
        }
    }
    

}