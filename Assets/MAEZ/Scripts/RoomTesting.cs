using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTesting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] walls; // 0 - Up 1 -Down 2 - Right 3- Left
    public GameObject[] doors;
    public bool[] status;

    void Start()
    {
        UpdateRoom(status);
    }

    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
        }
    }
}
