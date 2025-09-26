using UnityEngine;

public class BloodDrip : MonoBehaviour
{
    public GameObject BloodPrefab;     
    public float dripInterval = 2f;    // seconds between drops
    public float offsetAboveGround = 0.01f;
    private float dripTimer;

    void Update()
    {
        dripTimer += Time.deltaTime;

        if (dripTimer >= dripInterval)
        {
            DropBlood();
            dripTimer = 0f;
        }
    }

    void DropBlood()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 10f))
        {

            Vector3 spawnPos = hit.point + Vector3.up * offsetAboveGround;

            Quaternion rot = Quaternion.Euler(0, Random.Range(0, 360), 0);

            GameObject blood = Instantiate(BloodPrefab, spawnPos, rot);
            Destroy(blood, 10f);
        }
    }
}
