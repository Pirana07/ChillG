using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; } //Singleton

    [Header("Income Settings")]
    public TMP_Text displayMoney;
    public float addedMoney = 1f;
    public float currentMoney = 0;
    public MoneyButton moneyButton;

    [Header("IncomeState")]
    public MoneyState currentState;
    public enum MoneyState { MoneyAdded, MoneyDecreased };

    [Header("Rebirth Settings")]
    public int rebirthCounter = 0;
    public int evolveCounter = 0;
    public int currentEvolve = 0;
    public int rebirthMultiplier = 1;


    void Awake()
    {
        //if there is more than one instance then destroy
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    
    /// <summary>
    /// Money Display Format
    /// </summary>
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
