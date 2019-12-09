using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace fractal_generator.Fractals
{
    class FractalPixelGenerator
    {
        public static List<List<int>> CreateMandleBot() //methods starting with create means it give the pixelList
        {
            int Width = 640; //(int)canvas.Width; //FIXME: how to get the canvas size?
            int Height = 480; //(int)canvas.Height;

            var tupleList = new List<List<int>> { }; //list for saving the co-ordinates and color code 


            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    double a = (double) (x - (Width / 2)) / (double) (Width / 4);
                    double b = (double) (y - (Height / 2)) / (double) (Height / 4);

                    Complex c = new Complex(a, b);
                    Complex z = new Complex(0, 0);

                    int it = 0;
                    do
                    {
                        it++;
                        z.Square();
                        z.Add(c);
                        if (z.Magnitude() > 4.0) break;

                    } while (it < 900);

                    // bm.SetPixel(x, y, it < 100 ? Color.Black : Color.White);
                    int color_code = ((it < 100 ? 1 : 0));
                    tupleList.Add(new List<int> {x, y, color_code});

                }
            }

            return tupleList;
        }

        public static List<List<int>> CreateSierpinskiGasket()
        {
            int WIDTH = 768;
            int HEIGHT = 768;

            List<List<int>> tupleList = new List<List<int>> { };
            for (int y = 0; y < WIDTH; y++)
            {
                for (int x = 0; x < HEIGHT; x++)
                {
                    if ((x & (y - x)) == 0)
                    {
                        //DrawPoint(x+158-y/2, y+30, 1);
                        tupleList.Add(new List<int> {x + ((WIDTH / 2) + 30) - y / 2, y + 30, 1});
                    }
                }
            }

            return tupleList;
        }


        public static List<List<int>> CreateJuliaSet()
        {
            List<List<int>> pixelList = new List<List<int>>();
            int left = 20;
            int w = 300;
            int s = w / 3;
            int orig = left + w / 2;
            double xc = -1;
            double yc = -1;


            //    drawLine(1);
            // //    drawline(2);

            double xn = 0.25;
            double yn = 0;

            for (int i = 0; i < 5000; i++)
            {
                double a = xn - xc;
                double b = yn - yc;
                if (a == 0)
                {
                    xn = Math.Sqrt(Math.Abs(b) / 2);
                    if (xn > 0)
                    {
                        yn = b / (2 * xn);
                    }
                    else
                    {
                        yn = 0;
                    }
                }
                else if (a > 0)
                {
                    xn = Math.Sqrt((Math.Sqrt(a*a+b*b)+a)/2);
                    yn = b / (2 * xn);
                }
                else
                {
                    xn = Math.Sqrt((Math.Sqrt(a*a+b*b)-a)/2);
                    yn = b / (2 * yn);
                }

                if (i == 0)
                {
                    xn += .5;
                }

                if (new Random().Next() >= 0.5) //TODO: need to check the range of the random in java and c#
                {
                    xn = -xn;
                    yn = -yn;
                }

                pixelList.Add(new List<int>{(int)(xn*s+orig), (int)(-yn*xn+orig), 1});
            }

            return pixelList;
        }

    }




}
        
        
        
    
        /*

        */

        

        
    

        

       
