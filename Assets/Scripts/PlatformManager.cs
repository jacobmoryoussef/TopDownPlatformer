using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    float TimePassed;
    float NextSpawn;

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
        SpawnPlatform();

    }

    private void Update()
    {

        TimePassed += Time.deltaTime;

        if (TimePassed > NextSpawn)
        {

            SpawnPlatform();
            NextSpawn = TimePassed + SpawnRate;

        }

    }

    public void SpawnPlatform()
    {

        int RandomSprite = Random.Range(1, 5);

        Vector3 PlatformPosition = new Vector3(Random.Range(SpawnRangeLeft, SpawnRangeRight), 10, 0);
        GameObject Platform = Instantiate(PlatformPrefab, PlatformPosition, Quaternion.identity);
        SpriteRenderer sr = Platform.GetComponent<SpriteRenderer>();

        if (RandomSprite == 1)
            sr.sprite = Platform1;
        if (RandomSprite == 2)
            sr.sprite = Platform2;
        if (RandomSprite == 3)
            sr.sprite = Platform3;
        if (RandomSprite == 4)
            sr.sprite = Platform4;

        PlatformScript PlatformScript = Platform.GetComponent<PlatformScript>();

    }

}
