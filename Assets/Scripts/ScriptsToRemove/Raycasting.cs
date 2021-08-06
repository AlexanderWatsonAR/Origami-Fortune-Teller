using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    public GameObject text;
    public GameObject RaycastTarget;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = RaycastTarget.transform.position - gameObject.transform.position;
        RaycastHit hitInfo;
        Physics.Raycast(gameObject.transform.position, direction, out hitInfo, 25);
        //Physics.Raycast(gameObject.transform.position, Vector3.down, out hitInfo, 5);

        //float angle = Vector3.Angle(hitInfo.normal, transform.position);
        //Vector3 reflection = Vector3.Reflect(direction, hitInfo.normal);
        //text.transform.position = hitInfo.point;
        text.transform.forward = hitInfo.normal * -1;
        text.transform.position = hitInfo.point;
        

        //Debug.Log(reflection);
    }

    private void Update()
    {
        //Vector3 direction = RaycastTarget.transform.position - gameObject.transform.position;

        //Debug.DrawRay(gameObject.transform.position, direction, Color.red);

        //Vector3 direction = RaycastTarget.transform.position - gameObject.transform.position;
        //RaycastHit hitInfo;
        //Physics.Raycast(gameObject.transform.position, direction, out hitInfo, 25);

        //float angle = Vector3.Angle(hitInfo.normal, transform.position);
        //Vector3 reflection = Vector3.Reflect(direction, hitInfo.normal);

        //Debug.DrawRay(hitInfo.point, hitInfo.normal, Color.red);

    }
}
