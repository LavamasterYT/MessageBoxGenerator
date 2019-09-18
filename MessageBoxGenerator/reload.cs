using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoxGenerator
{
    class reload
    {
        public async void reloadWindow()
        {
            System.Windows.Forms.MessageBox.Show("Closing");
            MainWindow main = new MainWindow();
            await Task.Delay(5000);
            main.Show();
        }
    }
}
