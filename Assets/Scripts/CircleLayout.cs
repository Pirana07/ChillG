using UnityEngine;

public class CircleLayout : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToArrange;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float startAngle = 0f;
    [SerializeField] private bool arrangeOnStart = true;
    [SerializeField] private bool updateInEditor = false;
    
    [Header("Rotation Settings")]
    [SerializeField] private bool rotateObjects = false;
    [SerializeField] private float rotationSpeed = 30f;

    void Start()
    {
        if (arrangeOnStart)
        {
            ArrangeInCircle();
        }
    }

    void Update()
    {
        if (rotateObjects)
        {
            startAngle += rotationSpeed * Time.deltaTime;
            ArrangeInCircle();
        }
    }

    void OnValidate()
    {
        if (updateInEditor && objectsToArrange != null && objectsToArrange.Length > 0)
        {
            ArrangeInCircle();
        }
    }

    public void ArrangeInCircle()
    {
        if (objectsToArrange == null || objectsToArrange.Length == 0)
            return;

        int count = objectsToArrange.Length;
        float angleStep = 360f / count;

        for (int i = 0; i < count; i++)
        {
            if (objectsToArrange[i] == null)
                continue;

            float angle = (startAngle + (angleStep * i)) * Mathf.Deg2Rad;
            
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            objectsToArrange[i].transform.position = transform.position + new Vector3(x, y, 0);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}