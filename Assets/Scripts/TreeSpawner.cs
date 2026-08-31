using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    [Header("TreeAssets")]
    [SerializeField] Sprite Tree1;
    [SerializeField] Sprite Tree2;

    void Start()
    {

        for (int i = 1; i > 5; i++)
        { 
        
            SpawnTree();
        
        }

    }

    void SpawnTree()
    {

        GameObject Tree = new GameObject();
        SpriteRenderer sp = Tree.AddComponent<SpriteRenderer>();
        sp.sprite = Tree1;
        Tree.transform.position = new Vector3(0, 0, 0);
    
    }

}
