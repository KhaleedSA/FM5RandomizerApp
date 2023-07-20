namespace FM5Randomizer.GameMethods;

public class MyRandomize
{
    public static void GameRandom(FileStream fs, List<long> enemyAddresses)
        => RandomEnemy.RandomWanzerModel(fs, enemyAddresses);
}