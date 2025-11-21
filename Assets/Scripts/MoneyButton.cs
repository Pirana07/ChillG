using UnityEngine;
using TMPro;
using Unity.Collections;

public class MoneyButton : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] GameObject CombinedAddedText;
    [SerializeField] GameObject mouseAddedText;
    [SerializeField] TMP_Text Combinetextaddedtmp;

    [SerializeField] Animator animcoin;
    [SerializeField] ParticleSystem coinParticles;
    [SerializeField] private Canvas mainCanvas;
    public float onClickMoneyAdded = 1f;
    float combineadded;

    void Start()
    {
    }
    public void OnclickCoin()
    {
        SpawnAtMouse(mouseAddedText);


        moneyManager.currentMoney += onClickMoneyAdded;
        combineadded += onClickMoneyAdded;
        Combinetextaddedtmp.text = "+" + combineadded.ToString() + "$";

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
            case 1: Combinetextaddedtmp.color = Color.green;break;
            case 10:Combinetextaddedtmp.color = Color.yellow;break;
            case 30:Combinetextaddedtmp.color = new Color(1f, 0.5f, 0f);break; //orange
            case 50:Combinetextaddedtmp.color = Color.red;break;
            case 100:Combinetextaddedtmp.color = Color.magenta; break;
            case 500:Combinetextaddedtmp.color = Color.blue; break;
            case 999:Combinetextaddedtmp.color = Color.black;break;

        }
     }   
    
    void SpawnAtMouse(GameObject prefab)
    {
      GameObject obj = ObjectPoolManager.SpawnObject(prefab, mainCanvas.transform);
      Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      pos.z = 0f;

     obj.transform.position = pos;    
    }
    
}
