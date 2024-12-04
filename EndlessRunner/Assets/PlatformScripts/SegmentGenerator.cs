using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public ObjectPool objectPool;
    public float minPlatformWidth = 1f;
    public float maxPlatformWidth = 3f;
    public float minPlatformDistance = 2f;
    public float maxPlatformDistance = 5f;
    public int platformsPerSegment = 10;
    public float playerJumpDistance = 6f;

    private Vector3 lastPlatformPosition;

    public void GenerateSegment(float gameSpeed)
    {
        float adjustedMaxDistance = Mathf.Min(playerJumpDistance, maxPlatformDistance + gameSpeed / 2f);

        for (int i = 0; i < platformsPerSegment; i++)
        {
            GameObject platform = objectPool.GetPooledObject();
            if (platform != null)
            {
                float xOffset = Random.Range(minPlatformDistance, adjustedMaxDistance);
                platform.transform.position = lastPlatformPosition + new Vector3(xOffset, 0, 0);
                platform.GetComponent<Platform>().Initialize(minPlatformWidth, maxPlatformWidth, xOffset);
                lastPlatformPosition = platform.transform.position;
            }
        }
    }

    public void ReturnSegment(GameObject[] segmentPlatforms)
    {
        foreach (var platform in segmentPlatforms)
        {
            objectPool.ReturnObject(platform);
        }
    }
}
