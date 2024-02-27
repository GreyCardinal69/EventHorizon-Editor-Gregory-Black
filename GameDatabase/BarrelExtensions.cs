using EditorDatabase.DataModel;
using EditorDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameDatabase
{
    internal class BarrelExtensions
    {
        internal static Barrel[] CreateBarrels(string input)
        {
            int n = ( int ) Math.Sqrt( input.Length );
            int[,] grid = new int[n, n];

            for ( int i = 0; i < input.Length; i++ )
            {
                int row = i / n;
                int col = i % n;
                grid[row, col] = input[i] - '0';
            }

            List<(double, double)> coordinates = new List<(double, double)>();
            
            for ( int row = 0; row < n; row++ )
            {
                for ( int col = 0; col < n; col++ )
                {
                    if ( grid[row, col] == 4 )
                    {
                        AddCoordinate( row, col, n, grid, coordinates );
                    }
                }
            }

            Barrel[] barrels = new Barrel[coordinates.Count];

            int q = 0;
            foreach ( var coordinate in coordinates )
            {
                barrels[q] = new Barrel()
                {
                    Position = new Vector2()
                    {
                        x = Convert.ToSingle( coordinate.Item1 ),
                        y = Convert.ToSingle( coordinate.Item2 )
                    }
                };
                q++;
            }

            return barrels;
        }

        private static (double, double) GetCenter( (double, double)[] cells, double n )
        {
            double sumRow = cells.Sum( cell => cell.Item1 );
            double sumCol = cells.Sum( cell => cell.Item2 );

            double centerOffset = ( n - 1 ) / 2.0;

            double avgRow = centerOffset - ( sumRow / cells.Length );
            double avgCol = centerOffset - ( sumCol / cells.Length );

            avgRow = Math.Max( -1, Math.Min( 1, avgRow / centerOffset ) );
            avgCol = Math.Max( -1, Math.Min( 1, avgCol / centerOffset ) );

            return (avgRow, avgCol);
        }

        private static void AddCoordinate( int row, int col, int n, int[,] grid, List<(double, double)> coordinates )
        {
            double x = ( ( double ) col ) / n;
            double y = 1 - ( ( double ) row ) / n;

            foreach ( var (cx, cy) in coordinates )
            {
                double distanceX = Math.Abs( cx - x );
                double distanceY = Math.Abs( cy - y );

                if ( distanceX < 1.0 / n && distanceY < 1.0 / n )
                {
                    return;
                }
            }

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue( (row, col) );
            grid[row, col] = -1;

            List<(int, int)> overlappingCoords = new List<(int, int)>();
            overlappingCoords.Add( (row, col) );

            while ( queue.Count > 0 )
            {
                var current = queue.Dequeue();
                int r = current.Item1;
                int c = current.Item2;

                for ( int dr = -1; dr <= 1; dr++ )
                {
                    for ( int dc = -1; dc <= 1; dc++ )
                    {
                        int nr = r + dr;
                        int nc = c + dc;

                        if ( nr >= 0 && nr < n && nc >= 0 && nc < n && grid[nr, nc] == 4 && ( dr == 0 || dc == 0 ) )
                        {
                            grid[nr, nc] = -1;
                            queue.Enqueue( (nr, nc) );

                            overlappingCoords.Add( (nr, nc) );
                        }
                    }
                }
            }

            List<(double, double)> coords = new List<(double, double)>();
            foreach ( var (ox, oy) in overlappingCoords )
            {
                coords.Add( (oy, ox) );
            }

            var v = GetCenter( coords.ToArray(), n );
            double centerX = v.Item1;
            double centerY = v.Item2;

            coordinates.Add( (centerX, centerY) );
        }
    }
}