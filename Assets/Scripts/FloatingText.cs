using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] MoneyManager moneyManager;

    [Header("In(out)Come Settings")]
    [SerializeField] private GameObject moneyAddedText;
    [SerializeField] private GameObject moneyDecreasedText;

    [Header("Display Settings")]
    [SerializeField] private float seconds = 0.9f;
    [SerializeField] TMP_Text moneyAddedTextTmp;
    [SerializeField] TMP_Text moneyDecreasedTextTmp;
    float timePassed;

    private void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > seconds)
        {
            MoneyText();
            moneyAddedText.SetActive(true);
            timePassed = 0f;
        }
        else if (timePassed > 0.45f )
        {
            moneyAddedText.SetActive(false);
        }
    }
    
    void MoneyText()
    {
         switch (moneyManager.currentState)
            {
                case MoneyManager.MoneyState.MoneyAdded:
                    moneyDecreasedText.SetActive(false);
                    moneyManager.UpdateGoldText(moneyManager.addedMoney, moneyAddedTextTmp, "+"); //from MoneyManager(format)
                    moneyAddedTextTmp.color = Color.green;
                    break;
                case MoneyManager.MoneyState.MoneyDecreased:
                    moneyDecreasedText.SetActive(true);
                    moneyManager.UpdateGoldText(moneyManager.finalCost, moneyDecreasedTextTmp, "-"); //from MoneyManager(format)
                    moneyDecreasedTextTmp.color = Color.red;
                    moneyManager.finalCost = 0; //resetes money decrease from buying upgrades(UpgradeButtonScript)
                break;
            }
    }
}
