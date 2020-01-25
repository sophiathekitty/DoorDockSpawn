using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //public DockPoint dockPoint;
    public DockPoint[] dockPoints;
    public RoomArea roomArea;
    public RoomType roomType;

    public int doorIndex = 0;

    public bool roomBlocked
    {
        get
        {
            if (roomArea == null) return false;
            return roomArea.roomBlocked;
        }
    }

    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;
    // Start is called before the first frame update
    void Start()
    {
        dockPoints = GetComponentsInChildren<DockPoint>();
        roomArea = GetComponentInChildren<RoomArea>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        //dockPoint.AlignDock();

    }
    
    // Update is called once per frame
    void Update()
    {
        return;
        //AlignDock();
        if (roomArea.roomBlocked)
        {
            meshRenderer.enabled = false;
            meshCollider.enabled = false;
        }
        else
        {
            meshRenderer.enabled = true;
            meshCollider.enabled = true;
        }
    }
    public bool HasDoor(DoorTag tag)
    {
        foreach (DockPoint dock in dockPoints)
        {
            if (dock == null)
                Debug.LogError(gameObject.name + " missing docks");
            if (dock.doorTag == tag)
            {
                return true;
            }
        }
        return false;
    }
    public DockPoint[] GetDoor(DoorTag tag)
    {
        List<DockPoint> docks = new List<DockPoint>();
        foreach(DockPoint dock in dockPoints)
        {
            if(dock.doorTag == tag)
            {
                docks.Add(dock);
            }
        }
        return docks.ToArray();
    }

    public void AttatchRoom(DockPoint dock)
    {
        DockPoint[] doors = GetDoor(dock.doorTag);
        doorIndex = Random.Range(0, doors.Length);
        doors[doorIndex].targetDock = dock;
        doors[doorIndex].AlignDock();
    }

    /// <summary>
    /// 
    /// </summary>
    /*
    public void OnDrawGizmos()
    {

        Gizmos.matrix = transform.localToWorldMatrix;
        if (roomType != null && roomArea != null)
        {
            BoxCollider box = roomArea.GetComponent<BoxCollider>();
            if(box != null)
            {
                Gizmos.color = new Color(roomType.color.r, roomType.color.g, roomType.color.b, roomType.color.a);
                Gizmos.DrawCube(roomArea.transform.position, box.size * roomArea.transform.localScale.x);
            }
        }

    }


    /// <summary>
    /// 
    /// </summary>
    public void OnDrawGizmosSelected()
    {

        Gizmos.matrix = transform.localToWorldMatrix;
        if (roomType != null && roomArea != null)
        {
            BoxCollider box = roomArea.GetComponent<BoxCollider>();
            if (box != null)
            {
                Gizmos.color = new Color(roomType.color.r, roomType.color.g, roomType.color.b, 0.75f);
                Gizmos.DrawCube(roomArea.transform.position, box.size * roomArea.transform.localScale.x);
            }
        }

    }
    */
}
