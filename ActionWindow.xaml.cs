using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using fractal_generator.Model;

namespace fractal_generator
{
    /// <summary>
    /// Interaction logic for ActionWindow.xaml
    /// </summary>
    public partial class ActionWindow : Window
    {
        private Fractal fractal;
        public ActionWindow(Fractal fractal)
        {
            this.fractal = fractal;
            InitializeComponent();
        }

        private void ExecuteAssociatedFunction(int id)
        {
            
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
    }
}
