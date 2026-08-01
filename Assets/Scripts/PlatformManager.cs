using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    float TimePassed;
    float NextSpawn;
    public List<GameObject> PlatformList;
    [SerializeField] GameObject Player;

    [Header("Prefab")]
    [SerializeField] GameObject PlatformPrefab;

    [Header("Sprites")]
    [SerializeField] Sprite Platform1;
    [SerializeField] Sprite Platform2;
    [SerializeField] Sprite Platform3;
    [SerializeField] Sprite Platform4;

    [Header("Adjustments")]
    [SerializeField] float SpawnRangeLeft;
    [SerializeField] float SpawnRangeRight;
    [SerializeField] float SpawnRate;


    void Start()
    {

        NextSpawn = SpawnRate;

        for (int i = -10; i < 15; i = i + 5)
        {

            SpawnPlatform(new Vector3(Random.Range(SpawnRangeLeft, SpawnRangeRight), i, 0));

        }

    }

    private void Update()
    {

        TimePassed += Time.deltaTime;

        if (TimePassed > NextSpawn)
        {

            SpawnPlatform(new Vector3(Random.Range(SpawnRangeLeft, SpawnRangeRight), Player.transform.position.y + 12f, 0));
            NextSpawn = TimePassed + SpawnRate;

        }

    }

    public void SpawnPlatform(Vector3 PlatformPosition)
    {

        int RandomSprite = Random.Range(1, 5);

        GameObject Platform = Instantiate(PlatformPrefab, PlatformPosition, Quaternion.identity);
        SpriteRenderer sr = Platform.GetComponent<SpriteRenderer>();

        PlatformList.Add(Platform);

        PlatformScript PlatformScript = Platform.GetComponent<PlatformScript>();
        PlatformScript.SetManager(this);

        if (RandomSprite == 1)
            sr.sprite = Platform1;
        if (RandomSprite == 2)
            sr.sprite = Platform2;
        if (RandomSprite == 3)
            sr.sprite = Platform3;
        if (RandomSprite == 4)
            sr.sprite = Platform4;


    }

    public void RemovePlatFromList(GameObject platform)
    {

        PlatformList.Remove(platform);
    
    }

}
