using UnityEngine;

public class MinerManager : MonoBehaviour
{
  public static MinerManager Instance { get; private set; } //Singleton

  [Header("Miner Settings")]
  [SerializeField] GameObject[] miner;
  [SerializeField] MoneyManager moneyManager;
  Vector3[] startingPositions;

  [Header("Miner UI Settings")]
  [SerializeField] GameObject minerButton;
  public int minerIndex;

  [Header("Miner Evolve Settings")]
  // [Range(0, 2)][SerializeField] int Evolve;
  [SerializeField] Mans[] man;
  [SerializeField] SpriteRenderer[] minerSpriteRenderer;

  void Awake()
  {
    //if there is more than one instance then destroy
    if (Instance != null && Instance != this)
    {
      Destroy(this);
      return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
  }

  void Start()
  {
    startingPositions = new Vector3[miner.Length];//need this to reset position when rebirth
    for (int i = 0; i < miner.Length; i++)
    {
      startingPositions[i] = miner[i].transform.position;//getting miners first position 
    }
  }

  public void EvolveMan(int EvolveIndex)//Evolution(Rebirth)
  {
    for (int i = 0; i < minerSpriteRenderer.Length; i++)
    {
      minerSpriteRenderer[i].sprite = man[EvolveIndex].artWork;
    }
  }

  public void OnClickMinerButton()
  {
    miner[minerIndex].SetActive(true);
    minerIndex = minerIndex + 1;
    if (minerIndex == miner.Length)
      minerButton.SetActive(false);
  }

  public void ResetMiners()//must change
  {
    // Deactivate all miners
    for (int i = 0; i < miner.Length; i++)
    {
      miner[i].SetActive(false);
      miner[i].transform.position = startingPositions[i]; // Reset position
    }

    // Reset index so player can spawn miners again
    minerIndex = 0;

    // Re-enable the miner button if needed
    minerButton.SetActive(true);



  }

}
