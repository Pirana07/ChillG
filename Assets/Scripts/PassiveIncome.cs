using UnityEngine;

public class PassiveIncome : MonoBehaviour
{
    [Header("Managers")]
    MoneyManager moneyManager;
    MinerManager minerManager;
    RebirthManager rebirthManager;

    [Header("Time Settings")]
    [Range(0f, 2f)][SerializeField] float seconds = 1f;
    float timePassed = 0f;


    void Start()
    {
        moneyManager = MoneyManager.Instance;
        rebirthManager = RebirthManager.Instance;
        minerManager = MinerManager.Instance;
    }

    private void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > seconds)
        {
            moneyManager.currentMoney += PassiveIncomeMoney(); //++money
            timePassed = 0f;
        }
        moneyManager.UpdateGoldText(moneyManager.currentMoney, moneyManager.displayMoney);
    }

    public float PassiveIncomeMoney()
    {
        return MinerIncomeMoney() * rebirthManager.rebirthMultiplier * minerManager.minerCounter;
    }

    float MinerIncomeMoney()
    {
        return minerManager.man[rebirthManager.evolutionIndex].minerIncome;
    }
}
