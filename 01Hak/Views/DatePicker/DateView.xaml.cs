using System.Windows.Controls;
using _01Hak.ViewModels.DatePicker;

namespace _01Hak.Views.DatePicker
{
    /// <summary>
    /// Interaction logic for DateView.xaml
    /// </summary>
    public partial class DateView : UserControl
    {
        public DateView()
        {
            InitializeComponent();
            DataContext = new DateViewModel();
        }
    }
}
