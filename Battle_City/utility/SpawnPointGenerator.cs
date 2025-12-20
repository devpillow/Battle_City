using Battle_City.elements;
using System.Collections.Generic;
using System.Drawing;
using System;

public class WallMapGenerator
{
    private readonly int width;
    private readonly int height;
    private readonly Random random;

    public WallMapGenerator(int width, int height)
    {
        this.width = width;
        this.height = height;
        this.random = new Random();
    }

    public int[,] GenerateWallMap()
    {
        int[,] wallMap = new int[width, height];

        // Fill the map with walls and empty spaces
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                wallMap[x, y] = random.Next(0, 5); // Random values between 0 and 4
            }
        }

        return wallMap;
    }
}

public class SpawnPointGenerator
{
    private readonly int[,] wallMap; // Use int[,] for wall map
    private readonly List<EnemyTank> spawnedEnemies;
    private readonly int enemyTankSize;

    public SpawnPointGenerator(int[,] wallMap, List<EnemyTank> spawnedEnemies, int enemyTankSize = 2)
    {
        this.wallMap = wallMap;
        this.spawnedEnemies = spawnedEnemies;
        this.enemyTankSize = enemyTankSize;
    }

    public Point? GetRandomSpawnPoint(int maxYBound)
    {
        Random random = new Random();
        int maxX = wallMap.GetLength(0);
        int maxY = Math.Min(wallMap.GetLength(1), maxYBound);

        for (int attempt = 0; attempt < 100; attempt++)
        {
            int x = random.Next(0, maxX - enemyTankSize-1);
            int y = random.Next(0, maxY - enemyTankSize-1);

            if (IsValidSpawnPoint(x, y))
            {
                return new Point(x, y);
            }
            
        }

        return null;
    }

    private bool IsValidSpawnPoint(int x, int y)
    {
        // Check if the area is occupied by walls (values > 0)
        /* for (int i = 0; i < enemyTankSize; i++)
         {
             for (int j = 0; j < enemyTankSize; j++)
             {
                 if (wallMap[x + i, y + j] > 0) // Non-zero values indicate walls
                 {
                     return false;
                 }
             }
         }*/
        if (wallMap[y, x] != 0 || wallMap[y + 1, x] != 0 || wallMap[y, x + 1] != 0 || wallMap[y + 1, x + 1] != 0) { return false; }

        foreach (var enemy in spawnedEnemies)
        {
            Rectangle enemyRect = new Rectangle(enemy.Location, enemy.Size);
            Rectangle newEnemyRect = new Rectangle(x * 30, y * 30, enemyTankSize * 30, enemyTankSize * 30);

            if (enemyRect.IntersectsWith(newEnemyRect))
            {
                return false;
            }
        }

        return true;
    }
}



