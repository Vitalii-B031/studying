

using System.Collections;
using Timer = System.Windows.Forms.Timer;

namespace GameOfLife;

public partial class Form1 : Form
{
    private BitArray grid;
    private int cellSize=2 ;
    private int rows=400;
    private int columns=400;
    private Timer timer;
    private bool isRuning = false;
    
    private int CountNeighbors(int row, int column)
    {
        int count=0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }

                int r = row + i;
                int c = column + j;
                if (r >= 0 && r < rows && c >= 0 && c < columns)
                {
                    int index=r*columns+c;
                    if (grid[index])
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    private void UpdateGrid()
    {
        BitArray newGrid = new BitArray(rows * columns);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
               int index = i * columns + j;
               int neighbors = CountNeighbors(i, j);
               bool c=grid[index];
               newGrid[index]=c?(neighbors==2||neighbors==3):neighbors==3;
                
                
            }
        }
        grid = newGrid;
         /*if (GC.GetTotalMemory(false) > 50000000)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();  
        }              */          
        
    }

    private void RandomizeGrid()
    {
        var random = new Random();
        for (int i = 0; i < grid.Length; i++)
        {
            
                grid[i] = random.Next(2)==1?true:false;
            
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var graphics = e.Graphics;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var rect = new Rectangle(i * cellSize, j * cellSize, cellSize, cellSize);
                if (grid[i*columns+j])
                {
                    graphics.FillRectangle(new SolidBrush(Color.Black), rect);
                    graphics.DrawRectangle(new Pen(Color.Gray), rect);
                }
            }
        }
    }
    private void InitializeGame()
    {
        grid=new BitArray(rows* columns);
        this.ClientSize=new Size(columns*cellSize,rows*cellSize+50);
        this.DoubleBuffered=true;
        timer = new Timer();
        timer.Interval=100;
        timer.Tick += (s, e) =>
        {
            UpdateGrid();
            Invalidate();
        };
        Button startButton=new Button()
        {
            Text = "Start",
            Location=new Point(10,rows*cellSize+10),
            Size=new Size(80,30),
        };
        startButton.Click += (sender, e) =>
        {
            isRuning = !isRuning;
            if (isRuning)
            {
                RandomizeGrid();
                timer.Start();
                Text = "Pause";
            }
            else
            {
                timer.Stop();
                Text = "Start";
            }
        };
        Button clearButton=new Button()
        {
            Text = "Clear",
            Location=new Point(100,rows*cellSize+10),
            Size=new Size(80,30),
        };
        clearButton.Click += (sender, e) =>
        {
            ClearGrid();
            Invalidate();
            startButton.Text = "Start";
        };
        Button randomButton=new Button()
        {
            Text = "Random",
            Location=new Point(190,rows*cellSize+10),
            Size=new Size(80,30),
        };
        randomButton.Click += (sender, e) =>
        {
            RandomizeGrid();
            Invalidate();
        };
        this.Controls.Add(startButton);
        this.Controls.Add(clearButton);
        this.Controls.Add(randomButton);
    }

    private void ClearGrid()
    {
        grid.SetAll(false);
        isRuning=false;
        timer.Stop();
        
    }
    
    public Form1()
    {
        InitializeComponent();
        InitializeGame();
    }
}