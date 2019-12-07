﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using fractal_generator.Model;

namespace fractal_generator
{
    /// <summary>
    /// Interaction logic for DescriptionWindow.xaml
    /// </summary>
    public partial class DescriptionWindow : Window
    {

        public DescriptionWindow(Fractal fractal)
        {
            InitializeComponent();

            title.Text = fractal.Name;
            description.Text = fractal.Description;

            var imageList = Fractal.GetImagesUriList(fractal);

            img1.Source = imageList[0];
            img2.Source = imageList[1];
            img3.Source = imageList[2];



        }


    }
}
