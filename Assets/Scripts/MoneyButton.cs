using UnityEngine;
using TMPro;
using Unity.Collections;

public class MoneyButton : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] Canvas mainCanvas;

    [Header("AddedMoney Settings")]
    public float onClickMoneyAddedText = 1f;
    float onClickAddedTextDisplay;

    [Header("Clicked Effect")]
    [SerializeField] GameObject combinedAddedTextObject;
    [SerializeField] TMP_Text combineTextAddedTmp;
    [SerializeField] GameObject mouseAddedText;
    [SerializeField] Animator animcoin;
    // [SerializeField] ParticleSystem coinParticles;

    public void OnclickCoin() //coin click ButtonFunc
    {
        SpawnTextAtMouse(mouseAddedText);

        moneyManager.currentMoney += onClickMoneyAddedText;
        onClickAddedTextDisplay += onClickMoneyAddedText;
        combineTextAddedTmp.text = "+" + onClickAddedTextDisplay.ToString() + "$";

        ClickEffects();

        CancelInvoke(nameof(MoseTextDissapear));
        Invoke(nameof(MoseTextDissapear), 0.5f);
    } 
    //+1 Object Spawner
    void SpawnTextAtMouse(GameObject prefab)
    {
      GameObject obj = ObjectPoolManager.SpawnObject(prefab, mainCanvas.transform);
      Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      pos.z = 0f;

     obj.transform.position = pos;    
    }
     //+1 Object Despawn
    void MoseTextDissapear()
    {
        combinedAddedTextObject.SetActive(false);
        onClickAddedTextDisplay = 0; //reset added Money text
        // coinParticles.Stop();
    }
    void ClickEffects()
    {
        combinedAddedTextObject.SetActive(true);
        animcoin.SetTrigger("PlayCoin");//Jiggle Effect Anim
        // CombineAddedColor();
        // coinParticles.Stop();
        // coinParticles.Play(); 
    }

     //     void CombineAddedColor(){
    //     switch (combineadded)
    //     {
    //         case 1: combineTextAddedTmp.color = Color.green;break;
    //         case 10:combineTextAddedTmp.color = Color.yellow;break;
    //         case 30:combineTextAddedTmp.color = new Color(1f, 0.5f, 0f);break; //orange
    //         case 50:combineTextAddedTmp.color = Color.red;break;
    //         case 100:combineTextAddedTmp.color = Color.magenta; break;
    //         case 500:combineTextAddedTmp.color = Color.blue; break;
    //         case 999:combineTextAddedTmp.color = Color.black;break;
    //     }
    //  }  
}
