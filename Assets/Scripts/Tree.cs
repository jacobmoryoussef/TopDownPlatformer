using UnityEngine;

public class Tree : MonoBehaviour
{

    void Start()
    {

        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        sp.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);

    }

    void Update()
    {
        


    }

}
