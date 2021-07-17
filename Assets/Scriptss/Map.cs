using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map: MonoBehaviour
{
    
    public MapCell[,] MapCells
    {
        private set;
        get;
    }

    public int width => MapCells.GetUpperBound(0) + 1;
    public int heihgt => MapCells.Length/width;

    private void CreateNeighbourLink()
    {
        MapCell east;
        MapCell west;
        MapCell north;
        MapCell south;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < heihgt; j++)
            {

                if (i == 0)
                    west = null;
                else
                    west = MapCells[i - 1, j];

                if (i == width-1)
                    east = null;
                else
                    east = MapCells[i + 1, j];
                
                
                if (j==0)
                    south = null;
                else
                    south = MapCells[i, j-1];

                if (j == heihgt-1)
                    north = null;
                else
                    north = MapCells[i, j+1];
                
                MapCells[i,j].SetNeighbourLinks(west,east,north,south);
            }
        }
    }
    public void GenerateMapSize(int _width, int _heihgt)
    {
        MapCells = new MapCell[_width, _heihgt];
        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < heihgt; j++)
            {
                MapCells[i, j] = new MapCell(i, j);
            }
        }
        CreateNeighbourLink();
    }

    private void Start()
    {
        //GenerateMapSize(6,10);
        
    }

    private List<MapCell> busyCells;
    public void UpdateCellsData()
    {
        busyCells=  MapCells.Cast<MapCell>().ToList().FindAll(item=>item.HasData());
    }
    private void DrawCell(MapCell cell)
    {
        var center = Vector3.zero;
        center.x = cell.x;
        center.y = cell.y;
        Gizmos.DrawWireSphere(center,0.5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        foreach (var cell in MapCells)
            DrawCell(cell);
        Gizmos.color=Color.yellow;
       // var Neighbour = MapCells[0, 0].GetNeighbours();
        foreach (var cell in busyCells)
            DrawCell(cell);
       /* Neighbour = MapCells[width-1 , 0].GetNeighbours();
        foreach (var cell in Neighbour)
            DrawCell(cell);
        Neighbour = MapCells[width-1, heihgt-1].GetNeighbours();
        foreach (var cell in Neighbour)
            DrawCell(cell);
        Neighbour = MapCells[0, heihgt-1].GetNeighbours();
        foreach (var cell in Neighbour)
            DrawCell(cell);
        Neighbour = MapCells[3, 5].GetNeighbours();
        foreach (var cell in Neighbour)
            DrawCell(cell);*/
    }
}
