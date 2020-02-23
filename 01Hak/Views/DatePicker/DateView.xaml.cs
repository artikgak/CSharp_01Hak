using System.Windows.Controls;
using KMACSharp01Hak.ViewModels.DatePicker;

namespace KMACSharp01Hak.Views.DatePicker
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
