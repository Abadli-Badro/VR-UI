using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level {
    public List<string> rows = new List<string>();
    public int height { get { return rows.Count; } }
    public int width = 8;
}

public class Levels : MonoBehaviour {
    public TextAsset textFile;
    public List<Level> levels = new List<Level>();

    private void Awake() {
        string completeText = textFile.text;
        string[] lines = completeText.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        Debug.Log("Number of lines: " + lines.Length);
        foreach (string line in lines) {
            Level level = new Level();
            for (var i = 0; i < line.Length; i += 6) {
                level.rows.Add(line.Substring(i, Mathf.Min(6, line.Length - i)));
            }
            List<string> r = decorateLevelRows(level.rows);
            level.rows.Clear();
            level.rows.AddRange(r);
            levels.Add(level);
        }
    }

    private List<string> decorateLevelRows(List<string> levelRows) {
        List<string> rows = new List<string> {
            "44444444"
        };
        foreach (string line in levelRows) {
            string decoratedLine = "4" + line + "4";
            rows.Add(decoratedLine);
        }
        rows.Add("44444444");
        return rows;
    }
}


