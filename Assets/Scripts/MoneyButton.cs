using UnityEngine;
using TMPro;

public class MoneyButton : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] GameObject AddedText;
    [SerializeField] TMP_Text textaddedtmp;
    [SerializeField] Animator animcoin;
    [SerializeField] ParticleSystem coinParticles;

    float combineadded;

    void Start()
    {
    }
    public void OnclickCoin(float moneyadded)
    {
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
