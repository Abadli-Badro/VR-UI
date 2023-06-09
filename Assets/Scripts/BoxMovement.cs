using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    //[SerializeField]
    //float moveSpeed = 0.5f;
    [SerializeField]
    float rayLength = 1f;
    [SerializeField]
    float rayOffsetX = 0.5f;
    [SerializeField]
    float rayOffsetY = 0.5f;
    [SerializeField]
    float rayOffsetZ = 0.5f;


    Vector3 targetPosition;
    Vector3 startPosition;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {


        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX, transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX + Vector3.forward * rayLength, Color.green, Time.deltaTime);
        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX, transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX + Vector3.forward * rayLength, Color.green, Time.deltaTime);

        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX, transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX + Vector3.back * rayLength, Color.green, Time.deltaTime);
        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX, transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX + Vector3.back * rayLength, Color.green, Time.deltaTime);

        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ, transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ + Vector3.left * rayLength, Color.green, Time.deltaTime);
        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ, transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ + Vector3.left * rayLength, Color.green, Time.deltaTime);

        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ, transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ + Vector3.right * rayLength, Color.green, Time.deltaTime);
        Debug.DrawLine(transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ, transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ + Vector3.right * rayLength, Color.green, Time.deltaTime);

    }
    public bool CanMove(Vector3 direction)
    {
        RaycastHit hit;
        if ((Vector3.Equals(Vector3.forward, direction) || Vector3.Equals(Vector3.back, direction)))
        {
            if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX, direction, out hit, rayLength) && (hit.transform.gameObject.CompareTag("Box") || hit.transform.gameObject.CompareTag("Wall"))) return false;
            if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX, direction, out hit, rayLength) && (hit.transform.gameObject.CompareTag("Box") || hit.transform.gameObject.CompareTag("Wall"))) return false;
        }
        else if (Vector3.Equals(Vector3.left, direction) || Vector3.Equals(Vector3.right, direction))
        {
            if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ, direction, out hit, rayLength) && (hit.transform.gameObject.CompareTag("Box") || hit.transform.gameObject.CompareTag("Wall"))) return false;
            if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ, direction, out hit, rayLength) && (hit.transform.gameObject.CompareTag("Box") || hit.transform.gameObject.CompareTag("Wall"))) return false;
        }

        return true;
    }

}
