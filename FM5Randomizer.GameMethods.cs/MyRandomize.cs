namespace FM5Randomizer.GameMethods;

public class MyRandomize
{
    public static void GameRandom(FileStream fs, List<long> enemyAddresses) 
        => RandomEnemy.RandomEnemyModel(fs, enemyAddresses);
}