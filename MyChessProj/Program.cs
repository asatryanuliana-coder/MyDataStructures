using System;
using System.ComponentModel.Design;
using System.Security.Cryptography;
class Program
{

    static void Main()
    {
        MainDiagonal();
        AuxiliaryDiagonal();
        Console.WriteLine(RookMatrix(5, 4, 6, 7));
        Console.WriteLine(KnightMatrix(4, 5, 3, 8));
        Console.WriteLine(MinKnightMoves(1, 1, 2, 4));
        Console.WriteLine(BishopMoves(2, 3, 5, 6));
        Console.WriteLine(BishopBlocked(2,2,4,4,6,6));
        char[,] result = BishopBlocked(5, 6, 3, 4);

        Console.WriteLine("Possible positions:");

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (result[i, j] == '*')
                {
                    Console.WriteLine($"({i},{j})");
                }
            }
        }


    }

    static void MainDiagonal()
    {
        Console.Write("Enter matrix size N: ");
        int n = int.Parse(Console.ReadLine());

        char[,] matrix = new char[n, n];

        // Fill matrix
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                    matrix[i, j] = '#';
                else
                    matrix[i, j] = '*';
            }
        }

        // Print matrix
        Console.WriteLine("\nMatrix:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }

    static void AuxiliaryDiagonal()
    {
        Console.Write("The Size of the matrix is N: ");
        int n = int.Parse(Console.ReadLine());
        char[,] matrix = new char[n, n];

        // Fill matrix
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i + j == n - 1)
                    matrix[i, j] = '#';
                else
                    matrix[i, j] = '*';
            }
        }
        // Print matrix
        Console.WriteLine("\nMatrix:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }

    static bool RookMatrix(int x0, int y0, int x1, int y1)
    {
        if ((x0 == x1) || (y0 == y1))
            return true;
        else
            return false;
    }

    static bool KnightMatrix(int x0, int x1, int y0, int y1)
    {
        if (Math.Abs(x0 - x1) * Math.Abs(y0 - y1) == 2)
            return true;
        else
            return false;
    }


    static int MinKnightMoves(int sx, int sy, int ex, int ey)
    {
        int[] dx = { 2, 2, -2, -2, 1, 1, -1, -1 };
        int[] dy = { 1, -1, 1, -1, 2, -2, 2, -2 };

        bool[,] visited = new bool[9, 9];

        Queue<(int x, int y, int steps)> q = new Queue<(int x, int y, int steps)>();

        q.Enqueue((sx, sy, 0));
        visited[sx, sy] = true;

        while (q.Count > 0)
        {
            var cur = q.Dequeue();

            if (cur.x == ex && cur.y == ey)
                return cur.steps;

            for (int i = 0; i < 8; i++)
            {
                int nx = cur.x + dx[i];
                int ny = cur.y + dy[i];

                if (nx >= 1 && nx <= 8 && ny >= 1 && ny <= 8 && !visited[nx, ny])
                {
                    visited[nx, ny] = true;
                    q.Enqueue((nx, ny, cur.steps + 1));
                }
            }
        }

        return -1;
    }

    static bool BishopMoves(int x, int y, int x1, int y1)
    {
        if (Math.Abs(x - x1) == Math.Abs(y - y1))
            return true;
        else
            return false;
    }

   /// <summary>
   /// 
   /// </summary>
   /// <param name="x1"></param>
   /// <param name="y1"></param>
   /// <param name="x2"></param>
   /// <param name="y2"></param>
   /// <param name="bx"></param>
   /// <param name="by"></param>
   /// <returns></returns>
    static bool BishopBlocked(int x1, int y1, int x2, int y2, int bx, int by)
    {

        if (Math.Abs(x1 - x2) != Math.Abs(y1 - y2))
            return false;

        int dx;//dx-directions 
        int dy;//dy-directions

        if (x2 > x1)
            dx = 1;
        else
            dx = -1;

        if (y2 > y1)
            dy = 1;
        else
            dy = -1;

        int x = x1 + dx;
        int y = y1 + dy;


        while (x != x2 && y != y2)
        {
            if (x == bx && y == by)
                return false;

            x += dx;
            y += dy;
        }

        return true;
    }
    static char[,] BishopBlocked(int x1, int y1, int bx, int by)
    {
        int n = 9;

        char[,] board = new char[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                board[i, j] = '.';
            }
        }

        board[x1, y1] = 'B';
        board[bx, by] = 'X';

        int[] dx = { 1, 1, -1, -1 };
        int[] dy = { 1, -1, 1, -1 };

        for (int dir = 0; dir < 4; dir++)
        {
            int x = x1 + dx[dir];
            int y = y1 + dy[dir];

            while (x >= 0 && x < 9 &&
                   y >= 0 && y < 9)
            {
                if (x == bx && y == by)
                    break;

                board[x, y] = '*';

                x += dx[dir];
                y += dy[dir];
            }
        }

        return board;
    }
}






















