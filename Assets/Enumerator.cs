using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Level { Level1, Level2, Level3, Level4, Level5 };
public class LevelUtility {
    public static Level currentLevel;
    public void Next()
    {
        currentLevel++;
    }
}
