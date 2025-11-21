using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [Header("Time Settings")]
    [SerializeField] float seconds = 1f;
    float timePassed = 0f;

    [Header("Income Settings")]
    [SerializeField] TMP_Text displayMoney;
    public float addedMoney = 1f;
    public float currentMoney = 0;
    public enum MoneyState{MoneyAdded, MoneyDecreased};
    public MoneyState currentState;
   public int finalCost = 0;
    public MoneyButton moneyButton;
   
 private void Update() {
    timePassed += Time.deltaTime;

    if(timePassed > seconds)
    {
        currentMoney += addedMoney; //++money
        timePassed = 0f;
        }
    
        UpdateCookieText(currentMoney, displayMoney);

    }

     public void UpdateCookieText(double moneyCount, TMP_Text textToChange, string endText = "")
    {
        string[] suffixes = { "", "K", "M", "B", "T", "Q" };
        int index = 0;

        while (moneyCount >= 1000 && index < suffixes.Length - 1)
        {
            moneyCount /= 1000;
            index++;
        }

        string formatted =
            index == 0
            ? moneyCount.ToString()
            : moneyCount.ToString("F1") + suffixes[index];

        textToChange.text = endText + formatted + "$";
    }

}
