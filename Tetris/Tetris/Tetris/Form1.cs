using Timer = System.Windows.Forms.Timer;

namespace Tetris;

public partial class Form1 : Form
{
    private int[,] board=new int[10,20];
    private int score=0;
    private Random random=new Random();
    private Timer timer=new Timer();
    private bool gameOver=false;
    private Tetramino currentTetramino=null;

    private void Tick(object sender, EventArgs e)
    {
        Move(0, 1);
        Invalidate();
    }
    
    
    public Form1()
    {
        InitializeComponent();
        InitializeGame();
        
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g=e.Graphics;
        int cellSize=20;
        for (int x = 0; x < board.GetLength(0); x++)
        {
            for (int y = 0; y < board.GetLength(1); y++)
            {
                if (board[x, y] == 0)
                {
                    using (SolidBrush brush=new SolidBrush(Color.FromArgb(board[x, y])))
                    {
                        g.FillRectangle(brush,x*cellSize+50,y*cellSize+50,cellSize-1,cellSize-1);
                    }
                    g.DrawRectangle(Pens.Black,x*cellSize+50,y*cellSize+50,cellSize,cellSize);
                }
            }
        }

        foreach (var point in currentTetramino.Shape)
        {
            int x = point.X+ currentTetramino.X;
            int y = point.Y+currentTetramino.Y;
            if (y >= 0)
            {
                using (SolidBrush brush=new SolidBrush(currentTetramino.Color))
                {
                    g.FillRectangle(brush,x*cellSize+50,y*cellSize+50,cellSize-1,cellSize-1);
                }
            }
        }
    } 
    private Tetramino CreateTetramino()
    {
        Tetramino[] tet = new Tetramino[]
        {
            new Tetramino(new Point[]
            {
                new Point(0, 0),
                new Point(0, 1),
                new Point(1, 0),
                new Point(1, 1),
            }, Color.Blue),
            new Tetramino(new Point[]
            {
                new Point(0, 0),
                new Point(0, 1),
                new Point(0, 2),
                new Point(0, 3),
            }, Color.Green),
            new Tetramino(new Point[]
            {
                new Point(0, 0),
                new Point(0, 1),
                new Point(1, 1),
                new Point(0, 2),
            }, Color.Red),
            new Tetramino(new Point[]
            {
                new Point(0, 0),
                new Point(0, 1),
                new Point(1, 1),
                new Point(1, 2),
            }, Color.Yellow),
            new Tetramino(new Point[]
            {
                new Point(0, 1),
                new Point(0, 2),
                new Point(1, 0),
                new Point(1, 1),
            }, Color.BlueViolet),
            new Tetramino(new Point[]
            {
                new Point(0, 0),
                new Point(0, 1),
                new Point(0, 2),
                new Point(1, 0),
            }, Color.Aqua),
            new Tetramino(new Point[]
            {
                new Point(0, 0),
                new Point(0, 1),
                new Point(0, 2),
                new Point(1, 2),
            }, Color.Chocolate),
        };
        int r=random.Next(tet.Length);
        return new Tetramino(tet[r].Shape, tet[r].Color);
    }

    private bool CanMove(int deltaX, int deltaY)
    {
        foreach (var point in currentTetramino.Shape)
        {
            int newX = point.X + currentTetramino.X + deltaX;
            int newY = point.Y + currentTetramino.Y + deltaY;
            if (newX < 0 || newX >= board.GetLength(0) || newY < 0 || newY >= board.GetLength(1))
            {
                return false;
            }

            if (board[newX, newY] != 0)
            {
                return false;
            }


        } 
        return true;
    }

    private void Form1_Key(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
         case Keys.Left:
             Move(-1,0);
             break;
         case Keys.Right:
             Move(1, 0);
             break;
        }
        
    }
    private bool Move(int deltaX, int deltaY)
    {
        if (CanMove(deltaX, deltaY))
        {
            currentTetramino.X += deltaX;
            currentTetramino.Y += deltaY;
            return true;
        }
        return false;
    }
    private void InitializeGame()
    {
        currentTetramino=CreateTetramino();
        currentTetramino.X=random.Next(board.GetLength(0));
        this.Paint += Form1_Paint;
        this.Size = new Size(300, 600);
        this.timer.Interval = 500;
        this.timer.Tick += this.Tick;
        this.timer.Start();
        this.KeyDown += Form1_Key;
    }
}