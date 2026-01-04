using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class MoneyManager : MonoBehaviour
{

    [Header("Income Settings")]
    public TMP_Text displayMoney;
    public float addedMoney = 1f;
    public float currentMoney = 0;
    public MoneyButton moneyButton;

    [Header("IncomeState")]
    public MoneyState currentState; 
    public enum MoneyState{MoneyAdded, MoneyDecreased};
    
    [Header("Rebirth Settings")]
    public int rebirthCounter = 0;
    public int rebirthMultiplier = 1;


    // 
    // Money Display Format
    //
     public void UpdateGoldText(double moneyCount, TMP_Text textToChange, string endText = "")//Issue
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
