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
    private GameObject transformModel1;
    private GameObject transformModel2;

    public float distantaOffset;
    void Start()
    {
        animatorPisica1 = pisica1.GetComponentInChildren<Animator>();
        animatorPisica2 = pisica2.GetComponentInChildren<Animator>();
        transformModel1 = GameObject.FindWithTag("EditorOnly");
        transformModel2 = GameObject.FindWithTag("Finish");

        transformModel1.transform.SetPositionAndRotation(transformModel1.transform.position, Quaternion.Euler(0, -90f, 0));
        transformModel2.transform.SetPositionAndRotation(transformModel2.transform.position, Quaternion.Euler(0, 90f, 0));
    }

    void Update()
    {
        float distanta = Vector3.Distance(pisica1.transform.position, pisica2.transform.position);
     
        if (distanta > distantaOffset)
        {
            animatorPisica1.SetInteger("tranzitie", 1);
            animatorPisica2.SetInteger("tranzitie", 1);
        }
        else{
            animatorPisica1.SetInteger("tranzitie", 2);
            animatorPisica2.SetInteger("tranzitie", 2);
        }


        float unghiRotatiePisica1 = transformModel1.transform.rotation.eulerAngles.y;
        float unghiRotatiePisica2 = transformModel2.transform.rotation.eulerAngles.y;

        unghiRotatiePisica1 %= 360;
        if (unghiRotatiePisica1 > 180)
        {
            unghiRotatiePisica1 = unghiRotatiePisica1 - 360;
        }
        unghiRotatiePisica2 %= 360;
        if (unghiRotatiePisica2 > 180)
        {
            unghiRotatiePisica2 = unghiRotatiePisica2 - 360;
        }

        Debug.Log("Distanta: " + distanta);

        if (transformModel1.transform.position.x > transformModel2.transform.position.x)
        {
            transformModel1.transform.SetPositionAndRotation(transformModel1.transform.position, Quaternion.Euler(0, -90f, 0));
            transformModel2.transform.SetPositionAndRotation(transformModel2.transform.position, Quaternion.Euler(0, 90f, 0));
        }
        else {
            transformModel2.transform.SetPositionAndRotation(transformModel2.transform.position, Quaternion.Euler(0, -90f, 0));
            transformModel1.transform.SetPositionAndRotation(transformModel1.transform.position, Quaternion.Euler(0, 90f, 0));
        }
    }
}
