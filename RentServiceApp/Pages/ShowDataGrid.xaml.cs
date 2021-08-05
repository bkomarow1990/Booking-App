using BLL.Services;
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
    /// Interaction logic for ShowDataGrid.xaml
    /// </summary>
    public partial class ShowDataGrid : Page
    {
        IRentService rentService = new RentService();
        IUserService userService = new UserService();
        public ShowDataGrid()
        {
            InitializeComponent();
            datagrid.ItemsSource = rentService.GetAll().ToList();
        }
    }
}
