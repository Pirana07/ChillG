using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject text2;
    [SerializeField] private float seconds = 0.9f;
    [SerializeField] TMP_Text displayMoney;
    [SerializeField] TMP_Text textdecrease;

    [SerializeField] MoneyManager moneyManager;

    float timePassed;

    private void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > seconds)
        {
            MoneyText();
            text.SetActive(true);
            timePassed = 0f;
        }
        else if (timePassed > 0.45f )
        {
            text.SetActive(false);
        }
    }
    
    void MoneyText()
    {
         switch (moneyManager.currentState)
            {
                case MoneyManager.MoneyState.MoneyAdded:
                    text2.SetActive(false);
                    moneyManager.UpdateGoldText(moneyManager.addedMoney, displayMoney, "+");
                    displayMoney.color = Color.green;
                    break;

                case MoneyManager.MoneyState.MoneyDecreased:
                    text2.SetActive(true);
                    moneyManager.UpdateGoldText(moneyManager.finalCost, textdecrease, "-");
                    textdecrease.color = Color.red;

                    moneyManager.finalCost = 0;
                break;
            }
    }
}
