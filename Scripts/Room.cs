using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public DockPoint dockPoint;
    public DockPoint[] dockPoints;
    public RoomArea roomArea;

    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;
    // Start is called before the first frame update
    void Start()
    {
        dockPoints = GetComponentsInChildren<DockPoint>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        dockPoint.AlignDock();

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
    /*
    public Vector3 OffsetPossition()
    {
        return new Vector3(
                            targetDock.transform.position.x - dockPoint.transform.localPosition.x,
                            targetDock.transform.position.y - dockPoint.transform.localPosition.y,
                            targetDock.transform.position.z - dockPoint.transform.localPosition.z);
    }

    public void AlignDock()
    {
        if (targetDock == null || targetDock.doorTag != dockPoint.doorTag) return;
        transform.position = OffsetPossition();
        if(dockPoint.doorTag.mirror)
            transform.RotateAround(dockPoint.transform.position,Vector3.up, targetDock.transform.eulerAngles.y + dockPoint.transform.localEulerAngles.y);
        else
            transform.RotateAround(dockPoint.transform.position, Vector3.up, targetDock.transform.eulerAngles.y - dockPoint.transform.localEulerAngles.y);

    }
    */
}
