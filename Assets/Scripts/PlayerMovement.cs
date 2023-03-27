using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3f;
    [SerializeField]
    float rayLength = 1.4f;
    [SerializeField]
    float rayOffsetX = 0.5f;
    [SerializeField]
    float rayOffsetY = 0.5f;
    [SerializeField]
    float rayOffsetZ = 0.5f;


    Vector3 targetPosition;
    Vector3 startPosition;
    bool moving;
   
    void Update()
    {
        if (moving)
        {
            if (Vector3.Distance(startPosition, transform.position) > 1f)
            {
                transform.position = targetPosition;
                moving = false;
                return;
            }

            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;
        }


        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX, transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX + Vector3.forward * rayLength, Color.red, Time.deltaTime);
        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX, transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX + Vector3.forward * rayLength, Color.red, Time.deltaTime);

        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX, transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX + Vector3.back * rayLength, Color.red, Time.deltaTime);
        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX, transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX + Vector3.back * rayLength, Color.red, Time.deltaTime);

        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ, transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ + Vector3.left * rayLength, Color.red, Time.deltaTime);
        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ, transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ + Vector3.left * rayLength, Color.red, Time.deltaTime);

        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ, transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ + Vector3.right * rayLength, Color.red, Time.deltaTime);
        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ, transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ + Vector3.right * rayLength, Color.red, Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (CanMove(Vector3.forward))
            {
                targetPosition = transform.position + Vector3.forward;
                startPosition = transform.position;
                PushBox(Vector3.forward);
                moving = true;

            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (CanMove(Vector3.back))
            {
                targetPosition = transform.position + Vector3.back;
                startPosition = transform.position;
                PushBox(Vector3.back);
                moving = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (CanMove(Vector3.left))
            {
                targetPosition = transform.position + Vector3.left;
                startPosition = transform.position;
                PushBox(Vector3.left);
                moving = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (CanMove(Vector3.right))
            {
                targetPosition = transform.position + Vector3.right;
                startPosition = transform.position;
                PushBox(Vector3.right);
                moving = true;
            }
        }

    }

    bool CanMove(Vector3 direction)
    {
        RaycastHit hit;

        if ((Vector3.Equals(Vector3.forward, direction) || Vector3.Equals(Vector3.back, direction)))
        {
            if ((Physics.Raycast(transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX, direction, out hit, rayLength)) && ((hit.transform.gameObject.tag == "Wall")||(hit.transform.gameObject.tag == "Box" && !hit.transform.gameObject.GetComponent<BoxMovement>().CanMove(direction)))) return false;
            if ((Physics.Raycast(transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX, direction, out hit, rayLength)) && ((hit.transform.gameObject.tag == "Wall")|| (hit.transform.gameObject.tag == "Box" && !hit.transform.gameObject.GetComponent<BoxMovement>().CanMove(direction)))) return false;
        }
        else if (Vector3.Equals(Vector3.left, direction) || Vector3.Equals(Vector3.right, direction))
        {
            if ((Physics.Raycast(transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ, direction, out hit, rayLength)) && ((hit.transform.gameObject.tag == "Wall") || (hit.transform.gameObject.tag == "Box" && !hit.transform.gameObject.GetComponent<BoxMovement>().CanMove(direction)))) return false;
            if ((Physics.Raycast(transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ, direction, out hit, rayLength)) && (( hit.transform.gameObject.tag == "Wall") || (hit.transform.gameObject.tag == "Box" && !hit.transform.gameObject.GetComponent<BoxMovement>().CanMove(direction)))) return false;
        }
        

        return true;
    }
    void PushBox(Vector3 direction)
    {
        RaycastHit hit;


        if ((Vector3.Equals(Vector3.forward, direction) || Vector3.Equals(Vector3.back, direction)))
        {
            if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX, direction, out hit, rayLength) && hit.transform.gameObject.tag == "Box")
            {
                if (hit.transform.gameObject.GetComponent<BoxMovement>().CanMove(direction) && CanMove(direction))
                {
                    hit.transform.gameObject.transform.Translate(direction); transform.Translate(direction);
                }
            }
            if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX, direction, out hit, rayLength) && hit.transform.gameObject.tag == "Box")
            {
                if (hit.transform.gameObject.GetComponent<BoxMovement>().CanMove(direction) && CanMove(direction))
                {
                    hit.transform.gameObject.transform.Translate(direction); transform.Translate(direction);
                }
            }
        }
        else if (Vector3.Equals(Vector3.left, direction) || Vector3.Equals(Vector3.right, direction))
        {
            if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ, direction, out hit, rayLength) && hit.transform.gameObject.tag == "Box")
            {
                if (hit.transform.gameObject.GetComponent<BoxMovement>().CanMove(direction) && CanMove(direction))
                {
                    hit.transform.gameObject.transform.Translate(direction); transform.Translate(direction);
                }
            }
            if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ, direction, out hit, rayLength) && hit.transform.gameObject.tag == "Box")
            {
                if (hit.transform.gameObject.GetComponent<BoxMovement>().CanMove(direction) && CanMove(direction))
                {
                    hit.transform.gameObject.transform.Translate(direction); transform.Translate(direction);
                }
            }
        }
    }

}