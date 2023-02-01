using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FROG_Ai : MonoBehaviour
{
    public float speed = 5f;
    public float shoutingDistance = 5f;
    public string shoutMessage = "Hey! Get away from me!";

    private Transform playerTransform;
    private bool isShouting = false;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer < shoutingDistance)
        {
            isShouting = true;
            StartCoroutine(EndShouting());

            // Run away from the player
            Vector3 directionAwayFromPlayer = (transform.position - playerTransform.position).normalized;
            transform.position = transform.position + directionAwayFromPlayer * speed * Time.deltaTime;
        }
        else
        {
            isShouting = false;
        }
    }

    private void OnGUI()
    {
        if (isShouting)
        {
            GUI.Label(new Rect(10, 10, 500, 20), shoutMessage);
        }
    }

    IEnumerator EndShouting()
    {
        yield return new WaitForSeconds(1000f);
        isShouting = false;
    }
}