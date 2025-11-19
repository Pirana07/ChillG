using UnityEngine;
using TMPro;
using Unity.Collections;

public class MoneyButton : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] GameObject CombinedAddedText;
    [SerializeField] Animator CombinedAddedTextAnimator;

    [SerializeField] GameObject mouseAddedText;
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
        GameObject spawnedText = ObjectPoolManager.SpawnObject(mouseAddedText, mainCanvas.transform);
        spawnedText.transform.position = Input.mousePosition;

        moneyManager.currentMoney += moneyadded;
        combineadded += moneyadded;
        textaddedtmp.text = "+" + combineadded.ToString() + "$";

        CombineAddedColor();
        CombinedAddedText.SetActive(true);

        animcoin.SetTrigger("PlayCoin");
        coinParticles.Stop();
        coinParticles.Play();        

        CancelInvoke(nameof(dissapear));
        Invoke(nameof(dissapear), 0.5f);
    }
    void dissapear()
    {
        CombinedAddedText.SetActive(false);
        combineadded = 0;
        coinParticles.Stop();
    }

        void CombineAddedColor(){
        switch (combineadded)
        {
            case 1: textaddedtmp.color = Color.green;break;
            case 10:textaddedtmp.color = Color.yellow;break;
            case 30:textaddedtmp.color = new Color(1f, 0.5f, 0f);break; //orange
            case 50:textaddedtmp.color = Color.red;break;
            case 100:textaddedtmp.color = Color.magenta; break;
            case 500:textaddedtmp.color = Color.blue; break;
            case 999:textaddedtmp.color = Color.black;break;

        }
     }   
    

}
