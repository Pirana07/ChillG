using UnityEngine;

public class PassiveIncome : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] MinerManager minerManager;


    [Header("Time Settings")]
    [Range(0f, 2f)][SerializeField] float seconds = 1f;
    float timePassed = 0f;


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
        return moneyManager.addedMoney * moneyManager.rebirthMultiplier * minerManager.minerIndex;
    }
}
