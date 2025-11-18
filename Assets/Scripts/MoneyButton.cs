using UnityEngine;
using TMPro;

public class MoneyButton : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] GameObject AddedText;
    [SerializeField] TMP_Text textaddedtmp;

    float combineadded;


    public void OnclickCoin(float moneyadded)
    {
        moneyManager.currentMoney += moneyadded;
        combineadded += moneyadded;
        textaddedtmp.text = "+" + combineadded.ToString() + "$";
        AddedText.SetActive(true);
        CancelInvoke(nameof(dissapear));
        Invoke(nameof(dissapear), 0.2f);
    }
    void dissapear()
    {
        AddedText.SetActive(false);
        combineadded = 0;
    }
}
