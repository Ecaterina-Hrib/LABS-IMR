using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlModele : MonoBehaviour
{
    [SerializeField]
    private GameObject pisica1;
    [SerializeField]
    private GameObject pisica2;
    private Animator animatorPisica1;
    private Animator animatorPisica2;


    // Start is called before the first frame update
    void Start()
    {
        animatorPisica1 = pisica1.GetComponentInChildren<Animator>();
        animatorPisica2 = pisica2.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanta = Vector3.Distance(pisica1.transform.position, pisica2.transform.position);
        if (pisica1.transform.position.x > pisica2.transform.position.x) { 
            //de rotit pisica
        }
        Debug.Log("Distanta este: " + distanta.ToString());
        if (distanta > 0.4)
        {
            animatorPisica1.SetInteger("tranzitie", 1);
            animatorPisica2.SetInteger("tranzitie", 1);
        }
        else if (distanta < 0.3) {
            animatorPisica1.SetInteger("tranzitie", 2);
            animatorPisica2.SetInteger("tranzitie", 2);
        }
    }
}
