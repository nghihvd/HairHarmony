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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HairHarmony_BusinessObject;
using HairHarmony_Repository;
using HairHarmony_Services;

namespace PRN212_HairHarmony
{
    /// <summary>
    /// Interaction logic for Service.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        private readonly IServiceService iServiceseivce;
        


        public ServiceWindow()
        {
            InitializeComponent();
            iServiceseivce = new ServiceService();
        }

        public void LoadServiceList()
        {
            try
            {
                
                dtgService.ItemsSource = iServiceseivce.GetServiceList().Select(a => new {a.ServiceId, a.ServiceName, a.Duration, a.Price }); 
            }
            catch (Exception ex)
            {

            }
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomeWindow homeWindow = new HomeWindow();
            homeWindow.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator
                .ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowColumn =
                dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            String serviceID = ((TextBlock)RowColumn.Content).Text;
            Service service = iServiceseivce.GetServiceByID(Int32.Parse(serviceID));
            txtServiceName.Text = service.ServiceName.ToString();
            txtDuration.Text = $"{(service.Duration)}";
            txtPrice.Text = $"${service.Price:F2}";
        }
    }
    
}
