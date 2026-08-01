using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    [Header("Adjustments")]
    [SerializeField] public float PlatformSpeed;
    [SerializeField] float DespawnArea;
    [SerializeField] float PlatformSize;

    PlatformManager Manager;

    void Start()
    {

        PolygonCollider2D collider;
        collider = gameObject.AddComponent<PolygonCollider2D>();
        collider.isTrigger = true;
        
        transform.localScale = new Vector3(PlatformSize, PlatformSize, PlatformSize);

    }

    void FixedUpdate()
    {

        transform.position = transform.position + new Vector3(0, -PlatformSpeed, 0);

        if (transform.position.y < DespawnArea)
        {

            Manager.RemovePlatFromList(gameObject);
            Destroy(gameObject);
        
        }

    }

    public void SetManager(PlatformManager ManagerScipt)
    {

        Manager = ManagerScipt;
    
    }

}
