using UnityEngine;
using TMPro;

public class IncomeDisplayManager : MonoBehaviour
{
    public static IncomeDisplayManager Instance { get; private set; } //Singleton

    [Header("Managers")]
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] PassiveIncome passiveIncome;
    [SerializeField] CooldownTimer displayTimer;


    [Header("In(out)Come Settings")]
    // [SerializeField] GameObject moneyAddedText;
    [SerializeField] GameObject moneyDecreasedText;
    public int costDisplay = 0;

    [Header("Display Settings")]
    // [Range(0f, 1f)][SerializeField] float seconds = 0.99f;
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
        displayTimer.Tick(Time.deltaTime);
        if (displayTimer.IsReady(0))
        {
            displayTimer.Reset(0.99f);
            moneyAddedTextTmp.alpha = 1f;
            if (moneyManager.currentState == MoneyManager.MoneyState.MoneyAdded)
                costDisplay = 0;
        }
        else if (displayTimer.IsReady(0.55f))
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
