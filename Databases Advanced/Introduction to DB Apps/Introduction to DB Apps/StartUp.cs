namespace Introduction_to_DB_Apps
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.CreateDatabase();
            engine.CreateTable();
            engine.InserValues();

        }
    }
}
