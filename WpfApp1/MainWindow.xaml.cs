using SetsExample;
using System.Linq.Expressions;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySet<int> firstset = new MySet<int>();
        MySet<int> secondset = new MySet<int>();
        MySet<int> thirdset = new MySet<int>();
        MySet<int> fourthset = new MySet<int>();
        MySet<int> selectedSet1 = new MySet<int>();
        MySet<int> selectedSet2 = new MySet<int>();
        bool isSet1Empty = true;
        bool isSet2Empty = true;
        bool isResultEmpty = true;
        public MainWindow()
        {
            InitializeComponent();

            // Create 4 Sets with random numbers
            Random rnd = new Random();
            int num = 0;
            // 1st
            for (int i = 0; i < 10; i++)
            {
                num = rnd.Next(50,200);
                if (!firstset.Contains(num))
                    firstset.Add(num);
                else
                    i--;
            }
            for (int i = 0; i < 15; i++)
            {
                num = rnd.Next(50, 200);
                if (!secondset.Contains(num))
                    secondset.Add(num);
                else
                    i--;
            }
            for (int i = 0; i < 9; i++)
            {
                num = rnd.Next(50, 200);
                if (!thirdset.Contains(num))
                    thirdset.Add(num);
                else
                    i--;
            }
            for (int i = 0; i < 12; i++)
            {
                num = rnd.Next(50, 200);
                if (!fourthset.Contains(num))
                    fourthset.Add(num);
                else
                    i--;
            }
        }

        private void SetSelection1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isSet1Empty)
            {
                Set1.Items.Clear();
            }
            switch (SetSelection1.SelectedIndex)
            {
                case 0:
                    foreach (var item in firstset)
                        Set1.Items.Add(item);
                    selectedSet1 = firstset;
                    break;
                case 1:
                    foreach (var item in secondset)
                        Set1.Items.Add(item);
                    selectedSet1 = secondset;
                    break;
                case 2:
                    foreach (var item in thirdset)
                        Set1.Items.Add(item);
                    selectedSet1 = thirdset;
                    break;
                case 3:
                    foreach (var item in fourthset)
                        Set1.Items.Add(item);
                    selectedSet1 = fourthset;
                    break;
                default:
                    break;
            }

            isSet1Empty = false;
        }

        private void SetSelecyion2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isSet2Empty)
            {
                Set2.Items.Clear();
            }
            switch (SetSelection2.SelectedIndex)
            {
                case 0:
                    foreach (var item in firstset)
                        Set2.Items.Add(item);
                    selectedSet2 = firstset;
                    break;
                case 1:
                    foreach (var item in secondset)
                        Set2.Items.Add(item);
                    selectedSet2 = secondset;
                    break;
                case 2:
                    foreach (var item in thirdset)
                        Set2.Items.Add(item);
                    selectedSet2 = thirdset;
                    break;
                case 3:
                    foreach (var item in fourthset)
                        Set2.Items.Add(item);
                    selectedSet2 = fourthset;
                    break;
                default:
                    break;
            }

            isSet2Empty = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySet<int> afterAction = new MySet<int>();
            switch (Action.SelectedIndex)
            {
                case 0:
                    afterAction = selectedSet1.Union(selectedSet2);
                    break;
                case 1:
                    afterAction = selectedSet1.Interesection(selectedSet2);
                    break;
                case 2:
                    afterAction = selectedSet1.Difference(selectedSet2);
                    break;
                case 3:
                    afterAction = selectedSet1.SymmetricalDifference(selectedSet2);
                    break;
                default:
                    break;
            }
            if (!isResultEmpty)
            {
                AfterEvaluation.Items.Clear();
            }
            foreach (var item in afterAction)
                AfterEvaluation.Items.Add(item);
            isResultEmpty = false;
        }
    }
}