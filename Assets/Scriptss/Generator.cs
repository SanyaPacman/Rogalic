using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class Generator : MonoBehaviour
{
    [SerializeField] private int _numberRooms;
    [SerializeField] private GameObject[] roomsForGeneration;
    [SerializeField] private Map map;
    [SerializeField] private float roomWidth;
    [SerializeField] private float roomHeigth;
    [SerializeField] private NavMeshSurface2d navMeshSurface2d;

    public int numberRooms
    {
        get
        {
            return _numberRooms;
        }
        set
        {
            if (value<0)
            {
                return;
            }
            else
            {
                _numberRooms = value;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        map.GenerateMapSize(10,10);
        Generatemap(1);
        map.UpdateCellsData();
        navMeshSurface2d.BuildNavMesh();
    }

    private Vector2 scaler;
    public void Generatemap(int roomCount)
    {
       /* var random = new Unity.Mathematics.Random();
        int randomRoomIndex= random.NextInt(0, roomsForGeneration.Length-1);
        GameObject room = Instantiate(roomsForGeneration[randomRoomIndex]);*/
        scaler = new Vector2(map.width / 2, map.heihgt / 2);
        //scaler = new Vector2(map.width-1,map.heihgt-1);
        //var centerCell = map.MapCells[map.width/2,map.heihgt/2];
        var centerCell = map.MapCells[(int)scaler.x,(int)scaler.y];
        CreateRoom(centerCell.x,centerCell.y);
        //roomCount--;
        CreateRoomsArondCell(centerCell);
        foreach (var cellAraondCenter in centerCell.GetNeighbours())
        {
            CreateRoomsArondCell(cellAraondCenter);
        }
        
    }

    private void CreateRoomsArondCell(MapCell cell)
    {
        if (cell==null)
        {
            return;
        }
        foreach (var cellNeighbour in cell.GetNeighbours())
        {
            if (!cellNeighbour.HasData())
            {
                CreateRoom(cellNeighbour.x, cellNeighbour.y);
            }
        }
    }
    private void CreateRoom(int x, int y)
    {
        var random = new Unity.Mathematics.Random();
        int randomRoomIndex = Random.Range(0, roomsForGeneration.Length);// random.NextInt(0, roomsForGeneration.Length-1);
        GameObject room = Instantiate(roomsForGeneration[randomRoomIndex],transform);
        var cell = map.MapCells[x,y];
        cell.SetobjectInCell(room);
        Vector2 position = new Vector2((x-scaler.x)*roomWidth*2,(y-scaler.x)*roomHeigth*2-(y-map.heihgt/2));
        room.transform.localPosition = position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
