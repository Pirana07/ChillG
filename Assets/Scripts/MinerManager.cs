using UnityEngine;

public class MinerManager : MonoBehaviour
{
  [Header("Miner Settings")]
  [SerializeField] GameObject[] miner;
  [SerializeField] MoneyManager moneyManager;

  [Header("Miner UI Settings")]
  [SerializeField] GameObject minerButton;
  public int minerIndex;

  [Header("Miner Evolve Settings")]
  // [Range(0, 2)][SerializeField] int Evolve;
  [SerializeField] Mans[] man;
  [SerializeField] SpriteRenderer[] minerSpriteRenderer;


  void EvolveMan(int EvolveIndex)//Evolution(Rebirth)
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
    if (minerIndex == 6)
      minerButton.SetActive(false);
  }

  public void ResetMiners()
  {
    // Deactivate all miners
    for (int i = 0; i < miner.Length; i++)
    {
      miner[i].SetActive(false);
    }

    // Reset index so player can spawn miners again
    minerIndex = 0;

    // Re-enable the miner button if needed
    minerButton.SetActive(true);

    // Update artwork for the new evolution tier
    EvolveMan(moneyManager.rebirthCounter);
  }

}
