using UnityEngine;

public class PlayerShadow : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] Player playerScript;

    [Header("Adjustments")]
    [SerializeField] float ShadowOffsetY;
    [SerializeField] float ShadowOffsetX;

    void Update()
    {

        if (playerScript.IsJumping)
            transform.position = new Vector3(Player.transform.position.x + ShadowOffsetX, playerScript.GroundY + ShadowOffsetY, Player.transform.position.z);
        else
            transform.position = new Vector3(Player.transform.position.x + ShadowOffsetX, Player.transform.position.y + ShadowOffsetY, Player.transform.position.z);

        if (playerScript.direction == 1)
            ShadowOffsetX = Mathf.Abs(ShadowOffsetX);
        if (playerScript.direction == -1)
            ShadowOffsetX = -Mathf.Abs(ShadowOffsetX);

    }

}
