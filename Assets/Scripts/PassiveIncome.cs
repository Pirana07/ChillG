using UnityEngine;

public class PassiveIncome : MonoBehaviour
{
    [Header("Managers")]
    MoneyManager moneyManager;
    MinerManager minerManager;
    RebirthManager rebirthManager;

   [Header("Time Settings")]
    [SerializeField] CooldownTimer incomeTimer;


    void Start()
    {
        moneyManager = MoneyManager.Instance;
        rebirthManager = RebirthManager.Instance;
        minerManager = MinerManager.Instance;
    }

    private void Update()
    {
        incomeTimer.Tick(Time.deltaTime);

        if (incomeTimer.IsReady(0f))
        {
            moneyManager.currentMoney += PassiveIncomeMoney();
            incomeTimer.Reset(1f);
        }

        moneyManager.UpdateGoldText(moneyManager.currentMoney, moneyManager.displayMoney);
    }

    public float PassiveIncomeMoney()
    {
        float totalIncome = 0f;

        foreach (var group in minerManager.Groups)
            totalIncome += group.currentData.minerIncome * group.counter;

        return totalIncome * rebirthManager.rebirthMultiplier;
    }

}
