using UnityEngine;
using System.Collections;

public class LevelGeneration : MonoBehaviour {

    public int levelSize;
    public int roomSize = 20;
    public int wallThickness = 10;
    public GameObject wall;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject terrainDirt;
    public GameObject terrainSand;
    public GameObject terrainGrass;
    public GameObject outerBounds;

	// Use this for initialization
	void Start () {
        levelSize = PlayerPrefs.GetInt("levelNum");
        BuildWall();
        Generator();
        OutsideBoundaries();
        Time.timeScale = 1;
	}
	
    void Generator() //generates the level layout
    {
        for (int i = -levelSize; i <= levelSize; i++)
           for (int j = -levelSize; j <= levelSize; j++)
           {
                if (i == 0 && j == 0)
                    PresetStartRoom(i, j); //starting room
                else
                    BuildSection(Random.Range(1, 2), i, j); //build a random room preset

                GameObject terrain = Instantiate(terrainDirt, new Vector3(i * roomSize, j * roomSize), Quaternion.Euler(0, 0, 0)) as GameObject;
                terrain.transform.localScale = new Vector3(roomSize,roomSize);
            }
    }

    void BuildWall() //outside boundaries
    {
        int dist = (levelSize * roomSize) + (roomSize / 2) + (wallThickness / 2);

        //build edges
        for(int i = -levelSize; i <= levelSize; i++)
        {
            int pos = i * roomSize;
            GameObject eastWall = Instantiate(wall, new Vector3(dist, pos), Quaternion.Euler(0, 0, 90)) as GameObject;
            GameObject westWall = Instantiate(wall, new Vector3(-dist, pos), Quaternion.Euler(0, 0, 90)) as GameObject;
            GameObject northWall = Instantiate(wall, new Vector3(pos, dist), Quaternion.Euler(0, 0, 0)) as GameObject;
            GameObject southWall = Instantiate(wall, new Vector3(pos, -dist), Quaternion.Euler(0, 0, 0)) as GameObject;

            //scale walls
            Vector3 wallScale = new Vector3(roomSize, wallThickness);
            eastWall.transform.localScale = wallScale;
            westWall.transform.localScale = wallScale;
            northWall.transform.localScale = wallScale;
            southWall.transform.localScale = wallScale;
        }

        //build corners
        GameObject NEcorner = Instantiate(wall, new Vector3(dist, dist), Quaternion.Euler(0, 0, 0)) as GameObject;
        GameObject NWcorner = Instantiate(wall, new Vector3(-dist, dist), Quaternion.Euler(0, 0, 0)) as GameObject;
        GameObject SEcorner = Instantiate(wall, new Vector3(dist, -dist), Quaternion.Euler(0, 0, 0)) as GameObject;
        GameObject SWcorner = Instantiate(wall, new Vector3(-dist, -dist), Quaternion.Euler(0, 0, 0)) as GameObject;

        //scale corners
        Vector3 cornerScale = new Vector3(wallThickness, wallThickness);
        NEcorner.transform.localScale = cornerScale;
        NWcorner.transform.localScale = cornerScale;
        SEcorner.transform.localScale = cornerScale;
        SWcorner.transform.localScale = cornerScale;
    }

    void BuildSection(int type, int row, int column)
    {
        //set location of nodes
        row = row * roomSize;
        column = column * roomSize;

        //choose a preset
        switch (type)
        {
            case 1:
                Preset1(row, column);
                break;
            case 2:
                Preset2(row, column);
                break;
            case 3:
                Preset3(row, column);
                break;
            case 4:
                Preset4(row, column);
                break;
            case 5:
                Preset5(row, column);
                break;

        }
    }

    void OutsideBoundaries()
    {
        outerBounds.transform.localScale = new Vector3(roomSize, roomSize);

        int overSize = levelSize + 2;
        for (int i = -overSize; i <= overSize; i++)
            for (int j = -overSize; j <= overSize; j++)
            {
                if (i < -levelSize || i > levelSize)
                    Instantiate(outerBounds, new Vector3(i * roomSize, j * roomSize), Quaternion.identity);
                else if (j < -levelSize || j > levelSize)
                    Instantiate(outerBounds, new Vector3(i * roomSize, j * roomSize), Quaternion.identity);
            }
    }

    //start room preset
    void PresetStartRoom(int row, int column)
    {

    }

    //other room presets
    void Preset1(int row, int column)
    {
        Instantiate(enemy1, new Vector3(row, column), Quaternion.Euler(0, 0, 0));
    }

    void Preset2(int row, int column)
    {
        //enemies
        Instantiate(enemy2, new Vector3(row + 5, column + 5), Quaternion.Euler(0, 0, 0));
        Instantiate(enemy2, new Vector3(row - 5, column + 5), Quaternion.Euler(0, 0, 0));
        Instantiate(enemy2, new Vector3(row + 5, column - 5), Quaternion.Euler(0, 0, 0));
        Instantiate(enemy2, new Vector3(row - 5, column - 5), Quaternion.Euler(0, 0, 0));

        //doodads
    }

    void Preset3(int row, int column)
    {
        //enemies
        Instantiate(enemy3, new Vector3(row, column + 5), Quaternion.Euler(0, 0, 0));
        Instantiate(enemy3, new Vector3(row, column - 5), Quaternion.Euler(0, 0, 0));
        Instantiate(enemy3, new Vector3(row + 5, column), Quaternion.Euler(0, 0, 0));
        Instantiate(enemy3, new Vector3(row - 5, column), Quaternion.Euler(0, 0, 0));

        //doodads
    }

    void Preset4(int row, int column)
    {
        Instantiate(enemy1, new Vector3(row + 5, column), Quaternion.Euler(0, 0, 0));
        Instantiate(enemy1, new Vector3(row - 5, column), Quaternion.Euler(0, 0, 0));
    }

    void Preset5(int row, int column)
    {
        Instantiate(enemy1, new Vector3(row, column), Quaternion.Euler(0, 0, 0));
    }
}
