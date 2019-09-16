using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject fruta;
    public float tiempo;
    public float intervalo;
    public float fuerza;

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if(tiempo >= intervalo)
        {
            lanzarFruta();
            tiempo = 0;
        }
        
    }

    void lanzarFruta()
    {
        float numeroRandom = Random.Range(-5, 5);
        Vector3 direccionRandom = new Vector3(numeroRandom, fuerza);
        GameObject nuevaFruta = Instantiate(fruta, this.transform.position, Quaternion.identity);
        nuevaFruta.GetComponent<Rigidbody>().useGravity = true;
        nuevaFruta.GetComponent<Rigidbody>().AddForce(direccionRandom, ForceMode.Impulse);
    }
}
