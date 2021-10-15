using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleSystemWinner;

    [SerializeField]
    private GameObject basketballPanel;

    private bool isOut = false;
    private bool isCollision = false;
    private float passedTime = 0f;
    private float distance;
    public void Start()
    {
        this.transform.SetPositionAndRotation(new Vector3(3.35f, 11.49f, -4.100003f), Quaternion.identity);
        particleSystemWinner.Stop();
    }

    private void Update()
    {
        if (!isCollision)
        {
            passedTime = 0;
        }
        else
        {
            passedTime += Time.deltaTime;
            if (passedTime > 3f)
            {
                particleSystemWinner.Stop();
                isCollision = false;
            }
        }
        distance = Vector3.Distance(this.transform.position, basketballPanel.transform.position);
        if (distance > 100f && isOut)
        {
            isOut = true;
            this.transform.SetPositionAndRotation(new Vector3(3.35f, 11.49f, -4.100003f), Quaternion.identity);
        }
        else {
            isOut = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Cos")
        {
            isCollision = true;
            particleSystemWinner.Play();
        }
    }

}
