using BLL.Services;
using DAL.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RentServiceApp.Pages
{
    /// <summary>
    /// Interaction logic for RentDepartmentPage.xaml
    /// </summary>
    public partial class RentDepartmentPage : Page
    {
        IRentService rentService = new RentService();
        public RentDepartmentPage()
        {
            InitializeComponent();
            LoadComboBox();
        }
        void LoadComboBox()
        {
            List<int> tmp = new List<int> { 1, 2, 3 };

            cbDepartmentId.ItemsSource = tmp;
            cbUsers.ItemsSource = tmp;
        }
        void ClearAllInput()
        {
            checkBoxIsAviable.IsChecked = false;
            txtHouseName.Text = null;
            datetimefrom.SelectedDate = null;
            datetimeto.SelectedDate = null;
            cbUsers.SelectedItem = null;
            cbDepartmentId.SelectedItem = null;
        }

        void AddNewDepartment()
        {
            try
            {
                rentService.Add(
                    new Rent()
                    {
                        IsAviable = (bool)checkBoxIsAviable.IsChecked,
                        HouseName = txtHouseName.Text,
                        DateFrom = datetimefrom.SelectedDate.Value,
                        DateTo = datetimeto.SelectedDate.Value,
                        UserId = (int)cbUsers.SelectedItem,
                        DepartmentId = (int)cbDepartmentId.SelectedItem
                    });
                ClearAllInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewDepartment();
        }
    }
}
