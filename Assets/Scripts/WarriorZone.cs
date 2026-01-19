using UnityEngine;

public class WarriorZone : MonoBehaviour
{
    [SerializeField] WarriorBehaviour warriorBehaviour;

    //Enemy enetered warrior Zone
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Enemy")
        {
            warriorBehaviour.AlertTarget(other.transform);
            Debug.Log("Its here");
        }
    }
    //Enemy Left warrior Zone
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            warriorBehaviour.TargetLost();
            Debug.Log("Its Gone");

        }

    }
}
