using UnityEngine;
using TMPro;

public class MoneyButton : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] GameObject AddedText;
    // [SerializeField] GameObject mouseAddedText;
    [SerializeField] TMP_Text textaddedtmp;
    [SerializeField] Animator animcoin;
    [SerializeField] ParticleSystem coinParticles;
    [SerializeField] private Canvas mainCanvas;
    
    float combineadded;

    void Start()
    {
    }
    public void OnclickCoin(float moneyadded)
    {
        // Instantiate(mouseAddedText, Input.mousePosition, Quaternion.identity, mainCanvas.transform);
        moneyManager.currentMoney += moneyadded;
        combineadded += moneyadded;
        animcoin.SetTrigger("PlayCoin");
        coinParticles.Stop();
        coinParticles.Play();
        textaddedtmp.text = "+" + combineadded.ToString() + "$";
        AddedText.SetActive(true);
        CancelInvoke(nameof(dissapear));
        Invoke(nameof(dissapear), 0.2f);
    }
    void dissapear()
    {
        AddedText.SetActive(false);
        combineadded = 0;
        coinParticles.Stop();
    }
}
