using MySetProj;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp;


/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    MySet<Student> _men = new MySet<Student>();
    MySet<Student> _women = [];

    MySet<Student> _reading = [];
    MySet<Student> _writing = new MySet<Student>();
    MySet<Student> _arithmetic = [];

    Dictionary<string, MySet<Student>> allSets = new Dictionary<string, MySet< Student>>();

    public MainWindow()
    {
        Student james = new(id:1, name:"James", Gender.Male);
        Student  robert = new(id: 2, name: "Robert", Gender.Male);
        Student john = new(id: 3, name: "John", Gender.Male);
        Student mark = new(id: 4, name:"Mark", Gender.Male) ;
        Student otherMark = new(id: 5, name: "Mark", Gender.Male);
        _men.AddRange(new Student[] { james, robert, john, mark, otherMark });

        Student liz = new(id: 1, name: "Liza", Gender.Female);
        Student amy = new(id: 2, name: "Amy", Gender.Female);
        Student eve = new(id: 3, name: "Evelyn", Gender.Female);
        _women.AddRange(new Student[] { liz, amy, eve });

        _reading.AddRange(new Student[] { james, robert, liz });
        _writing.AddRange([robert, mark, amy, liz]);
        _arithmetic.AddRange(new Student[] { john, mark, otherMark, amy });

        allSets.Add("Men", _men);
        allSets.Add("Women", _women);
        allSets.Add("Reading", _reading);
        allSets.Add("Writing", _writing);
        allSets.Add("Arithmetic", _arithmetic);

        InitializeComponent();
    }

    public MainWindow(MySet<Student> writing)
    {
        _writing = writing;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (string name in allSets.Keys)
        {
            leftSet.Items.Add(name);
            rightSet.Items.Add(name);
        }
        operation.Items.Add("UNION");
        operation.Items.Add("INTERSECTION");
        operation.Items.Add("DIFFERENCE");
        operation.Items.Add("SYMETRIC DIFF");


    }

    private void leftMySet_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        leftMembers.Items.Clear();

        if (e.AddedItems.Count > 0)
        {
            DisplayMySetData(GetMySetByName(e.AddedItems[0].ToString()), leftMembers);
        }
    }
    
    private void rightMySet_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        rightMembers.Items.Clear();

        if (e.AddedItems.Count > 0)
        {
            DisplayMySetData(GetMySetByName(e.AddedItems[0].ToString()), rightMembers);
        }
    }

    private MySet<Student> GetMySetByName(string? v)
    {
        throw new NotImplementedException();
    }

    private void DisplayMySetData(MySet<Student> set, ListBox listBox)
    {
        foreach (var student in set)
        {
            listBox.Items.Add(student.Name);
        }
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var listBox = sender as ListBox;
        var selectedItem = listBox.SelectedItem;

        MessageBox.Show(selectedItem.ToString());
    }

    private void evaluateButton_Click(object sender, RoutedEventArgs e)
    {
        if (leftSet.SelectedItem == null || rightSet.SelectedItem == null || operation.SelectedItem == null)
        {
            MessageBox.Show("Please select both sets and operation!");
            return;
        }

        var left = GetMySetByName(leftSet.SelectedItem.ToString());
        var right = GetMySetByName(rightSet.SelectedItem.ToString());
        var op = operation.SelectedItem.ToString();

        MySet<Student> result = new MySet<Student>();

        switch (op)
        {
            case "UNION":
                result = left.Union(right);
                break;

            case "INTERSECTION":
                result = left.Intersection(right);
                break;

            case "DIFFERENCE":
                result = left.Difference(right);
                break;

            case "SYMETRIC DIFF":
                result = left.SymmetricDifference(right);
                break;
        }

        resultSet.Items.Clear();
        DisplayMySetData(result, resultSet);
    }

}