using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCell
{
    public int x { get; private set; }
    public int y{ get; private set; }
    public object objectInCell { get; private set; }
    public MapCell westNeighbour { get; private set; }//запад
    public MapCell eastNeighbour { get; private set; }//восток
    public MapCell northNeighbour { get; private set; }//север
    public MapCell southNeighbour { get; private set; }//юг
    public MapCell(int X, int Y,object ObjectInCell=null)
    {
        x = X;
        y = Y;
        objectInCell = ObjectInCell;
    }

    public void SetobjectInCell(object ObjectInCell)
    {
        objectInCell = ObjectInCell;
    }
    public void SetNeighbourLinks(MapCell _westNeighbour,MapCell _eastNeighbour,MapCell _northNeighbour,MapCell _southNeighbour)
    {
        northNeighbour = _northNeighbour;
        southNeighbour = _southNeighbour;
        eastNeighbour = _eastNeighbour;
        westNeighbour = _westNeighbour;
    }

    public MapCell[] GetNeighbours()
    {
        var neighbours= new List<MapCell>(0);
        if (westNeighbour!=null)
            neighbours.Add(westNeighbour);
        if (eastNeighbour!=null)
            neighbours.Add(eastNeighbour);
        if (northNeighbour!=null)
            neighbours.Add(northNeighbour);
        if (southNeighbour!=null)
            neighbours.Add(southNeighbour);
        return neighbours.ToArray();
    }

    public bool HasData()
    {
        return objectInCell != null;
    }
    
}
