using UnityEngine;
using System.Collections;

public class LevelGeneration : MonoBehaviour {

    public int levelSize = 2;
    public int roomSize = 250;
    public int wallThickness = 10;
    public GameObject wall;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

	// Use this for initialization
	void Start () {
        BuildWall();
        Generator();
	}
	
    //generates the level layout
    void Generator()
    {
        for (int i = -levelSize; i <= levelSize; i++)
           for (int j = -levelSize; j <= levelSize; j++)
           {
                if (i == 0 && j == 0)
                    //starting room
                    PresetStartRoom(i, j);
                else
                    //build a random room preset
                    BuildSection(Random.Range(1, 4), i, j);
           }
    }

    //outside boundaries
    void BuildWall()
    {
        int dist = (levelSize * roomSize) + (roomSize / 2);

        //build edges
        for(int i = -levelSize; i <= levelSize; i++)
        {
            int pos = i * roomSize;
            GameObject eastWall = Instantiate(wall, new Vector3(dist, pos), Quaternion.Euler(0, 0, 90)) as GameObject;
            GameObject westWall = Instantiate(wall, new Vector3(-dist, pos), Quaternion.Euler(0, 0, 90)) as GameObject;
            GameObject northWall = Instantiate(wall, new Vector3(pos, dist), Quaternion.Euler(0, 0, 0)) as GameObject;
            GameObject southWall = Instantiate(wall, new Vector3(pos, -dist), Quaternion.Euler(0, 0, 0)) as GameObject;

            //scale walls
            eastWall.transform.localScale = new Vector3(roomSize, wallThickness);
            westWall.transform.localScale = new Vector3(roomSize, wallThickness);
            northWall.transform.localScale = new Vector3(roomSize, wallThickness);
            southWall.transform.localScale = new Vector3(roomSize, wallThickness);
        }

        //build corners
        GameObject NEcorner = Instantiate(wall, new Vector3(dist, dist), Quaternion.Euler(0, 0, 0)) as GameObject;
        GameObject NWcorner = Instantiate(wall, new Vector3(-dist, dist), Quaternion.Euler(0, 0, 0)) as GameObject;
        GameObject SEcorner = Instantiate(wall, new Vector3(dist, -dist), Quaternion.Euler(0, 0, 0)) as GameObject;
        GameObject SWcorner = Instantiate(wall, new Vector3(-dist, -dist), Quaternion.Euler(0, 0, 0)) as GameObject;

        //scale corners
        NEcorner.transform.localScale = new Vector3(wallThickness * 2, wallThickness * 2);
        NWcorner.transform.localScale = new Vector3(wallThickness * 2, wallThickness * 2);
        SEcorner.transform.localScale = new Vector3(wallThickness * 2, wallThickness * 2);
        SWcorner.transform.localScale = new Vector3(wallThickness * 2, wallThickness * 2);
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
        Instantiate(enemy2, new Vector3(row, column), Quaternion.Euler(0, 0, 0));
    }

    void Preset3(int row, int column)
    {
        Instantiate(enemy3, new Vector3(row, column), Quaternion.Euler(0, 0, 0));
    }

    void Preset4(int row, int column)
    {
        Instantiate(enemy1, new Vector3(row, column), Quaternion.Euler(0, 0, 0));
    }

    void Preset5(int row, int column)
    {
        Instantiate(enemy1, new Vector3(row, column), Quaternion.Euler(0, 0, 0));
    }
}
