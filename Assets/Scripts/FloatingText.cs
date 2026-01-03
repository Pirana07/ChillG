using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] MoneyManager moneyManager;

    [Header("In(out)Come Settings")]
    [SerializeField] GameObject moneyAddedText;
    [SerializeField] GameObject moneyDecreasedText;
    public int costDisplay = 0;


    [Header("Display Settings")]
     [Range(0f, 1f)][SerializeField] float seconds = 0.9f;
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
                    moneyManager.UpdateGoldText(costDisplay, moneyDecreasedTextTmp, "-"); //from MoneyManager(format)
                    moneyDecreasedTextTmp.color = Color.red;
                    costDisplay = 0; //resetes money decrease from buying upgrades(UpgradeButtonScript)
                break;
            }
    }
}
