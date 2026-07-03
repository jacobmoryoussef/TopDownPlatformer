using UnityEngine;

public class Platform : MonoBehaviour
{

    Transform transform;

    [Header("Adjustments")]
    [SerializeField] float PlatformSpeed;
    [SerializeField] float DespawnArea;

    [Header("Manager")]
    [SerializeField] PlatformManager Manager;

    void Start()
    {
        
        transform = GetComponent<Transform>();

    }

    void Update()
    {

        transform.position = transform.position + new Vector3(0, -PlatformSpeed, 0);

        if (transform.position.y < DespawnArea)
        {

            Destroy(gameObject);
        
        }

    }

}
