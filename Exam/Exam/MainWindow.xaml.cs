using System;
using System.Collections.Generic;
using System.Data;
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

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public  int id, amount, price;
        public  string name;

        List<Good> goods = new List<Good>();
        public MainWindow()
        {
            InitializeComponent();
            if (dataGrid.Items != null)
            {
                using (var context = new GoodContext())
                {
                    goods = context.Goods.ToList();
                    dataGrid.ItemsSource = goods;
                }
            }
            else if(dataGrid.Items == null)
            {
                dataGrid.ItemsSource = goods;
            }

        }  
      

        private void dataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {


               

                using (var context = new GoodContext())
                {
                    context.Goods.Add(new Good
                    {

                        Id = id,
                        Name = name,
                        Price = price,
                        Amount = amount
                    });
                    context.SaveChanges();


                }

            }
        }

        private void dataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            DataRowView rowView = e.Row.Item as DataRowView;


            if (rowView != null)
            {
                id = Convert.ToInt32(rowView[0]);
                name = rowView[1].ToString();
                price = Convert.ToInt32(rowView[2]);
                amount = Convert.ToInt32(rowView[3]);
            }


        }

    }
}
