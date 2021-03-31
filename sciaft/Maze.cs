using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [System.Serializable]
    public class Cell
    {
        public bool visited;
        public GameObject north; //1
        public GameObject south; //4
        public GameObject east; //2
        public GameObject west; //3
    }
    public GameObject wall;
    public float walllength = 1.0f;
    public int xSize = 5;
    public int ySize = 5;
    private Vector3 initialPos;
    private GameObject wallHolder;
    //CreateCells
    public Cell[] cells;
    //Neighbour
    public int currentCell = 0;
    private int totalcells;

    //CreateMaze
    private int visitedCells = 0;
    private bool start = false;
    private int currentNeighbour = 0;
    private List<int> lastCells;
    private int backingUp;
    private int wallToBreak = 0;

    // Start is called before the first frame update
    void Start()
    {
        CreateWalls();
    }

    void CreateWalls()
    {
        wallHolder = new GameObject();
        wallHolder.name = "Maze";
        initialPos = new Vector3(((-xSize / 2) + walllength / 2), 0, ((-ySize / 2) + walllength / 2));
        Vector3 myPos = initialPos;
        GameObject MazeWall;
        // ทาง แกน X
        for(int i = 0; i<ySize; i++)
        {
            for(int j = 0; j <= xSize; j++)
            {
                myPos = new Vector3(initialPos.x + (j * walllength) - walllength / 2 , 0, initialPos.z + (i * walllength )- walllength / 2);
                MazeWall = Instantiate(wall, myPos, Quaternion.identity) as GameObject;
                MazeWall.transform.parent = wallHolder.transform;
            }
        }
        // ทาง แกน Y
        for (int i = 0; i <= ySize; i++)
        {
            for (int j = 0; j < xSize; j++)
            {
                myPos = new Vector3(initialPos.x + (j * walllength) , 0, initialPos.z + (i * walllength) - walllength );
                MazeWall = Instantiate(wall, myPos, Quaternion.Euler(0,90,0)) as GameObject;
                MazeWall.transform.parent = wallHolder.transform;
            }
        }

        CreateCells();
    }

    void CreateCells()
    {
        lastCells = new List<int>();
        lastCells.Clear();
        totalcells = xSize * ySize;

        //GameObject[] allWall ;
        int childern = wallHolder.transform.childCount;
        GameObject[] allWall = new GameObject[childern];
        cells = new Cell[xSize * ySize];

        int EW = 0;
        int childProcess = 0;
        int termCount = 0;
        //Get all children to allwalls and name it
        for(int i = 0; i<childern;i++)
        {
            allWall[i] = wallHolder.transform.GetChild(i).gameObject;
            allWall[i].transform.GetChild(0).GetComponent<TextMesh>().text = i.ToString(); //TEXT
        }

        //Assign walls to cells
        for(int i = 0; i<cells.Length; i++ )
        {
            if(termCount == xSize)
            {
                EW++;
                termCount = 0;
            }
            cells[i] = new Cell();
            cells[i].west = allWall[EW];
            cells[i].south = allWall[childProcess + (xSize + 1) * ySize];

            EW++;
            termCount++;
            childProcess++;

            cells[i].east = allWall[EW];
            cells[i].north = allWall[(childProcess + (xSize + 1) * ySize) + xSize-1];
        }

        CreateMaze();
    }

    void CreateMaze()
    {
        if(visitedCells < totalcells)
        {
            if(start)
            {
                Neighbour();
                if(cells[currentNeighbour].visited == false && cells[currentCell].visited == true)
                {
                    Breakwall();
                    cells[currentNeighbour].visited = true;
                    visitedCells++;
                    lastCells.Add(currentCell);
                    currentCell = currentNeighbour;
                    if(lastCells.Count > 0)
                    {
                        backingUp = lastCells.Count - 1;
                    }
                }
            }
            else
            {
                currentCell = Random.Range(0, totalcells);
                cells[currentCell].visited = true;
                visitedCells++;
                start = true;
            }
            Invoke("CreateMaze", 0.0f); 
        } 
    }
    void Breakwall()
    {
        switch(wallToBreak)
        {
            case 1: Destroy(cells[currentCell].north); break;
            case 2: Destroy(cells[currentCell].east); break;
            case 3: Destroy(cells[currentCell].west); break;
            case 4: Destroy(cells[currentCell].south); break;
        }
    }

    void Neighbour()
    {
        totalcells = xSize * ySize;
        int length = 0;
        int[] neighbours = new int[4];
        int[] connectingWall = new int[4];
        int check = (currentCell + 1) / xSize;
        check -= 1;
        check *= xSize;
        check += xSize;

        //West
        if(currentCell -1 >= 0 && currentCell != check)
        {
            if(cells[currentCell - 1].visited == false)
            {
                neighbours[length] = currentCell - 1;
                connectingWall[length] = 3;
                length++;
            }
        }

        //East
        if (currentCell + 1 < totalcells && (currentCell + 1 ) != check)
        {
            if (cells[currentCell + 1].visited == false)
            {
                neighbours[length] = currentCell + 1;
                connectingWall[length] = 2;
                length++;
            }
        }
        //North
        if (currentCell + xSize < totalcells)
        {
            if (cells[currentCell + xSize].visited == false)
            {
                neighbours[length] = currentCell + xSize;
                connectingWall[length] = 1;
                length++;
            }
        }
        //South
        if (currentCell - xSize >= 0)
        {
            if (cells[currentCell - xSize].visited == false)
            {
                neighbours[length] = currentCell - xSize;
                connectingWall[length] = 4;
                length++;
            }
        }

       // for(int i=0; i<length; i++)
       // {
        //    print(neighbours[i]);
       // }

        if(length != 0)
        {
            int theChosen = Random.Range(0, length);
            currentNeighbour = neighbours[theChosen];
            wallToBreak = connectingWall[theChosen];
        }
        else
        {
            if(backingUp > 0)
            {
                currentCell = lastCells[backingUp];
                backingUp--;
            }
        }
    }
}
