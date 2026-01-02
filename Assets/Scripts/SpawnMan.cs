using UnityEngine;
using UnityEngine.AI;

public class SpawnMan : MonoBehaviour
{
  [Header("Miner Settings")]
  [SerializeField] GameObject[] miner;
  [Header("Miner UI Settings")]
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
