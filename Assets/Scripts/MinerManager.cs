using System.Collections;
using UnityEngine;

public class MinerManager : MonoBehaviour
{
  public static MinerManager Instance { get; private set; } //Singleton

  [Header("Units")]
  [SerializeField] UnitGroup[] groups;

  public UnitGroup[] Groups => groups; //property

  // [Header("Evolution")]
  // [SerializeField] Mans[] evolutionData;

  // [Header("Miner Settings")]
  // [SerializeField] GameObject[] miner;
  // [SerializeField] MoneyManager moneyManager;
  // Vector3[] startingPositions;

  // [Header("Miner UI Settings")]
  // [SerializeField] GameObject minerButton;
  // public int minerCounter;
  // public int warriorCounter;


  [Header("Miner Evolve Settings")]
  // [Range(0, 2)][SerializeField] int Evolve;
  [SerializeField] public Mans[] man;
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
    StartPos();
  }
  /// <summary>
  /// Updates the sprite artwork of all units in all groups based on evolution/rebirth.
  /// </summary>
  public void EvolveUnits(int evolutionIndex)
  {
    foreach (var group in groups)
    {
      // Clamp index to avoid crashes
      int index = Mathf.Clamp(evolutionIndex, 0, group.evolutionData.Length - 1);

      group.currentData = group.evolutionData[index];

      foreach (var r in group.renderers)
        r.sprite = group.currentData.artWork;
    }
  }
  /// <summary>
  /// Spawns the next unit in a specific group, disables button if max reached.
  /// </summary>
  public void SpawnUnit(int groupIndex)
  {
    var group = groups[groupIndex];

    if (group.counter >= group.units.Length)
      return;

    group.units[group.counter].SetActive(true);
    group.counter++;

    if (group.counter >= group.units.Length)
      group.spawnButton.SetActive(false);
  }
  /// <summary>
  /// Resets all units in all groups to their starting positions and deactivates them.
  /// Also resets the spawn buttons and counters.
  /// </summary>
  public void ResetAllUnits()
  {
    foreach (var group in groups)
    {
      for (int i = 0; i < group.units.Length; i++)
      {
        group.units[i].SetActive(false);
        group.units[i].transform.position = group.startPositions[i];
      }

      group.counter = 0;
      group.spawnButton.SetActive(true);
    }
  }
  /// <summary>
  /// Stores the starting positions of all units in all groups.
  /// Used for resetting on rebirth/evolve.
  /// </summary>
  void StartPos()
  {
    foreach (var group in groups)
    {
      group.startPositions = new Vector3[group.units.Length];

      for (int i = 0; i < group.units.Length; i++)
        group.startPositions[i] = group.units[i].transform.position;
    }
  }

}

[System.Serializable]
public class UnitGroup
{
  public string id; // "Miner", "Warrior"
  [Header("Units")]
  public GameObject[] units; //all units of this group
  public SpriteRenderer[] renderers;
  public GameObject spawnButton;

  [Header("Evolution Data")]
  public Mans[] evolutionData;
  // [HideInInspector] public int evolutionIndex;

   public Mans currentData; //reference to the current scriptable object for this unit type

  [HideInInspector] public int counter; //how many units are currently spawned
  [HideInInspector] public Vector3[] startPositions; //for reseting positions on rebirth/evolve
}
