using UnityEngine;

public class FollowPlayerY : MonoBehaviour
{

    [SerializeField] GameObject Player;

    [Header("Adjustments")]
    [SerializeField] float zOffset;

    void Update()
    {

        transform.position = new Vector3(transform.position.x, Player.transform.position.y, zOffset);

    }

}
