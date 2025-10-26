using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class BloodDrip : MonoBehaviour
{
    public GameObject BloodPrefab;
    public float dripInterval = 5f;
    public float offsetAboveGround = 0.01f;
    public float bloodTimer = 10f;
    public float initialDetectionRange = 20f;
    public float minDetectionRange = 2f;

    public Color startTint = Color.white;
    public Color endTint = new Color(0.7f, 0.4f, 0.3f);

    private float dripTimer;

    public static List<(GameObject blood, float spawnTime)> activeBlood = new List<(GameObject, float)>();

    void Update() //driptimer is a timer using dripinterval to drop blood on that set interval and resetting
    {
        dripTimer += Time.deltaTime;

        if (dripTimer >= dripInterval)
        {
            DropBlood();
            dripTimer = 0f;
        }
    }

    void DropBlood() //spawn the blood below the player at the first surface it hits then start the coroutine colourchange
    {

        RaycastHit hit;

        Vector3 origin = transform.position + Vector3.up * 0.1f;
        if (Physics.Raycast(origin, Vector3.down, out hit, 100f))
        {
            Vector3 spawnPos = hit.point + Vector3.up * offsetAboveGround;
            GameObject blood = Instantiate(BloodPrefab, spawnPos, Quaternion.identity);

            activeBlood.Add((blood, Time.time));

            StartCoroutine(ColourChange(blood));

            // StartCoroutine(DebugDetectionSphere(spawnPos, 10f, 0.5f, bloodTimer, Color.green)); //This was a debug test for the radius of detection on the blood that i removed

        }
    }

    System.Collections.IEnumerator ColourChange(GameObject blood) //this the blood changing colour, when it gets to the end of the change it destroys itself
    {
        Renderer rend = blood.GetComponentInChildren<Renderer>();

        float timer = 0f;
        while (timer < bloodTimer)
        {
            timer += Time.deltaTime;
            float t = timer / bloodTimer;

            rend.material.color = Color.Lerp(startTint, endTint, t);

            yield return null;
        }

        activeBlood.RemoveAll(b => b.blood == blood);
        Destroy(blood);
    }

    public static float GetCurrentDetectionRange(float spawnTime, float lifetime, float initial, float min)
    {
        float age = Time.time - spawnTime;
        float t = Mathf.Clamp01(age / lifetime);
        return Mathf.Lerp(initial, min, t);
    }


}
