using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CamFollow : MonoBehaviour
{
    public Transform followTransform;
    public Tilemap groundTilemap;
    public TilemapRenderer groundTilemapRenderer;

    private float xMin, xMax, yMin, yMax;
    private float camY, camX;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;

    private void Start()
    {
        // Calculate bounds using the TilemapRenderer's bounds property
        BoundsInt tilemapBounds = groundTilemap.cellBounds;
        Vector3Int minCell = tilemapBounds.min;
        Vector3Int maxCell = tilemapBounds.max;

        xMin = groundTilemapRenderer.bounds.min.x;
        xMax = groundTilemapRenderer.bounds.max.x;
        yMin = groundTilemapRenderer.bounds.min.y;
        yMax = groundTilemapRenderer.bounds.max.y;

        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthsize, yMax - camOrthsize);
        camX = Mathf.Clamp(followTransform.position.x, xMin + cameraRatio, xMax - cameraRatio);
        this.transform.position = new Vector3(camX, camY, this.transform.position.z);
    }
}
