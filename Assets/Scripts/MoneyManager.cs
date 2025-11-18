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
   public float combinedDecrease = 0f;

   
 private void Update() {
    timePassed += Time.deltaTime;

    if(timePassed > seconds)
    {
        currentMoney += addedMoney; //++money
        timePassed = 0f;
        }
    
        displayMoney.text = "$" + currentMoney.ToString();

    }
}
