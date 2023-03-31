using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelElement {
    public string character;
    public GameObject prefab;
}

public class LevelBuilder : MonoBehaviour {
    public int currentLevel;
    public List<LevelElement> elements;
    private Level level;
    public float offsetX = 0f;
    public float offsetY = 0f;
    public float offsetZ = 0f;
    public float scale = 0.2f;

    GameObject GetPrefab(char c) {
        LevelElement levelElement = elements.Find(le => le.character == c.ToString());
        if (levelElement != null) {
            return levelElement.prefab;
        }
        else {
            return null;
        }
    }

    public void NextLevel() {
        currentLevel++;
        if (currentLevel >= GetComponent<Levels>().levels.Count) {
            currentLevel = 0;
        }
    }

    public void Build() {
        level = GetComponent<Levels>().levels[currentLevel];
        int startX = -level.width / 2;
        float x = startX + offsetX;
        float y = (-level.height / 2) + offsetY;
        foreach (var row in level.rows) {
            foreach (var c in row) {
                Debug.Log(c);
                if (c == '3') {
                    GameObject prefabM = GetPrefab('2');//moving box
                    GameObject prefabE = GetPrefab('1');//end
                    if (prefabM != null && prefabE != null) {
                        Instantiate(prefabM, new Vector3(x, y, offsetZ), Quaternion.identity);
                        Instantiate(prefabE, new Vector3(x, y, offsetZ), Quaternion.identity);
                    }
                }
                else if (c == '5') {
                    GameObject prefabM = GetPrefab('5');//player
                    GameObject prefabE = GetPrefab('0');//floor
                    if (prefabM != null && prefabE != null) {
                        Instantiate(prefabM, new Vector3(x, y, offsetZ), Quaternion.identity);
                        Instantiate(prefabE, new Vector3(x, y, offsetZ), Quaternion.identity);
                    }
                }
                else if (c == '2') {
                    GameObject prefabM = GetPrefab('2');//box
                    GameObject prefabE = GetPrefab('0');//floor
                    if (prefabM != null && prefabE != null) {
                        Instantiate(prefabM, new Vector3(x, y, offsetZ), Quaternion.identity);
                        Instantiate(prefabE, new Vector3(x, y, offsetZ), Quaternion.identity);
                    }
                }
                else if (c == '4') {
                    GameObject prefabM = GetPrefab('4');//walls
                    GameObject prefabE = GetPrefab('0');//floor
                    if (prefabM != null && prefabE != null) {
                        Instantiate(prefabM, new Vector3(x, y, offsetZ), Quaternion.identity);
                        Instantiate(prefabE, new Vector3(x, y, offsetZ), Quaternion.identity);
                    }
                }
                else {
                    GameObject prefab = GetPrefab(c);
                    if (prefab != null) {
                        Debug.Log(prefab.name);
                        Instantiate(prefab, new Vector3(x, y, offsetZ), Quaternion.identity);
                    }
                }
                x+= scale;
            }
            y+=scale;
            x = startX + offsetX;
        }
    }

}
