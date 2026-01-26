using UnityEngine;

public class WarriorZone : MonoBehaviour
{
    [SerializeField] WarriorBehaviour warriorBehaviour;

    //Enemy enetered warrior Zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            warriorBehaviour.AlertTarget(other.transform);
    }
    
    //Enemy Left warrior Zone
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            warriorBehaviour.TargetLost(other.transform);
    }

}
