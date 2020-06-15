﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BattleMap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Monster_Token
    {
        int last_Monster_Position_X;
        int last_Monster_Position_Y;
        int monster_Speed;
        Rectangle last_Monster_Rect;

        public Monster_Token(Rectangle last_Monster_Rect = null)
        {
            last_Monster_Position_X = 0;
            last_Monster_Position_Y = 0;
            monster_Speed = 0;
            this.Last_Monster_Rect = last_Monster_Rect;
        }

        public Monster_Token(Monster_Token m, Rectangle last_Monster_Rect = null)
        {
            last_Monster_Position_X = m.last_Monster_Position_X;
            last_Monster_Position_Y = m.last_Monster_Position_Y;
            monster_Speed = m.monster_Speed;
            this.last_Monster_Rect = last_Monster_Rect;
        }

        public Monster_Token(int last_Monster_Position_X, int last_Monster_Position_Y, int monster_Speed, Rectangle last_Monster_Rect)
        {
            this.Last_Monster_Position_X = last_Monster_Position_X;
            this.Last_Monster_Position_Y = last_Monster_Position_Y;
            this.Monster_Speed = monster_Speed;
            this.Last_Monster_Rect = last_Monster_Rect;
        }

        public int Last_Monster_Position_X { get => last_Monster_Position_X; set => last_Monster_Position_X = value; }
        public int Last_Monster_Position_Y { get => last_Monster_Position_Y; set => last_Monster_Position_Y = value; }
        public int Monster_Speed { get => monster_Speed; set => monster_Speed = value; }
        public Rectangle Last_Monster_Rect { get => last_Monster_Rect; set => last_Monster_Rect = value; }

        public override bool Equals(object obj)
        {
            if (((Monster_Token)obj).last_Monster_Position_X == last_Monster_Position_X &&
                ((Monster_Token)obj).last_Monster_Position_Y == last_Monster_Position_Y &&
                ((Monster_Token)obj).monster_Speed == monster_Speed &&
                ((Monster_Token)obj).last_Monster_Rect == last_Monster_Rect)
                return true;
            return false;
        }
    }

    public partial class MainWindow : Window
    {

        static List<Monster_Token> Monster_Positions = new List<Monster_Token>();
        //List_Last_Positions -> max to 7 records
        static List<Monster_Token> List_Last_Positions = new List<Monster_Token>();
        //
        static List<string> Monster_Actions_List = new List<string>();
        static Random rnd = new Random();
        static int x = rnd.Next(0, 950);
        static int y = rnd.Next(0, 500);


        //get last player position
        static int last_Player_Position_X = 0;
        static int last_Player_Position_Y = 0;
        static Rectangle last_player_rect;

        public static List<Monster_Token> Monster_Positions1 { get => Monster_Positions; set => Monster_Positions = value; }
        public static List<Monster_Token> List_Last_Positions1 { get => List_Last_Positions; set => List_Last_Positions = value; }
        public static List<string> Monster_Actions_List1 { get => Monster_Actions_List; set => Monster_Actions_List = value; }

        public MainWindow()
        {
            InitializeComponent();

            canvas.Focus();
            ComboBox_Monster_List.Focusable = false;
            Remove_Monster.Focusable = false;

            setPlayerPosition();
        }

        private void setPlayerPosition()
        {
            x -= (x % 50);
            y -= (y % 50);

            if (x > 500)
            {
                x = 500;
            }
            else if (x < 0)
            {
                x = 0;
            }

            if (y > 950)
            {
                y = 950;
            }
            else if (y < 50)
            {
                y = 50;
            }

            Rectangle rect;
            rect = new Rectangle();
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(@"img/player.png", UriKind.Relative));
            rect.Fill = imgBrush;
            rect.Width = 50;
            rect.Height = 50;
            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
            canvas.Children.Add(rect);

            last_Player_Position_X = x;
            last_Player_Position_Y = y;
            last_player_rect = rect;
        }

        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                if (y - 50 >= 0)
                {
                  
                    y -= 50;

                    canvas.Children.Remove(last_player_rect);

                    Rectangle rect;
                    rect = new Rectangle();
                    ImageBrush imgBrush = new ImageBrush();
                    imgBrush.ImageSource = new BitmapImage(new Uri(@"img/player.png", UriKind.Relative));
                    rect.Fill = imgBrush;
                    rect.Width = 50;
                    rect.Height = 50;
                    Canvas.SetLeft(rect, x);
                    Canvas.SetTop(rect, y);
                    canvas.Children.Add(rect);

                    last_Player_Position_X = x;
                    last_Player_Position_Y = y;
                    last_player_rect = rect;

                    canvas.Focus();
                    ComboBox_Monster_List.Focusable = false;
                    Remove_Monster.Focusable = false;
                   
                }
            }
            else if (e.Key == Key.Down)
            {

                if (y + 50 <= 500)
                {
                    y += 50;

                    canvas.Children.Remove(last_player_rect);

                    Rectangle rect;
                    rect = new Rectangle();
                    ImageBrush imgBrush = new ImageBrush();
                    imgBrush.ImageSource = new BitmapImage(new Uri(@"img/player.png", UriKind.Relative));
                    rect.Fill = imgBrush;
                    rect.Width = 50;
                    rect.Height = 50;
                    Canvas.SetLeft(rect, x);
                    Canvas.SetTop(rect, y);
                    canvas.Children.Add(rect);

                    last_Player_Position_X = x;
                    last_Player_Position_Y = y;
                    last_player_rect = rect;

                    canvas.Focus();
                    ComboBox_Monster_List.Focusable = false;
                    Remove_Monster.Focusable = false;
                }
            }
            else if (e.Key == Key.Left)
            {

                if (x - 50 >= 0)
                {
                    x -= 50;

                    canvas.Children.Remove(last_player_rect);

                    Rectangle rect;
                    rect = new Rectangle();
                    ImageBrush imgBrush = new ImageBrush();
                    imgBrush.ImageSource = new BitmapImage(new Uri(@"img/player.png", UriKind.Relative));
                    rect.Fill = imgBrush;
                    rect.Width = 50;
                    rect.Height = 50;
                    Canvas.SetLeft(rect, x);
                    Canvas.SetTop(rect, y);
                    canvas.Children.Add(rect);

                    last_Player_Position_X = x;
                    last_Player_Position_Y = y;
                    last_player_rect = rect;

                    canvas.Focus();
                    ComboBox_Monster_List.Focusable = false;
                    Remove_Monster.Focusable = false;
                }
            }
            else if (e.Key == Key.Right)
            {

                if (x + 50 <= 950)
                {
                    x += 50;

                    canvas.Children.Remove(last_player_rect);

                    Rectangle rect;
                    rect = new Rectangle();
                    ImageBrush imgBrush = new ImageBrush();
                    imgBrush.ImageSource = new BitmapImage(new Uri(@"img/player.png", UriKind.Relative));
                    rect.Fill = imgBrush;
                    rect.Width = 50;
                    rect.Height = 50;
                    Canvas.SetLeft(rect, x);
                    Canvas.SetTop(rect, y);
                    canvas.Children.Add(rect);

                    last_Player_Position_X = x;
                    last_Player_Position_Y = y;
                    last_player_rect = rect;

                    canvas.Focus();
                    ComboBox_Monster_List.Focusable = false;
                    Remove_Monster.Focusable = false;
                }
            }
        }

        private void End_turn_Button_Click(object sender, RoutedEventArgs e)
        {
            Monster_Actions_List1.Clear();

            Random rd = new Random();

            int pX = 0;
            int pY = 0;

            int clicks = 0;

            ComboBox_Monster_List.Items.Clear();

            for (int i = 0; i < Monster_Positions1.Count; i++)
            {
                int X = rd.Next(0, Monster_Positions1[i].Monster_Speed);
                int Y = rd.Next(0, Monster_Positions1[i].Monster_Speed);
                int Plus_Minus = rd.Next(0, 2);

                canvas.Children.Remove(Monster_Positions1[i].Last_Monster_Rect);

                // 0 = Plus | 1 = Minus
                if (Plus_Minus == 0)
                {
                    if (((Monster_Positions1[i].Last_Monster_Position_X + X) >= 0) && ((Monster_Positions1[i].Last_Monster_Position_X + X) <= 950))
                    {
                        for (int j = 0; j < List_Last_Positions1.Count(); j++)
                        {
                            if ((Monster_Positions1[i].Last_Monster_Position_X + X) != List_Last_Positions1[j].Last_Monster_Position_X)
                            {
                                pX = Monster_Positions1[i].Last_Monster_Position_X + X;
                            }
                            else
                            {
                                pX = Monster_Positions1[i].Last_Monster_Position_X;
                            }
                        }
                    }

                    if (((Monster_Positions1[i].Last_Monster_Position_Y + Y) >= 0) && ((Monster_Positions1[i].Last_Monster_Position_Y + Y) <= 500))
                    {
                        for (int j = 0; j < List_Last_Positions1.Count(); j++)
                        {
                            if ((Monster_Positions1[i].Last_Monster_Position_Y + Y) != List_Last_Positions1[j].Last_Monster_Position_Y)
                            {
                                pY = Monster_Positions1[i].Last_Monster_Position_Y + Y;
                            }
                            else
                            {
                                pY = Monster_Positions1[i].Last_Monster_Position_Y;
                            }
                        }
                    }
                }
                else if (Plus_Minus == 1)
                {
                    if (((Monster_Positions1[i].Last_Monster_Position_X - X) >= 0) && ((Monster_Positions1[i].Last_Monster_Position_X - X) <= 950))
                    {
                        for (int j = 0; j < List_Last_Positions1.Count(); j++)
                        {
                            if ((Monster_Positions1[i].Last_Monster_Position_X - X) != List_Last_Positions1[j].Last_Monster_Position_X)
                            {
                                pX = Monster_Positions1[i].Last_Monster_Position_X - X;
                            }
                            else
                            {
                                pX = Monster_Positions1[i].Last_Monster_Position_X;
                            }
                        }
                    }

                    if (((Monster_Positions1[i].Last_Monster_Position_Y - Y) >= 0) && ((Monster_Positions1[i].Last_Monster_Position_Y - Y) <= 500))
                    {
                        for (int j = 0; j < List_Last_Positions1.Count(); j++)
                        {
                            if ((Monster_Positions1[i].Last_Monster_Position_Y - Y) != List_Last_Positions1[i].Last_Monster_Position_Y)
                            {
                                pY = Monster_Positions1[i].Last_Monster_Position_Y - Y;
                            }
                            else
                            {
                                pY = Monster_Positions1[i].Last_Monster_Position_Y;
                            }
                        }
                    }
                }

                if (i > 0)
                {
                    if (Plus_Minus == 0)
                    {
                        if (pX == (Monster_Positions1[i - 1].Last_Monster_Position_X))
                        {
                            if ((pX += 50) <= 950)
                            {
                                pX += 50;
                            }
                            else
                            {
                                pX -= 50;
                            }
                        }

                        if (pY == (Monster_Positions1[i - 1].Last_Monster_Position_Y))
                        {
                            if ((pY += 50) <= 500)
                            {
                                pY += 50;
                            }
                            else
                            {
                                pY -= 50;
                            }
                        }
                    }
                    else if (Plus_Minus == 1)
                    {
                        if (pX == (Monster_Positions1[i - 1].Last_Monster_Position_X))
                        {
                            if ((pX -= 50) >= 0)
                            {
                                pX -= 50;
                            }
                            else
                            {
                                pX += 50;
                            }
                        }

                        if (pY == (Monster_Positions1[i - 1].Last_Monster_Position_Y))
                        {
                            if ((pY -= 50) >= 0)
                            {
                                pY -= 50;
                            }
                            else
                            {
                                pY += 50;
                            }
                        }
                    }
                }

                Rectangle rect;
                rect = new Rectangle();
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(@"img/Monster.png", UriKind.Relative));
                rect.Fill = imgBrush;
                rect.Width = 50;
                rect.Height = 50;
                Canvas.SetLeft(rect, pX);
                Canvas.SetTop(rect, pY);
                canvas.Children.Add(rect);


                //Generate monster action
                int Determine_Action = rd.Next(1, 5);
                if (Determine_Action == 1 || Determine_Action == 3)
                {
                    int Monster_D20 = rd.Next(1, 21);
                    Monster_Actions_List1.Add("Monster " + (i + 1) + " rolled " + Monster_D20 + " on its d20");
                }
                else
                {
                    Monster_Actions_List1.Add("Monster " + (i + 1) + " just moved arround...");
                }


                Monster_Positions1[i].Last_Monster_Position_X = pX;
                Monster_Positions1[i].Last_Monster_Position_Y = pY;
                Monster_Positions1[i].Last_Monster_Rect = rect;

                clicks++;
                if (clicks == 10)
                {
                    List_Last_Positions1.RemoveAt(0);
                    clicks = 0;
                }
            }

            for (int i = 0; i < Monster_Positions1.Count(); i++)
            {
                ComboBox_Monster_List.Items.Add("Monster " + (i + 1) + ":  X-> " + Monster_Positions1[i].Last_Monster_Position_X + " |  Y-> " + Monster_Positions1[i].Last_Monster_Position_Y);
            }

            string Actions = string.Join("\r\n", Monster_Actions_List1.ToArray());
            textbox.Text = Actions;
        }

        private void Add_Monster_Click(object sender, RoutedEventArgs e)
        {
            Add_Monster_Func();
        }

        private void Monster_Speed_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Monster_Speed_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Monster_Speed.Focusable = true;
        }

        private void Monster_Speed_MouseLeave(object sender, MouseEventArgs e)
        {
            canvas.Focus();
            Monster_Speed.Focusable = false;
        }

        private void Monster_Speed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Add_Monster_Func();
            }
        }

        private void Add_Monster_Func()
        {
            try
            {
                Random r = new Random();
                int Nx = r.Next(0, 950);
                int Ny = r.Next(0, 500);

                int Speed = Int32.Parse(Monster_Speed.Text);

                if ((Speed < 50) || Speed.Equals("") || Speed.Equals(" "))
                {
                    Speed = 50;
                }
                else if (Speed > 150)
                {
                    Speed = 150;
                }


                if ((Nx != last_Player_Position_X) && (Ny != last_Player_Position_Y))
                {
                    Rectangle rect;
                    rect = new Rectangle();
                    ImageBrush imgBrush = new ImageBrush();
                    imgBrush.ImageSource = new BitmapImage(new Uri(@"img/Monster.png", UriKind.Relative));
                    rect.Fill = imgBrush;
                    rect.Width = 50;
                    rect.Height = 50;
                    Canvas.SetLeft(rect, Nx);
                    Canvas.SetTop(rect, Ny);
                    canvas.Children.Add(rect);

                    int last_Monster_Position_X = Nx;
                    int last_Monster_Position_Y = Ny;

                    Monster_Positions1.Add(new Monster_Token(last_Monster_Position_X, last_Monster_Position_Y, Speed, rect));
                    List_Last_Positions1.Add(new Monster_Token(last_Monster_Position_X, last_Monster_Position_Y, Speed, rect));

                    int pos = Monster_Positions1.Count() - 1;
                    ComboBox_Monster_List.Items.Add("Monster " + (pos + 1) + ":  X-> " + Monster_Positions1.ElementAt(Monster_Positions1.Count() - 1).Last_Monster_Position_X + " |  Y-> " + Monster_Positions1.ElementAt(Monster_Positions1.Count() - 1).Last_Monster_Position_Y);

                    Monster_Speed.Focusable = false;
                    canvas.Focus();
                    ComboBox_Monster_List.Focusable = false;
                    Remove_Monster.Focusable = false;
                }
                else
                {
                    int Second_P_X = r.Next(0, 950);
                    int Second_P_Y = r.Next(0, 500);

                    Rectangle rect;
                    rect = new Rectangle();
                    ImageBrush imgBrush = new ImageBrush();
                    imgBrush.ImageSource = new BitmapImage(new Uri(@"img/Monster.png", UriKind.Relative));
                    rect.Fill = imgBrush;
                    rect.Width = 50;
                    rect.Height = 50;
                    Canvas.SetLeft(rect, Second_P_X);
                    Canvas.SetTop(rect, Second_P_Y);
                    canvas.Children.Add(rect);

                    int Second_last_Monster_Position_X = Second_P_X;
                    int Second_last_Monster_Position_Y = Second_P_Y;

                    Monster_Positions1.Add(new Monster_Token(Second_last_Monster_Position_X, Second_last_Monster_Position_Y, Speed, rect));
                    List_Last_Positions1.Add(new Monster_Token(Second_last_Monster_Position_X, Second_last_Monster_Position_Y, Speed, rect));

                    int pos = Monster_Positions1.Count() - 1;
                    ComboBox_Monster_List.Items.Add("Monster " + (pos + 1) + ":  X-> " + Monster_Positions1.ElementAt(Monster_Positions1.Count() - 1).Last_Monster_Position_X + " |  Y-> " + Monster_Positions1.ElementAt(Monster_Positions1.Count() - 1).Last_Monster_Position_Y);

                    Monster_Speed.Focusable = false;
                    canvas.Focus();
                    ComboBox_Monster_List.Focusable = false;
                    Remove_Monster.Focusable = false;
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong :(\r\n\r\nPlease try again and if the problem persists, feel free to contact me.\r\n\r\nSomething that might be causing the problem is that you didn't add a value to the monster speed.", "Something went wrong");
            }
        }

        private void Remove_Monster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                canvas.Children.Remove(Monster_Positions1[ComboBox_Monster_List.SelectedIndex].Last_Monster_Rect);

                Monster_Positions1.RemoveAt(ComboBox_Monster_List.SelectedIndex);
                ComboBox_Monster_List.Items.Remove(ComboBox_Monster_List.SelectedIndex);

                ComboBox_Monster_List.Items.Clear();

                for (int i = 0; i < Monster_Positions1.Count(); i++)
                {
                    ComboBox_Monster_List.Items.Add("Monster " + (i + 1) + ":  X-> " + Monster_Positions1[i].Last_Monster_Position_X + " |  Y-> " + Monster_Positions1[i].Last_Monster_Position_Y);
                }
                canvas.Focus();
                ComboBox_Monster_List.Focusable = false;
                Remove_Monster.Focusable = false;
            }
            catch
            {
                MessageBox.Show("You must select a monster to remove.");
            }
        }

        private void ComboBox_Monster_List_MouseLeave(object sender, MouseEventArgs e)
        {
            canvas.Focus();
            ComboBox_Monster_List.Focusable = false;
            Remove_Monster.Focusable = false;
        }
    }
}
