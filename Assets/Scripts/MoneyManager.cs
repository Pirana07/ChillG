using UnityEngine;
using System.Collections;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TMP_Text displayMoney;
    [SerializeField] float seconds = 1f;
    public float addedMoney = 1f;
 
    public float currentMoney = 0;
    float timePassed = 0f;
 
    public enum MoneyState{MoneyAdded, MoneyDecreased};
    public MoneyState currentState;
   
   

 private void Update() {
    timePassed += Time.deltaTime;

    if(timePassed > seconds)
    {
        currentMoney += addedMoney; //++money
        displayMoney.text = "$" + currentMoney.ToString();
        timePassed = 0f; 
    } 
        
    }

   



}
