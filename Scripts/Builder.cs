using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public GameObject[] prefabs;
    readonly List<Room> rooms = new List<Room>();
    public int doorIndex = 0;
    public int roomIndex = 0;
    public Room room;
    public bool building;
    public bool validating = false;
    private int validating_countdown = 0;
    // Start is called before the first frame update
    void Start()
    {
        building = true;
        GameObject go = Instantiate(prefabs[Random.Range(0,5)]);
        Room room = go.GetComponent<Room>();
        rooms.Add(room);
    }

    // Update is called once per frame
    void Update()
    {
        if(rooms.Count > roomIndex)
        {
            if(rooms[roomIndex].dockPoints.Length > doorIndex)
            {
                if(rooms[roomIndex].dockPoints[doorIndex].targetDock == null)
                {
                    if (validating)
                    {
                        if(validating_countdown-- < 0)
                        {
                            if (room.roomBlocked)
                            {
                                Destroy(room.gameObject);
                                spawnRoom();
                            }
                            else
                            {
                                validating = false;
                                rooms.Add(room);
                                rooms[roomIndex].dockPoints[doorIndex].targetDock = room.dockPoints[room.doorIndex];
                            }
                        }
                    }
                    else
                    {
                        spawnRoom();
                    }
                }
                else
                {
                    doorIndex++;
                }
            }
            else
            {
                roomIndex++;
                doorIndex = 0;
            }
        }
        else
        {
            building = false;
        }
    }
    private void spawnRoom()
    {
        // spawn a room and make sure it's docked.
        List<GameObject> rwd = RoomsWithDoor(rooms[roomIndex].dockPoints[doorIndex].doorTag);
        GameObject go = Instantiate(rwd[Random.Range(0, rwd.Count)]);
        room = go.GetComponent<Room>();
        //rooms.Add(room);
        DockPoint[] dp = room.GetDoor(rooms[roomIndex].dockPoints[doorIndex].doorTag);
        if (dp.Length > 0)
        {
            //dp[0].LinkDock(rooms[roomIndex].dockPoints[doorIndex]);
            room.AttatchRoom(rooms[roomIndex].dockPoints[doorIndex]);
        }
        validating = true;
        validating_countdown = 10;
    }

    public List<GameObject> RoomsWithDoor(DoorTag tag)
    {
        List<GameObject> rwd = new List<GameObject>();
        foreach(GameObject prefab in prefabs)
        {
            Room room = prefab.GetComponent<Room>();
            if (room.HasDoor(tag))
            {
                rwd.Add(prefab);
            }
        }
        return rwd;
    }

}
