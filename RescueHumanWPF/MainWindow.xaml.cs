using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RescueHumanWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        DispatcherTimer enemyTimer = new DispatcherTimer();
        DispatcherTimer targetTimer = new DispatcherTimer();
        bool humanCaptured = false;
        public MainWindow()
        {
            InitializeComponent();
            enemyTimer.Tick += enemyTimer_Tick;
            enemyTimer.Interval = TimeSpan.FromSeconds(2);

            targetTimer.Tick += targetTimer_Tick;
            targetTimer.Interval = TimeSpan.FromSeconds(.1);
        }

        private void EndTheGame()
        {
            if (!PlayArea.Children.Contains(textBlock1))
            {
                enemyTimer.Stop();
                targetTimer.Stop();
                humanCaptured = false;
                button.Visibility = Visibility.Visible;
                textBlock1.Visibility = Visibility.Visible;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            humanCaptured = false;
            progressBar.Value = 0;
            button.Visibility = Visibility.Collapsed;
            textBlock1.Visibility = Visibility.Collapsed;
            textBlock1.Text = "Game Over";
            PlayArea.Children.Clear();
            PlayArea.Children.Add(target);
            PlayArea.Children.Add(human);
            enemyTimer.Start();
            targetTimer.Start();
        }

        private void AddEnemy()
        {
            ContentControl enemy = new ContentControl();
            enemy.Template = Resources["EnemyTemplate"] as ControlTemplate;
            AnimateEnemy(enemy, 0, PlayArea.ActualWidth - 100, "(Canvas.Left)");
            AnimateEnemy(enemy, random.Next((int)PlayArea.ActualHeight - 100), random.Next((int)PlayArea.ActualHeight - 100), "(Canvas.Top)");
            PlayArea.Children.Add(enemy);


            enemy.MouseEnter += Enemy_MouseEnter; ;
        }

        private void AnimateEnemy(ContentControl enemy, double from, double to, string propertyToChange)
        {
            Storyboard storyboard = new Storyboard() { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever };
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = new Duration(TimeSpan.FromSeconds(random.Next(2, 6)))

            };
            Storyboard.SetTarget(animation, enemy);
            Storyboard.SetTargetProperty(animation, new PropertyPath(propertyToChange));
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        private void targetTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Value += 1;
            if (progressBar.Value >= progressBar.Maximum)
                EndTheGame();
        }

        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            AddEnemy();
        }

        private void PlayArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (humanCaptured)
            {
                Point pointerPosition = e.GetPosition(null);
                Point relativePosition = grid.TransformToVisual(PlayArea).Transform(pointerPosition);
                if ((Math.Abs(relativePosition.X - Canvas.GetLeft(human)) > human.ActualWidth * 3)
                    || (Math.Abs(relativePosition.Y - Canvas.GetTop(human)) > human.ActualHeight * 3))
                {
                    humanCaptured = false;
                }
                else
                {
                    Canvas.SetLeft(human, relativePosition.X - human.ActualWidth / 2);
                    Canvas.SetTop(human, relativePosition.Y - human.ActualHeight / 2);
                }
            }
        }

        private void Enemy_MouseEnter(object sender, MouseEventArgs e)
        {
            if (humanCaptured)
                EndTheGame();
        }

        private void human_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (enemyTimer.IsEnabled)
            {
                humanCaptured = true;
            }
        }

        private void human_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (targetTimer.IsEnabled)
            {
                humanCaptured = false;
                Point pointerPosition = e.GetPosition(null);
                Rect rect = new Rect(Canvas.GetLeft(target), Canvas.GetTop(target) + 2 * target.Height, target.Width, target.Height);
                if (rect.Contains(pointerPosition))
                {
                    progressBar.Value = 0;
                    Canvas.SetLeft(target, random.Next(100, (int)PlayArea.ActualWidth - 100));
                    Canvas.SetTop(target, random.Next(100, (int)PlayArea.ActualHeight - 100));
                    Canvas.SetLeft(human, random.Next(100, (int)PlayArea.ActualWidth - 100));
                    Canvas.SetTop(human, random.Next(100, (int)PlayArea.ActualHeight - 100));
                }
            }
        }

        private void PlayArea_MouseLeave(object sender, MouseEventArgs e)
        {
            if (humanCaptured)
                EndTheGame();
        }
    }
}
