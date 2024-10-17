using Microsoft.Maui.Controls;
using System.Linq;
using System.Text;

namespace roomTime
{
    public partial class CreateFormPage : ContentPage
    {
        public CreateFormPage()
        {
            InitializeComponent();
            CreateDynamicTable(0, 1);
        }

        private void OnCreateTableClicked(object sender, EventArgs e)
        {
            if (int.TryParse(RowEntry.Text, out int rows) && int.TryParse(ColumnEntry.Text, out int columns))
            {
                if (rows > 0 && columns > 0)
                {
                    CreateDynamicTable(rows, columns);
                    ConfirmButton.IsVisible = true; // Show the confirm button after table creation
                }
                else
                {
                    DisplayAlert("B³¹d", "Podaj wartoœæ wiêksz¹ od 0.", "OK");
                }
            }
            else
            {
                DisplayAlert("B³¹d", "Podaj wartoœæ liczbow¹.", "OK");
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        }

        private void CreateDynamicTable(int rows, int columns)
        {
            DynamicGrid.RowDefinitions.Clear();
            DynamicGrid.ColumnDefinitions.Clear();
            DynamicGrid.Children.Clear();

            for (int col = 0; col < columns + 2; col++)
            {
                DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int row = 0; row < rows + 1; row++)
            {
                DynamicGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            for (int row = 0; row < rows + 1; row++)
            {
                for (int col = 0; col < columns + 2; col++)
                {
                    var entry = new Entry
                    {
                        TextColor = Colors.White,
                        BackgroundColor = Colors.Black,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    };

                    if (row == 0)
                    {
                        switch (col)
                        {
                            case 0: entry.Placeholder = "Godz Lekcja"; break;
                            case 1: entry.Placeholder = "Nr Lekcji"; break;
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8: entry.Placeholder = "Dzieñ"; break;
                            default: entry.Placeholder = "ERROR"; break;
                        }
                    }
                    else
                    {
                        if (col == 0) entry.Placeholder = "Godz Lekcyjna";
                        else if (col == 1) entry.Placeholder = "Nr Lekcji";
                        else entry.Placeholder = "Lekcja Sala";
                    }

                    DynamicGrid.Children.Add(entry);
                    Grid.SetRow(entry, row);
                    Grid.SetColumn(entry, col);
                }
            }
        }

        private void OnConfirmButtonClicked(object sender, EventArgs e)
        {
            int columns = DynamicGrid.ColumnDefinitions.Count;
            int rows = DynamicGrid.RowDefinitions.Count;

            // Create a list to hold arrays for each column
            string[][] columnData = new string[columns][];

            // Iterate through columns
            for (int col = 0; col < columns; col++)
            {
                // Initialize each column as a new string array with the number of rows
                columnData[col] = new string[rows];

                // Iterate through rows for the current column
                for (int row = 0; row < rows; row++)
                {
                    var entry = DynamicGrid.Children
                        .OfType<Entry>()
                        .FirstOrDefault(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);

                    if (entry != null)
                    {
                        // Save the text of each Entry into the array
                        columnData[col][row] = entry.Text;
                    }
                }
            }

            // Build a string to display the arrays
            StringBuilder displayText = new StringBuilder();
            for (int i = 0; i < columnData.Length; i++)
            {
                string columnValues = string.Join(", ", columnData[i]);
                displayText.AppendLine($"Kolumna {i + 1}: {columnValues}");
            }

            // Display the array contents in an alert
            DisplayAlert("Powiadomienie", displayText.ToString(), "OK");

            Navigation.PopAsync();
        }
    }
}
