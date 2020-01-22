using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomArea : MonoBehaviour
{
    public bool roomBlocked = false;
    private Room room;
    // Start is called before the first frame update
    void Start()
    {
        room = transform.parent.GetComponent<Room>();
    }

    // Update is called once per frame
    void Update()
    {
        //roomBlocked = false;
    }
    private void OnTriggerStay(Collider other)
    {
        RoomArea otherArea = other.GetComponent<RoomArea>();
        if (otherArea == null) return;
        roomBlocked = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        RoomArea otherArea = other.GetComponent<RoomArea>();
        if (otherArea == null) return;
        roomBlocked = true;
    }
    private void OnTriggerExit(Collider other)
    {
        roomBlocked = false;
    }
}
