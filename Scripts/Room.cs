using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //public DockPoint dockPoint;
    public DockPoint[] dockPoints;
    public RoomArea roomArea;
    public RoomType roomType;

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
