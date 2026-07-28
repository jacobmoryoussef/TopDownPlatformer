using Unity.VisualScripting;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    [Header("Adjustments")]
    [SerializeField] float PlatformSpeed;
    [SerializeField] float DespawnArea;
    [SerializeField] float PlatformSize;

    [Header("Manager")]
    [SerializeField] PlatformManager Manager;

    void Start()
    {

        transform.localScale = new Vector3(PlatformSize, PlatformSize, PlatformSize);

    }

    void FixedUpdate()
    {

        transform.position = transform.position + new Vector3(0, -PlatformSpeed, 0);

        if (transform.position.y < DespawnArea)
        {

            Destroy(gameObject);
        
        }

    }

}
