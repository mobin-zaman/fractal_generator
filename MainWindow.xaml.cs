﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace fractal_generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            text.Text = "what is wrong?";
            //CreateMandleBot();
            /*
            DrawPoint(1, 1, 1);
            DrawPoint(5, 3, 1);
            DrawPoint(8, 4, 0);
            DrawPoint(2, 9, 1);
            DrawPoint(10, 1, 1);
            DrawPoint(1, 100, 1);
            DrawPoint(-123, 3, 1);
            DrawPoint(-8, 40, 0);
            DrawPoint(23, -9, 1);
            DrawPoint(101, 1, 1);
            */

            //            DrawListIteration(CreateMandleBot());
            DrawSierpinskiGasket(SierpinskiGasket());

        }

        void DrawListRandom(List<List<int>> pixelList)
        {
            DispatcherTimer t = new DispatcherTimer();
            pixelList = ShuffleList(pixelList);

            t.Tick += t_drawPoints;
            t.Interval = new TimeSpan(0, 0, 0, 0, 1);
            t.Start();


            void t_drawPoints(object sender, EventArgs e)
            {
                for (int i = 0; i < 1000; i++)
                {
                    var randomElement = pixelList[0];
                    DrawPoint(randomElement[0], randomElement[1], randomElement[2]);
                    pixelList.RemoveAt(0);
                }

            }
        }
        private List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList;
          }
         
        void DrawListIteration(List<List<int>> pixelList)
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Tick += t_drawPoints;
            t.Interval = new TimeSpan(0, 0, 0, 0, 1);
            t.Start();
            
               void t_drawPoints(object sender, EventArgs e)
            {
                for (int i = 0; i < 1000; i++)
                {
                    var firstElement = pixelList[0];
                    DrawPoint(firstElement[0], firstElement[1], firstElement[2]);
                    pixelList.RemoveAt(0);
                }

            }
        }

        void DrawPoint(int x, int y, int choice) //blue background, yellow middle purple dots
        {
                     Task.Run(() =>
                       { 
                     this.Dispatcher.Invoke(() =>

             {
            int dotSize = 2;
               Ellipse currentDot = new Ellipse();
               if (choice == 0)
               {
                int random = new Random().Next(1);
                if (random == 0)
                {
                    currentDot.Stroke = new SolidColorBrush(Colors.DarkOrange);
                    currentDot.Fill = new SolidColorBrush(Colors.DarkOrange);
                }
                else
                {
                    currentDot.Stroke = new SolidColorBrush(Colors.OrangeRed);
                    currentDot.Fill = new SolidColorBrush(Colors.OrangeRed);
                }
               }
               else
               {
                int random = new Random().Next(1);
                if (random == 0)
                {
                    currentDot.Stroke = new SolidColorBrush(Colors.DarkBlue);
                    currentDot.Fill = new SolidColorBrush(Colors.DarkBlue);
                }
                else
                {
                    currentDot.Stroke = new SolidColorBrush(Colors.Blue);
                    currentDot.Fill = new SolidColorBrush(Colors.Blue);
                } 
               }
               currentDot.StrokeThickness = 1;
                //   Canvas.SetZIndex(currentDot, 3);
                currentDot.Height = dotSize;
               currentDot.Width = dotSize;
               currentDot.Margin = new Thickness(x, y, 0, 0); // Sets the position.
                canvas.Children.Add(currentDot);
           });
       });
         }

        /*
        void TestThread()
        {
            Thread thread = new Thread(new ThreadStart(CreateMandleBot));
            thread.Start();
        }
        async void TestTask()
        {
            await Task.Run(() =>
            {
                CreateMandleBot();
            });
        }

        */
        List<List<int>> CreateMandleBot()

        {
            int Width = 640;//(int)canvas.Width; //FIXME: how to get the canvas size?
            int Height = 480;//(int)canvas.Height;

            var tupleList = new List<List<int>> { }; //list for saving the co-ordinates and color code 


            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    double a = (double)(x - (Width / 2)) / (double)(Width / 4);
                    double b = (double)(y - (Height / 2)) / (double)(Height / 4);

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
                    tupleList.Add(new List<int> { x, y, color_code });

                }
            }
            return tupleList;

        }

        void DrawSierpinskiGasket(List<List<int>> pixelList)
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Tick += t_drawPoints;
            t.Interval = new TimeSpan(0, 0, 0, 0, 1);
            t.Start();

            void t_drawPoints(object sender, EventArgs e)
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var firstElement = pixelList[0];
                        DrawPoint(firstElement[0], firstElement[1], firstElement[2]);
                        pixelList.RemoveAt(0);
                    }
                }
                catch (Exception)
                {
                    t.Stop();
                }


            }
        }

       

        List<List<int>> SierpinskiGasket()
        {
            int WIDTH = 768;
            int HEIGHT = 768;

            List<List<int>> tupleList = new List<List<int>> { };
            for (int y = 0; y < WIDTH; y++)
            {
                for(int x=0; x< HEIGHT; x++)
                {
                    if((x & (y-x)) ==0)
                    {
                        //DrawPoint(x+158-y/2, y+30, 1);
                        tupleList.Add(new List<int> { x + ((WIDTH/2)+30) - y / 2, y + 30, 1 });
                    }
                }
            }
            return tupleList;
        }
    }

}
