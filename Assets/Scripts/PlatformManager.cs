using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    [Header("Prefab")]
    [SerializeField] GameObject PlatformPrefab;

    [Header("Sprites")]
    [SerializeField] Sprite Platform1;
    [SerializeField] Sprite Platform2;

    void Start()
    {

        for (int i = 0; i < 3; i++)
        {

            SpawnPlatform();            
           
        }

    }

    void SpawnPlatform()
    {

        int RandomSprite = Random.Range(1, 3);
        Debug.Log(RandomSprite);

        Vector3 PlatformPosition = new Vector3(Random.Range(-11, 11), 7, 0);
        GameObject Platform = Instantiate(PlatformPrefab, PlatformPosition, Quaternion.identity);
        SpriteRenderer sr = Platform.GetComponent<SpriteRenderer>();

        if (RandomSprite == 1)
            sr.sprite = Platform1;
        else
            sr.sprite = Platform2;

    }

}
