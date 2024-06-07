using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private BoxCollider colliderFront = null;
    [SerializeField] private BoxCollider colliderBack = null;

    [SerializeField] private Animator DoorAnimator = null;
    [SerializeField] private bool isOpenedFront = false;
    [SerializeField] private bool isOpenedBack = false;
    [SerializeField] private bool isClosed = true;

    [SerializeField] private GameObject E_Label;
    [SerializeField] private float debounceTime = 0.5f; // time in seconds to ignore subsequent presses
    private bool canToggleDoor = true;

    void Start()
    {
        DoorAnimator = GetComponent<Animator>();
        isOpenedBack = false;
        isOpenedFront = false;
        isClosed = true;
        E_Label.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            E_Label.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!E_Label.activeSelf)
            {
                E_Label.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E) && canToggleDoor)
            {
                StartCoroutine(DebounceToggle());
                Debug.Log("E is pressed");
                if (isOpenedFront)
                {
                    DoorAnimator.Play("DoorCloseFront", 0, 0.0f);
                    isOpenedFront = false;
                    isClosed = true;
                }
                else if (isOpenedBack)
                {
                    DoorAnimator.Play("DoorCloseBack", 0, 0.0f);
                    isOpenedBack = false;
                    isClosed = true;
                }
                else if (isClosed)
                {
                    Debug.Log("Opening door");
                    if (colliderFront.bounds.Contains(other.transform.position))
                    {
                        DoorAnimator.Play("DoorOpenFront", 0, 0.0f);
                        Debug.Log("Door opened from front");
                        isOpenedFront = true;
                        isClosed = false;
                    }
                    else if (colliderBack.bounds.Contains(other.transform.position))
                    {
                        DoorAnimator.Play("DoorOpenBack", 0, 0.0f);
                        Debug.Log("Door opened from back");
                        isOpenedBack = true;
                        isClosed = false;
                    }
                }
            }
        }
    }

    private IEnumerator DebounceToggle()
    {
        canToggleDoor = false;
        yield return new WaitForSeconds(debounceTime);
        canToggleDoor = true;
    }
}
