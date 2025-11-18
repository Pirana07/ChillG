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
            text2.SetActive(false);
        }
    }
    
    void MoneyText()
    {
         switch (moneyManager.currentState)
            {
                case MoneyManager.MoneyState.MoneyAdded:
                    displayMoney.text = "+" + moneyManager.addedMoney.ToString() + "$";
                    displayMoney.color = Color.green;
                    break;

                case MoneyManager.MoneyState.MoneyDecreased:
                    text2.SetActive(true);
                    textdecrease.text = "-" + moneyManager.deacreasedMoney.ToString() + "$";
                    textdecrease.color = Color.red;
                    break;
            }
    }
}
