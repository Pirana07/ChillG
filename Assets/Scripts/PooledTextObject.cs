using UnityEngine;

public class PooledTextObject : MonoBehaviour
{
    [SerializeField] float lifetime = 2f;


    void OnEnable(){
        Invoke(nameof(ReturnToPool), lifetime);
    }

    void ReturnToPool(){
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }

    void OnDisable(){
        CancelInvoke();
    }
}