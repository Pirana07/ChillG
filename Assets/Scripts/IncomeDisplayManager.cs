using UnityEngine;
using TMPro;

public class IncomeDisplayManager : MonoBehaviour
{
    public static IncomeDisplayManager Instance { get; private set; } //Singleton

    [Header("Managers")]
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] PassiveIncome passiveIncome;

    [Header("In(out)Come Settings")]
    // [SerializeField] GameObject moneyAddedText;
    [SerializeField] GameObject moneyDecreasedText;
    public int costDisplay = 0;

    [Header("Display Settings")]
    [Range(0f, 1f)][SerializeField] float seconds = 0.99f;
    [SerializeField] TMP_Text moneyAddedTextTmp;
    [SerializeField] TMP_Text moneyDecreasedTextTmp;
    float timePassed;
    void Awake()
    {
        //if there is more than one instance then destroy
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }
    
    private void Update()
    {
        MoneyText();
        timePassed += Time.deltaTime;
        if (timePassed > seconds)
        {
            moneyAddedTextTmp.alpha = 1f;
            timePassed = 0f;
            costDisplay = 0; 
        }
        else if (timePassed > 0.45f)
        {
            moneyAddedTextTmp.alpha = 0.7f;
        }
    }

    void MoneyText()
    {
        switch (moneyManager.currentState)
        {
            case MoneyManager.MoneyState.MoneyAdded:
                moneyDecreasedText.SetActive(false);
                moneyManager.UpdateGoldText(passiveIncome.PassiveIncomeMoney(), moneyAddedTextTmp, "+"); //from MoneyManager(format)
                moneyAddedTextTmp.color = Color.green;
                break;
            case MoneyManager.MoneyState.MoneyDecreased:
                moneyDecreasedText.SetActive(true);
                moneyManager.UpdateGoldText(costDisplay, moneyDecreasedTextTmp, "-"); //from MoneyManager(format)
                moneyDecreasedTextTmp.color = Color.red;
                break;
        }
    }
}
