using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCoordinateSystem : MonoBehaviour
{
    public Transform player;
    private TileCoordinates _tileCoordinates;
    private void Start()
    {
        _tileCoordinates = GetComponent<TileCoordinates>();
    }

    void Update()
    {
        _tileCoordinates.x = Mathf.Floor((player.position.x + 10f) / 20f);
        _tileCoordinates.y = Mathf.Floor((player.position.y + 10f) / 20f);
    }
}
