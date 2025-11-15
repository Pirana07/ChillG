using UnityEngine;
using TMPro;
using UnityEditor.ShaderGraph;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private float seconds = 0.9f;
    [SerializeField] TMP_Text displayMoney;
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
        else if (timePassed > 0.45f)
        {
            text.SetActive(false);
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
                    displayMoney.text = "-5$";
                    displayMoney.color = Color.red;
                    break;
            }
    }
    
}
