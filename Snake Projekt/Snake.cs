using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeNS
{
    public partial class Snake : Form
    {
        /// <summary>
        /// Pola klasy i zmienne wykorzystywane w klasie Snake.
        /// </summary>
        int cols = 50, rows = 25, score = 0, dx = 0, dy = 0, front = 0, back = 0;
        Punkt[] snake = new Punkt[1250];
        List<int> available = new List<int>();
        public bool[,] visit { get; set; }

        int highScore;
        

        Random rand = new Random();

        Timer timer = new Timer();
        /// <summary>
        /// Konstruktor który ma za zadanie utworzenie instancji.
        /// </summary>
        public Snake()
        {
            InitializeComponent();
            initial();
        }

        /// <summary>
        /// Metoda gameover zostanie wywołana, kiedy wąż opuści teren gry.
        /// Metoda collisionFood jest wywoływana podczas kolizji jedzenia z wężem.
        /// Jeżeli metoda collisionFood zwróci false, wąż zmieni swoje położenie. W metodzie jest sprawdzany jest także czy punkty gracza są wyższe od rekordu.
        /// </summary>
        public void move(object sender, EventArgs e)
        {
            int x = snake[front].Location.X, y = snake[front].Location.Y;
            if (dx == 0 && dy == 0) return;
            if (game_over(x + dx, y + dy))
            {
                MessageBox.Show("Koniec Gry");
                System.Windows.Forms.Application.Exit();
                return;
            }
            if (collisionFood(x + dx, y + dy))
            {
                score += 1;
                Wynik.Text = "Wynik: " + score.ToString();
                if (hits((y + dy) / 20, (x + dx) / 20)) return;
                Punkt head = new Punkt(x + dx, y + dy);
                front = (front - 1 + 1250) % 1250;
                snake[front] = head;
                visit[head.Location.Y / 20, head.Location.X / 20] = true;
                Controls.Add(head);
                randomFood();
            }
            else
            {
                if (hits((y + dy) / 20, (x + dx) / 20)) return;
                visit[snake[back].Location.Y / 20, snake[back].Location.X / 20] = false;
                front = (front - 1 + 1250) % 1250;
                snake[front] = snake[back];
                snake[front].Location = new Point(x + dx, y + dy);
                back = (back - 1 + 1250) % 1250;
                visit[(y + dy) / 20, (x + dx) / 20] = true;

                if (score > highScore)
                {
                    highScore = score;

                    txtHighScore.Text = "Najlepszy wynik: " + Environment.NewLine + highScore;
                    txtHighScore.ForeColor = Color.Maroon;
                    txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
                }
            }
        }
        /// <summary>
        /// Metoda snake_keydown zmienia kierunek toru węża wyznaczoną przez gracza.
        /// </summary>
        private void Snake_KeyDown(object sender, KeyEventArgs e)
        {
            dx = dy = 0;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    dx = 20;
                    break;
                case Keys.Left:
                    dx = -20;
                    break;
                case Keys.Up:
                    dy = -20;
                    break;
                case Keys.Down:
                    dy = 20;
                    break;
            }
        }
        /// <summary>
        /// Metoda w losowym miejscu generuje jedzenie na ekranie.
        /// </summary>
        public void randomFood()
        {
            available.Clear();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (!visit[i, j]) available.Add(i * cols + j);
            int idx = rand.Next(available.Count) % available.Count;
            Jedzenie.Left = (available[idx] * 20) % Width;
            Jedzenie.Top = (available[idx] * 20) / Width * 20;
        }
        /// <summary>
        /// Metoda sprawdza czy nastąpiła kolizja sama z sobą.
        /// </summary>
        public bool hits(int x, int y)
        {
            if (visit[x, y])
            {
                MessageBox.Show("Wąż ugryzł się w ogon");
                System.Windows.Forms.Application.Exit();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Metoda sprawdza czy występuje kolizja z jedzeniem.
        /// </summary>
        private bool collisionFood(int x, int y)
        {
            return x == Jedzenie.Location.X && y == Jedzenie.Location.Y;
        }
        /// <summary>
        /// Metoda sprawdza czy wąż wyszedł poza obszar gry.
        /// </summary>
        public bool game_over(int x, int y)
        {
            return x < 0 || y < 0 || x > 980 || y > 480;
        }
        /// <summary>
        /// Metoda generuje pozycje węża i jedzenia.
        /// </summary>
        private void initial()
        {
            visit = new bool[rows, cols];
            Punkt head = new Punkt((rand.Next() % cols) * 20, (rand.Next() % rows) * 20);
            Jedzenie.Location = new Point((rand.Next() % cols) * 20, (rand.Next() % rows) * 20);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    visit[i, j] = false;
                    available.Add(i * cols + j);
                }
            visit[head.Location.Y / 20, head.Location.X / 20] = true;
            available.Remove(head.Location.Y / 20 * cols + head.Location.X / 20);
            Controls.Add(head);
            snake[front] = head;
        }
        private void Snake_Load(object sender, EventArgs e)
        {

        }
    }
}