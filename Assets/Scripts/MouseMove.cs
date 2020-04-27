using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{

    bool isMouseDragging;
    private GameObject target;
    private GameObject lastTarget;
    Vector3 offset;
    Vector3 screenPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //while mouse1 is pressed, objects can be grabbed
        //and pulled or pushed away with scrollwheel
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = ReturnClickedObject(out hitInfo);
            lastTarget = target;
            if (target != null && target.layer != 8 && target.layer != 5) //ignore world and ui layers
            {
                isMouseDragging = true;
                target.GetComponent<Collider>().enabled = false;
                //Debug.Log("grabbed object position :" + target.transform.position);
                //convert world position to screen position
                screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;

            if (lastTarget == null)
            {
                return;
            }
            else
            {
                lastTarget.GetComponent<Collider>().enabled = true;
            }

        }

        if (isMouseDragging == true)
        {

            //track mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);

            //convert screen position to world position with offset changes
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;

            //update target gameobject's current postion
            target.transform.position = currentPosition;
        }

    }

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject targetObject = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            targetObject = hit.collider.gameObject;
        }
        return targetObject;
    }

}
