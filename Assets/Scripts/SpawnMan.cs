using UnityEngine;
using UnityEngine.AI;

public class SpawnMan : MonoBehaviour
{
    [SerializeField] GameObject[] miner;
    [SerializeField] GameObject minerButton;
      int minerIndex;

    public void OnClickMinerButton()
    {
        miner[minerIndex].SetActive(true);
        minerIndex = minerIndex + 1;
        if(minerIndex == 6)
        minerButton.SetActive(false);
        
    }
}
