using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class TreeSpawner : MonoBehaviour
{

    public Vector2 bottomLeft;
    public Vector2 topRight;

    private List<GameObject> Trees = new List<GameObject>();

    [SerializeField] Transform parentObject;
    [SerializeField] Player playerScript;

    [Header("Adjustments")]
    [SerializeField] float riverLeft;
    [SerializeField] float riverRight;
    [SerializeField] int totalTrees;
    [SerializeField] float spawnDistance;
    [SerializeField] float minSize;
    [SerializeField] float maxSize;

    [Header("TreeAssets")]
    [SerializeField] GameObject Tree1;
    [SerializeField] GameObject Tree2;

    void Start()
    {

        SetScreenRanges();

        while (Trees.Count < totalTrees)
        {

            GameObject prefabVariant;

            int randomTree = Random.Range(0, 100);
            if (randomTree < 50)
                prefabVariant = Tree1;
            else
                prefabVariant = Tree2;

                SpawnTree(prefabVariant);
        
        }

    }

    private void Update()
    {

        SetScreenRanges();

    }

    void SetScreenRanges()
    { 
    
        Camera cam = Camera.main;
        bottomLeft = cam.ViewportToWorldPoint(Vector3.zero);
        topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));
    
    }

    void SpawnTree(GameObject prefabVariant)
    {

        //0 is left side of screen, 1 is right side of screen
        int spawnSide = Random.Range(0, 100);
        float x = 0;

        if (spawnSide < 50)
            x = Random.Range(bottomLeft.x, riverLeft);
        else
            x = Random.Range(riverRight, topRight.x);

        Vector2 Position = new Vector2(x,
                                  Random.Range(bottomLeft.y, topRight.y));

        if (Vector2.Distance(playerScript.PlayerSpawnPoint, Position) < 7)
        {

            Debug.Log(Vector2.Distance(playerScript.PlayerSpawnPoint, Position));
                return;
        
        }

        for (int i = 0; i < Trees.Count; i++)
        {

            if (Vector2.Distance(Position, Trees[i].transform.position) < spawnDistance)
                return;

        }

       GameObject tree = Instantiate(prefabVariant, Position, Quaternion.identity);
       tree.transform.parent = parentObject;
       Trees.Add(tree);

       tree.transform.localScale = tree.transform.localScale * Random.Range(minSize, maxSize);

       parentObject.gameObject.name = $"Trees ({Trees.Count})";
    
    }

}
