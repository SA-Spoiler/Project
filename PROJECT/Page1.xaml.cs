﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace PROJECT
{
    /// <summary>
    /// Page1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page1 : Page
    {
        List<string> movieList;
        List<MovieInfo> movieInfos;

        public Page1(List<string> list)
        {
            InitializeComponent();
            movieInfos = (List<MovieInfo>)Application.Current.Properties["mvInfoList"];

            Init(list);
        }

        private void Init(List<string> list)
        {
            // get 추천영화 리스트 10개(제목들, 카테고리) from MainWindow.xaml
            movieList = new List<string>(list);

            // debug
            btnMv1.Content = list[0];
            btnMv2.Content = list[1];
            btnMv3.Content = list[2];
       
        }

        private void btnMv_Click(object sender, RoutedEventArgs e)
        {
            var btnOption = sender as Button;

            if(null != btnOption)
            {
                string title = "";

                // 영화 제목
                if (btnOption == btnMv1)
                    title = btnMv1.Content.ToString();
                else if (btnOption == btnMv2)
                    title = btnMv2.Content.ToString();
                else if (btnOption == btnMv3)
                    title = btnMv3.Content.ToString();


                // new Window and send extraData to Window1.xaml
                Window1 w1 = new Window1(title);
                w1.Show();
            }
        }

        private void btnKill_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
            App.Current.MainWindow.Close();
            Environment.Exit(0);
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
