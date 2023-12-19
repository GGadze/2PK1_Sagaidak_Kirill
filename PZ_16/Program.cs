
namespace ConsoleApp8
{
    internal class Program
    {
        
        static int mapSize = 25; //размер карты
        static char[,] map = new char[mapSize, mapSize + 1]; //карта
        //координаты на карте игрока
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;

        static byte enemies = 10; //количество врагов
        static byte buffs = 5; //количество усилений
        static int health = 5;  // количество аптечек

        static int enemiesCount = 10;
        static int enemiesCountForBoss = 1; 
        //параметры консоли
        static int winHeight = 40;
        static int winWidth = 100;

        //параметры игрока
        static int playerHP = 50;
        static int playerStrong = 10;
        static int playerStepCount = 0;

        static byte enemyStrong = 5;
        static int enemyHP = 30;

        static int bossHP = 500;
        static int bossStrong = 20;
        static int bossCount = 0;
        static bool isBoss;
        static bool isBossFight = false;
        static bool bossIsRight;

        static int buffCount;

        static bool isAlive = true;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(winWidth, winHeight);
            StartGame();
        }


        /// <summary>
        /// генерация карты с расставлением врагов, аптечек, баффов
        /// </summary>
        static void GenerationMap()
        {
            Random random = new Random();
            //создание пустой карты
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = '_';
                }
            }

            map[playerY, playerX] = 'P'; // в чередину карты ставится игрок

            //временные координаты для проверки занятости ячейки
            int x;
            int y;

            while (bossIsRight)
            {
                x = random.Next(1, mapSize - 5);
                y = random.Next(1, mapSize - 5);
                if (map[x, y] == '_' && map[x + 1, y] != 'P' && map[x - 1, y] != 'P' && map[x, y + 1] != 'P' && map[x, y - 1] != 'P'
                    && map[x + 1, y - 1] != 'P' && map[x - 1, y - 1] != 'P' && map[x + 1, y + 1] != 'P' && map[x - 1, y + 1] != 'P'
                     && map[x - 1, y + 2] != 'P' && map[x + 1, y + 2] != 'P' && map[x, y + 3] != 'P' && map[x - 1, y + 3] != 'P'
                      && map[x + 1, y + 3] != 'P' &&  map[x, y + 2] != 'P')
                {
                    map[x, y] = 'O'; map[x, y + 1] = '-'; map[x, y + 2] = 'O';
                    map[x, y - 1] = '▒'; map[x + 1, y - 1] = '▒'; map[x - 1, y - 1] = '▒';
                    map[x + 1, y] = '▒'; map[x - 1, y] = '▒'; map[x - 1, y + 1] = '▒';
                    map[x - 1, y + 2] = '▒'; map[x + 1, y + 2] = '▒'; map[x, y + 3] = '▒';
                    map[x + 1, y + 3] = '▒'; map[x - 1, y + 3] = '▒';
                    bossIsRight = false;
                }
            }
            //добавление врагов
            while (enemies > 0)
            {
                x = random.Next(1, mapSize - 3);
                y = random.Next(1, mapSize - 3);

                //если ячейка пуста  - туда добавляется враг
                if (map[x, y] == '_' && map[x + 1, y] != 'E' && map[x - 1, y] != 'E' && map[x, y + 1] != 'E' && map[x, y - 1] != 'E'
                    && map[x + 1, y - 1] != 'E' && map[x - 1, y - 1] != 'E' && map[x + 1, y + 1] != 'E' && map[x - 1, y + 1] != 'E')
                {
                    map[x, y] = 'E';
                    enemies--; //при добавлении врагов уменьшается количество нерасставленных врагов
                }
            }
            //добавление баффов
            while (buffs > 0)
            {
                x = random.Next(1, mapSize - 1);
                y = random.Next(1, mapSize - 1);

                if (map[x, y] == '_' && map[x + 1, y] != 'B' && map[x - 1, y] != 'B' && map[x, y + 1] != 'B' && map[x, y - 1] != 'B'
                    && map[x + 1, y - 1] != 'B' && map[x - 1, y - 1] != 'B' && map[x + 1, y + 1] != 'B' && map[x - 1, y + 1] != 'B')
                {
                    map[x, y] = 'B';
                    buffs--;
                }
            }
            //добавление аптечек
            while (health > 0)
            {
                x = random.Next(1, mapSize - 3);
                y = random.Next(1, mapSize - 3);

                if (map[x, y] == '_' && map[x + 1, y] != 'H' && map[x - 1, y] != 'H' && map[x, y + 1] != 'H' && map[x, y - 1] != 'H'
                    && map[x + 1, y - 1] != 'H' && map[x - 1, y - 1] != 'H' && map[x + 1, y + 1] != 'H' && map[x - 1, y + 1] != 'H')
                {
                    map[x, y] = 'H';
                    health--;
                }
            }

            UpdateMap(); //отображение заполненной карты на консоли

            Console.SetCursorPosition(0, 28); //позиция курсора для подсчета шагов
            Console.Write($"Шагов сделано: {playerStepCount}");

            Console.SetCursorPosition(0, 29);
            Console.Write($"Сила удара: {playerStrong}");

            Console.SetCursorPosition(0, 30);
            Console.Write($"Здоровье игрока: {playerHP}");
        }
        /// <summary>
        /// перемещение персонажа
        /// </summary>
        static void Move()
        {
            //предыдущие координаты игрока
            int playerOldY;
            int playerOldX;

            while (isAlive)
            {
                playerOldX = playerX;
                playerOldY = playerY;

                //смена координат в зависимости от нажатия клавиш
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        playerY--;
                        playerStepCount++;
                        if (playerY < 0)
                        {
                            playerY = 0;
                            playerStepCount--;
                        }
                        if (map[playerY, playerX] == '-')
                            BossFight();
                        break;
                    case ConsoleKey.DownArrow:
                        playerY++;
                        playerStepCount++;
                        if (playerY >= mapSize)
                        {
                            playerY = mapSize - 1;
                            playerStepCount--;
                        }
                        if (map[playerY, playerX] == '-')
                        {
                            playerX = playerOldX;
                            playerY = playerOldY;
                            playerStepCount--;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        playerX--;
                        playerStepCount++;
                        if (playerX < 0)
                        {
                            playerX = 0;
                            playerStepCount--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        playerX++;
                        playerStepCount++;
                        if (playerX >= mapSize)
                        {
                            playerX = mapSize - 1;
                            playerStepCount--;
                        }
                            break;
                    case ConsoleKey.Escape:
                        GameMenu();
                        break;
                    default:
                        UpdateMap();
                        Move();
                        break;

                }

                Console.CursorVisible = false; //скрытный курсор

                if (playerStepCount - buffCount == 20)
                    BuffUp();

                if (map[playerY, playerX] == 'O')
                {
                    playerX = playerOldX;
                    playerY = playerOldY;
                    playerStepCount--;
                }

                Console.SetCursorPosition(0, 28);
                Console.Write($"Шагов сделано: {playerStepCount}");

                if (map[playerY, playerX] == 'B')
                {
                    buffCount = playerStepCount;
                    BuffUp();
                }

                if (map[playerY, playerX] == 'E')
                    Fight();

                if (map[playerY, playerX] == 'H')
                    AidUp();

                //предыдущее положение игрока затирается
                if (map[playerOldY, playerOldX] == '▒')
                {
                    Console.SetCursorPosition(playerOldX, playerOldY);
                    Console.Write('▒');
                }
                else
                {
                    map[playerOldY, playerOldX] = '_';
                    Console.SetCursorPosition(playerOldX, playerOldY);
                    Console.Write('_');
                }

                if (map[playerY, playerX] == '▒' && playerHP > 0)
                {
                    playerHP -= 5;
                    Console.SetCursorPosition(playerX, playerY);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write('P');
                    Console.ResetColor();
                    Console.SetCursorPosition(0, 30);
                    Console.Write($"Здоровье игрока: {playerHP}  ");
                }
                //обновленное положение игрока
                else
                {
                    map[playerY, playerX] = 'P';
                    Console.SetCursorPosition(playerX, playerY);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write('P');
                    Console.ResetColor();
                }

                if (playerHP <= 0)
                {
                    isAlive = false;
                    GameOver();
                }

                if (enemiesCount == 0 && enemiesCountForBoss == 1)
                {
                    enemiesCountForBoss--;
                    BossSpawn();
                }
            }
        }
        /// <summary>
        /// вывод карты на консоль
        /// </summary>
        static void UpdateMap()
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == 'B') Console.ForegroundColor = ConsoleColor.Blue;
                    if (map[i, j] == 'E') Console.ForegroundColor = ConsoleColor.Red;
                    if (map[i, j] == 'H') Console.ForegroundColor = ConsoleColor.Green;
                    if (map[i, j] == 'O' || map[i, j] == '-') Console.ForegroundColor = ConsoleColor.DarkRed;
                    if (map[i, j] == 'P') Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(map[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.ResetColor();
            }
            Console.SetCursorPosition(30, 0);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Буквой B на карте обазначены баффы, увеличивающие силу удара в 2 раза");

            Console.SetCursorPosition(30, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Буквой E на карте обазначены враги, имеющие 30 HP");

            Console.SetCursorPosition(30, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Буквой H на карте обазначены аптечки,");

            Console.SetCursorPosition(30, 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("увеличивающие ваше здоровье до 50");
            Console.ResetColor();

            Console.SetCursorPosition(30, 4);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Буквой P обозначен игрок");
            Console.ResetColor();

            Console.SetCursorPosition(0, 29);
            Console.Write($"Сила удара: {playerStrong}  ");
            Console.SetCursorPosition(0, 30);
            Console.Write($"Здоровье игрока: {playerHP}  ");
            Console.SetCursorPosition(0, 28);
            Console.Write($"Шагов сделано: {playerStepCount}");

            if (isBoss)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(30, 5);
                Console.Write("Данным цветом на карте обозначен Босс.");
                Console.SetCursorPosition(30, 6);
                Console.Write("Он имеет 500 здоровья и силу 20, а также");
                Console.SetCursorPosition(30, 7);
                Console.Write("меняет свое местоположение после двух обоюдных ударов.");
                Console.SetCursorPosition(30, 8);
                Console.Write("Вокруг него действует поле, наносящее 5 урона при наступании,");
                Console.SetCursorPosition(30, 9);
                Console.Write("а также если вы будете пытаться ударить его из этого поля,");
                Console.SetCursorPosition(30, 10);
                Console.Write("однако у него есть слабое место - бейте его в тело снизу!");
                Console.ResetColor();

                Console.SetCursorPosition(0, 31);
                Console.Write($"Здоровье босса: {bossHP}  ");

                Console.SetCursorPosition(0, 29);
                Console.Write($"Сила удара: {playerStrong}  ");
                Console.SetCursorPosition(0, 30);
                Console.Write($"Здоровье игрока: {playerHP}  ");
                Console.SetCursorPosition(0, 28);
                Console.Write($"Шагов сделано: {playerStepCount}");
            }
        }
        /// <summary>
        /// стартовое меню игры
        /// </summary>
        static void StartGame()
        { 
            Console.Clear();
            string new_game_text = "N - начать новую игру";
            string load_game_text = "L - загрузить последнее сохранение";

            Console.Write(TextToCentre(new_game_text, 1));
            Console.Write(TextToCentre(load_game_text, 0));

            Console.CursorVisible = false;

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.N:
                    if (!isAlive) ResetMap();
                    GenerationMap();
                    Move();
                    break;
                case ConsoleKey.L:
                    isAlive = true;
                    LoadGame();
                    break;
                default:
                    StartGame();
                    break;

            }
        }
        /// <summary>
        /// логика поднятия бафа
        /// </summary>
        static void BuffUp()
        {
            if (playerStepCount - buffCount == 20)
            {
                playerStrong = 10;
                Console.SetCursorPosition(0, 29);
                Console.Write($"Сила удара: {playerStrong}  ");
            }
            else
            {
                playerStrong *= 2;
                Console.SetCursorPosition(0, 29);
                Console.Write($"Сила удара: {playerStrong}  ");
                map[playerY, playerX] = '_';
            }
        }

        static void Fight()
        {
            while (playerHP > 0 && enemyHP > 0)
            {
                for (int i = 0; i < 3; i++) // Перебор символов анимации
                {
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write('|');
                    Thread.Sleep(60);
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write('/');
                    Thread.Sleep(60);
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write('-');
                    Thread.Sleep(60);
                }
                playerHP -= enemyStrong;
                enemyHP -= playerStrong;

                Console.SetCursorPosition(0, 30);
                Console.Write($"Здоровье игрока: {playerHP}  ");
                Console.Write('_');
            }
            enemiesCount--;
            enemyHP = 30;
        }

        static void AidUp()
        {
            playerHP = 50;

            Console.SetCursorPosition(0, 30);
            Console.Write($"Здоровье игрока: {playerHP}  ");
        }

        static void GameOver()
        {
            Console.Clear();
            string game_over = "GAME OVER";
            string lose = "Вы проиграли :(";
            string steps = $"Проделано шагов: {playerStepCount}";
            string go_next = "Нажмите клавишу Enter, чтобы вернуться в меню игры";

            Console.Write(TextToCentre(game_over, 1));
            Console.Write(TextToCentre(lose, 0));
            Console.Write(TextToCentre(steps, -1));
            Console.Write(TextToCentre(go_next, -4));

            if (Console.ReadKey().Key == ConsoleKey.Enter)
                StartGame();
            else
                GameOver();
        }

        static string TextToCentre(string text, sbyte n)
        {
            int text2_X = (Console.WindowWidth / 2) - (text.Length / 2);
            int text2_Y = (Console.WindowHeight / 2) - n;

            Console.SetCursorPosition(text2_X, text2_Y);
            return text;
        }

        static void ResetMap()
        {
            playerHP = 50;
            playerStrong = 10;
            playerStepCount = 0;
            enemies = 10;
            enemiesCount = 10;
            buffs = 5;
            health = 5;
            enemyStrong = 5;
            enemyHP = 30;
            playerY = mapSize / 2;
            playerX = mapSize / 2;
            isAlive = true;
            isBoss = false;
        }

        static void RemoveMap()
        {
            playerStrong = 10;
            bossCount = 0;
            enemies = 0;
            enemiesCount = 0;
            buffs = 4;
            health = 2;
            isAlive = true;
            bossIsRight = true;
        }

        static void Winning()
        {
            Console.Clear();
            string you_re_winner = "YOU ARE A WINNER!";
            string congruts = "Поздравляем! Вы уничтожили всех врагов!";
            string steps = $"Проделано шагов: {playerStepCount}";
            string go_next = "Нажмите клавишу Enter, чтобы вернуться в меню игры";

            Console.Write(TextToCentre(you_re_winner, 1));
            Console.Write(TextToCentre(congruts, 0));
            Console.Write(TextToCentre(steps, -1));
            Console.Write(TextToCentre(go_next, -4));

            if (Console.ReadKey().Key == ConsoleKey.Enter)
                StartGame();
            else
                Winning();
        }
        static void GameMenu()
        {
            Console.Clear();
            string save = "gНажмите S, чтобы сохранить игру";
            string menu = "Нажмите M, чтобы выйти в главное меню";
            string go = "Нажмите C, чтобы продолжить игру";

            Console.Write(TextToCentre(save, 1));
            Console.Write(TextToCentre(menu, 0));
            Console.Write(TextToCentre(go, -1));

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.S:
                    SaveGame();
                    break;
                case ConsoleKey.M:
                    ResetMap();
                    StartGame();
                    break;
                case ConsoleKey.C:
                    UpdateMap();
                    Move();
                    break;
                default:
                    GameMenu();
                    break;
            }
        }

        static string SaveGame()
        {
            Console.Clear();
            string save = "Вы успешно сохранили игру!";
            string save1 = "Нажмите любую клавишу, чтобы вернуться в меню паузы";
            Console.Write(TextToCentre(save, 1));
            Console.Write(TextToCentre(save1, 0));
            Console.ReadKey();
            

            string path = "save.txt"; 
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine($"playerX={playerX}");
                writer.WriteLine($"playerY={playerY}");
                writer.WriteLine($"playerHP={playerHP}");
                writer.WriteLine($"playerStrong={playerStrong}");
                writer.WriteLine($"playerStepCount={playerStepCount}");
                writer.WriteLine($"enemies_count={enemiesCount}");
                writer.WriteLine($"enemiesCountForBoss={enemiesCountForBoss}");
                writer.WriteLine($"bossHP={bossHP}");
                writer.WriteLine($"bossCount={bossCount}");
                writer.WriteLine($"bossStrong={bossStrong}");
                writer.WriteLine($"isAlive={isAlive}");
                writer.WriteLine($"isBoss={isBoss}");
                writer.WriteLine($"isBossFight={isBossFight}");

                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        writer.Write(map[i, j]);
                    }
                    writer.WriteLine();
                }
            }
            GameMenu();
            return path;
        }

        static void LoadGame()
        {
            string path = "save.txt"; 
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path); 
                if (lines.Length >= mapSize)
                {
                    if (int.TryParse(lines[0].Split('=')[1], out int loadedPlayerX) &&
                        int.TryParse(lines[1].Split('=')[1], out int loadedPlayerY) &&
                        int.TryParse(lines[2].Split('=')[1], out int loadedPlayerHP) &&
                        int.TryParse(lines[3].Split('=')[1], out int loadedPlayerStrong) &&
                        int.TryParse(lines[4].Split('=')[1], out int loadedPlayerStepCount) &&
                        int.TryParse(lines[5].Split('=')[1], out int loadedEnemies_count) &&
                        int.TryParse(lines[6].Split('=')[1], out int loadedenemiesCountForBoss) &&
                        int.TryParse(lines[7].Split('=')[1], out int loadedbossHP) &&
                        int.TryParse(lines[8].Split('=')[1], out int loadedbossCount) &&
                        int.TryParse(lines[9].Split('=')[1], out int loadedbossStrong) &&
                        bool.TryParse(lines[10].Split('=')[1], out bool loadedisAlive) &&
                        bool.TryParse(lines[11].Split('=')[1], out bool loadedisBoss) &&
                        bool.TryParse(lines[12].Split('=')[1], out bool loadedisBossFight))
                    {
                        playerX = loadedPlayerX;
                        playerY = loadedPlayerY; 
                        playerHP = loadedPlayerHP;
                        playerStrong = loadedPlayerStrong; 
                        playerStepCount = loadedPlayerStepCount;
                        enemiesCount = loadedEnemies_count;
                        enemiesCountForBoss = loadedenemiesCountForBoss;
                        bossHP = loadedbossHP;
                        bossCount = loadedbossCount;
                        bossStrong = loadedbossStrong;
                        isAlive = loadedisAlive;
                        isBoss = loadedisBoss;
                        isBossFight = loadedisBossFight;

                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                map[i, j] = '_';
                            }
                        }
                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                map[i, j] = lines[i + 13][j];
                            }
                        }
                        map[playerY, playerX] = 'P';
                        UpdateMap();
                        Move();
                    }

                }
                else
                {
                    Console.WriteLine("Ошибка чтения файла сохранения.");
                }
            }
            else
            {
                Console.WriteLine("Файл сохранения не найден.");
            }
        }

        static void BossSpawn()
        {
            if (!isBossFight)
            {
                playerStrong = 10;
            }
            isBoss = true;
            RemoveMap();
            GenerationMap();
            Move();
        }

        static void BossFight() 
        {
            while (playerHP > 0 && bossHP > 0 && bossCount < 2)
            {
                for (int i = 0; i < 3; i++) // Перебор символов анимации
                {
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write('|');
                    Thread.Sleep(60);
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write('/');
                    Thread.Sleep(60);
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write('-');
                    Thread.Sleep(60);
                }
                playerHP -= bossStrong;
                bossHP -= playerStrong;

                Console.SetCursorPosition(0, 30);
                Console.Write($"Здоровье игрока: {playerHP}  ");
                Console.SetCursorPosition(0, 31);
                Console.Write($"Здоровье босса: {bossHP}  ");
                Console.Write('_');
                bossCount++;
            }
            if (bossHP <= 0)
            {
                Winning();
                ResetMap();
            }
            isBossFight = true;
            BossSpawn();
        }
    }
}
