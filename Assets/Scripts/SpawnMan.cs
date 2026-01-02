using UnityEngine;

public class SpawnMan : MonoBehaviour
{
  [Header("Miner Settings")]
  [SerializeField] GameObject[] miner;

  [Header("Miner UI Settings")]
  [SerializeField] GameObject minerButton;
  int minerIndex;

  [Header("Miner Evolve Settings")]
  [Range(0, 2)][SerializeField] int Evolve;
  [SerializeField] Mans[] man;
  [SerializeField] SpriteRenderer[] minerSpriteRenderer;

  void Update()
  {
    switch (Evolve)
    {
      case 0: EvolveMan(Evolve); break;
      case 1: EvolveMan(Evolve); break;
      case 2: EvolveMan(Evolve); break;
      }
  }
  void EvolveMan(int EvolveIndex)//this should be another script... Temporary function
  {
    for (int i = 0; i < 7; i++)
    {
      minerSpriteRenderer[i].sprite = man[EvolveIndex].artWork;
    }
  }

  public void OnClickMinerButton()
  {
      miner[minerIndex].SetActive(true);
      minerIndex = minerIndex + 1;
      if(minerIndex == 6)
      minerButton.SetActive(false);
  }
}
