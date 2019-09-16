using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruta : MonoBehaviour
{

    public float rotacionPorSegundos;
    public float rotacionRandom;
    public float tiempoDestruir;

    public GameObject arriba;
    public GameObject abajo;
    public float fuerza;
    GameObject mouseApuntador;

    public void cortar()
    {
        
        mouseApuntador = GameObject.Find("mouse apuntador");
        arriba.transform.parent = null;
        abajo.transform.parent = null;
        arriba.GetComponent<Rigidbody>().isKinematic = false;
        abajo.GetComponent<Rigidbody>().isKinematic = false;
        arriba.GetComponent<Rigidbody>().useGravity = true;
        abajo.GetComponent<Rigidbody>().useGravity = true;

        if(arriba.transform.position.x < abajo.transform.position.x)
        {
            if(arriba.transform.position.y < abajo.transform.position.y)
            {
                arriba.GetComponent<Rigidbody>().AddForce(new Vector3(-1,-1,0) * fuerza, ForceMode.Impulse);
                abajo.GetComponent<Rigidbody>().AddForce(new Vector3(1, 1, 0) * fuerza, ForceMode.Impulse);
            }
            else
            {
                arriba.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 1, 0) * fuerza, ForceMode.Impulse);
                abajo.GetComponent<Rigidbody>().AddForce(new Vector3(1, -1, 0) * fuerza, ForceMode.Impulse);
            }
        }
        else
        {
            if (arriba.transform.position.y < abajo.transform.position.y)
            {
                arriba.GetComponent<Rigidbody>().AddForce(new Vector3(1, -1, 0) * fuerza, ForceMode.Impulse);
                abajo.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 1, 0) * fuerza, ForceMode.Impulse);
            }
            else
            {
                arriba.GetComponent<Rigidbody>().AddForce(new Vector3(1, 1, 0) * fuerza, ForceMode.Impulse);
                abajo.GetComponent<Rigidbody>().AddForce(new Vector3(-1, -1, 0) * fuerza, ForceMode.Impulse);
            }
        }
        Destroy(arriba, 5);
        Destroy(abajo, 5);
        Destroy(this.gameObject);
        
    }

    private void OnEnable()
    {
        rotacionRandom = Random.Range(-1, 2);
        while(rotacionRandom == 0)
        {
            rotacionRandom = Random.Range(-1, 2);
        }
        Destroy(this.gameObject, tiempoDestruir);
    }
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 0, rotacionRandom * rotacionPorSegundos));

    }
}
