using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apuntadorMouse : MonoBehaviour
{
    public LayerMask hitLayers;
    public Vector3 mousePuntoDeContacto;
    public ParticleSystem explosion;

    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
#if UNITY_EDITOR

        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))
        {
            transform.position = hit.point;
            mousePuntoDeContacto = hit.point;
            if(hit.transform.tag == "Respawn")
            {
                hit.transform.GetComponent<fruta>().cortar();
                ParticleSystem efecto = Instantiate(explosion, hit.transform.position, Quaternion.identity);
                efecto.Play();
                Destroy(efecto.gameObject, 0.5f);
            }
        }
#endif

#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Ray castPointAndroid = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(castPointAndroid, out hit, Mathf.Infinity, hitLayers))
                {
                    transform.position = hit.point;
                    mousePuntoDeContacto = hit.point;
                    if (hit.transform.tag == "Respawn")
                    {
                        hit.transform.GetComponent<fruta>().cortar();
                        ParticleSystem efecto = Instantiate(explosion, hit.transform.position, Quaternion.identity);
                        efecto.Play();
                        Destroy(efecto.gameObject, 0.5f);
                    }
                }
            }
        }
#endif
    }



}
