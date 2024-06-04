using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public GameObject[] walls; // 0 - Up 1 -Down 2 - Right 3- Left
    public GameObject[] doors;

    public GameObject[] Segments;
    
    [SerializeField] public bool isHallway = false;

    [SerializeField] private bool GenerateClutter = false;
    [SerializeField] private  GameObject[] Clutter;

    public void UpdateRoom(bool[] status)
    {
        if (isHallway)
        {
            //if hallway shape is assigned, return. else continue and make a room
            if (UpdateHallway(status))
            {
                return;
            }
        }

        //up. down, right, left
        for (int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);

            // //10% chance of disabling both wall and door
            // if (Random.Range(0, 100) < 10 && validNeighbours[i])
            // {
            //     doors[i].SetActive(false);
            //     walls[i].SetActive(false);
            // }
        }

        AddClutter();
    }

    private bool UpdateHallway(bool[] status)
    {

        bool U, D, R, L;
        U = status[0];
        D = status[1];
        R = status[2];
        L = status[3];
        
        //up. down, right, left
        //segments: all, updown,leftright, 
        // upleft, upright, downleft, downright, 
        // LeftUpRight, UpRightDown, RightDownLeft, DownLeftUp, none

        if(U && D && R && L)
        {
            Segments[0].SetActive(true);
        }
        else if(U && D && !R && !L)
        {
            Segments[1].SetActive(true);
        }
        else if(!U && !D && R && L)
        {
            Segments[2].SetActive(true);
        }
        else if(U && !D && !R && L)
        {
            Segments[3].SetActive(true);
        }
        else if(U && !D && R && !L)
        {
            Segments[4].SetActive(true);
        }
        else if(!U && D && !R && L)
        {
            Segments[5].SetActive(true);
        }
        else if(!U && D && R && !L)
        {
            Segments[6].SetActive(true);
        }
        // LeftUpRight, UpRightDown, RightDownLeft, DownLeftUp, EndRoom

        else if(U && !D && R && L)
        {
            Segments[7].SetActive(true);
        }
        else if(U && D && R && !L)
        {
            Segments[8].SetActive(true);
        }
        else if(!U && D && R && L)
        {
            Segments[9].SetActive(true);
        }
        else if(U && D && !R && L)
        {
            Segments[10].SetActive(true);
        }
        else
        {
            //end room. 
            //1 entrance, no way out
            Segments[11].SetActive(true);

            for (int i = 0; i < Segments.Length; i++)
            {
                if (Segments[i].activeSelf == false)
                {
                    Destroy(Segments[i]);
                }
            }

            return false;
        }

        //delete the segment that is not active
        for (int i = 0; i < Segments.Length; i++)
        {
            if (Segments[i].activeSelf == false)
            {
                Destroy(Segments[i]);
            }
        }
        return true;
    }

    public void AddClutter()
    {
        if (Clutter.Length <= 2)
        {
            return;
        }
        if (GenerateClutter)
        {
            Debug.Log("Adding Clutter");
            for (int i = 0; i < Clutter.Length; i++)
            {
                if (Random.Range(0, 100) < 50)
                {
                    Clutter[i].SetActive(true);
                }
                else{
                    Clutter[i].SetActive(false);
                    Destroy(Clutter[i]);
                }
            }
        }
        else
        {
            for (int i = 0; i < Clutter.Length; i++)
            {
                Clutter[i].SetActive(false);
                Destroy(Clutter[i]);
            }
        }
    }
}