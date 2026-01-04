using UnityEngine;

public class MinerBehavour : MonoBehaviour
{

    [Header("Movement Settings")]
    [SerializeField] float minerSpeed = 5;
    Transform[] minePlaces;
    Transform depositPlace;
    Transform currentTargetMine;


    [Header("Mining Settings")]
    [SerializeField] float miningSpeed = 0.5f;
    [SerializeField] float miningProgress = 0f;

    enum MinerState
    {
        Idle,
        GoingToMine,
        Mining,
        GoingToDeposit,
    }
    [Header("Miner Settings")]
    [SerializeField] MinerState minerState;
    [SerializeField] Animator minerAnim;

    void Start()
    {
        GameObject[] mineObjects = GameObject.FindGameObjectsWithTag("MiningPlace");
        minePlaces = new Transform[mineObjects.Length];
        for (int i = 0; i < mineObjects.Length; i++)
        {
            minePlaces[i] = mineObjects[i].transform;
        }
        depositPlace = GameObject.FindWithTag("DepositPlace").transform;

        PickNewMinePlace(); //picks first miningplace
    }
    void Update()
    {
        switch (minerState)
        {
            case MinerState.GoingToMine: WalkingTowards(currentTargetMine, MinerState.Mining); break;
            case MinerState.Mining: MiningTheCoin(MinerState.GoingToDeposit); break;
            case MinerState.GoingToDeposit: WalkingTowards(depositPlace, MinerState.GoingToMine); break;

        }
    }

    void WalkingTowards(Transform target, MinerState nextState)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, minerSpeed * Time.deltaTime);
        minerAnim.SetBool("isItMining", false);
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < 0.05f)
        {
            minerState = nextState;
            PickNewMinePlace();
            if (nextState == MinerState.GoingToMine)
                Flip();
        }
    }

    void MiningTheCoin(MinerState nextState)
    {
        minerAnim.SetBool("isItMining", true);
        miningProgress += miningSpeed * Time.deltaTime;// timer kind of thing
        if (miningProgress >= 1f)
        {
            miningProgress = 0f;
            minerState = nextState;
            Flip();
        }
    }
    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    void PickNewMinePlace()
    {
        currentTargetMine = minePlaces[Random.Range(0, minePlaces.Length)];
    }
}
