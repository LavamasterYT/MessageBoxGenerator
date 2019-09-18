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
using System.Windows.Forms;
using Microsoft.Win32;

namespace MessageBoxGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\CMBG", true);
            if (!Convert.ToBoolean(reg.GetValue("isDarkMode")))
            {
                ldmode.Content = "Switch To Dark Mode";
            }
            var converter = new System.Windows.Media.BrushConverter();
            var darkWhite = (Brush)converter.ConvertFromString("#F0F0F0");

            if (reg != null)
            {
                if (Convert.ToBoolean(reg.GetValue("isDarkMode")))
                {

                }
                else
                {
                    Style button = new Style
                    {
                        TargetType = typeof(System.Windows.Controls.Button)
                    };
                    Style label = new Style
                    {
                        TargetType = typeof(System.Windows.Controls.Label)
                    };
                    Style radio = new Style
                    {
                        TargetType = typeof(System.Windows.Controls.RadioButton)
                    };
                    Style box = new Style
                    {
                        TargetType = typeof(System.Windows.Controls.TextBox)
                    };
                    Style back = new Style
                    {
                        TargetType = typeof(System.Windows.Controls.Border)
                    };
                    Style title = new Style
                    {
                        TargetType = typeof(System.Windows.Controls.Border)
                    };

                    label.Setters.Add(new Setter(System.Windows.Controls.Label.ForegroundProperty, Brushes.Black));
                    radio.Setters.Add(new Setter(System.Windows.Controls.RadioButton.ForegroundProperty, Brushes.Black));
                    box.Setters.Add(new Setter(System.Windows.Controls.TextBox.ForegroundProperty, Brushes.Black));
                    box.Setters.Add(new Setter(System.Windows.Controls.TextBox.BorderBrushProperty, Brushes.White));
                    box.Setters.Add(new Setter(System.Windows.Controls.TextBox.BackgroundProperty, Brushes.LightGray));
                    button.Setters.Add(new Setter(System.Windows.Controls.TextBox.ForegroundProperty, Brushes.Black));
                    button.Setters.Add(new Setter(System.Windows.Controls.TextBox.BorderBrushProperty, Brushes.White));
                    button.Setters.Add(new Setter(System.Windows.Controls.TextBox.BackgroundProperty, Brushes.LightGray));
                    back.Setters.Add(new Setter(System.Windows.Controls.Border.BackgroundProperty, Brushes.White));
                    title.Setters.Add(new Setter(System.Windows.Controls.Border.BackgroundProperty, darkWhite));

                    System.Windows.Application.Current.Resources["button"] = button;
                    System.Windows.Application.Current.Resources["label"] = label;
                    System.Windows.Application.Current.Resources["textbox"] = box;
                    System.Windows.Application.Current.Resources["radio"] = radio;
                    System.Windows.Application.Current.Resources["title"] = title;
                    System.Windows.Application.Current.Resources["back"] = back;
                }
            }
            else
            {
                RegistryKey reg2 = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\CMBG", true);
                reg2.SetValue("isDarkMode", true);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            var button = MessageBoxButtons.OK;
            var icon = MessageBoxIcon.Error;

            if (error.IsChecked == true)
            {
                icon = MessageBoxIcon.Error;
            }
            else if (warning.IsChecked == true)
            {
                icon = MessageBoxIcon.Warning;
            }
            else if (information.IsChecked == true)
            {
                icon = MessageBoxIcon.Information;
            }
            else if (question.IsChecked == true)
            {
                icon = MessageBoxIcon.Question;
            }
            else
            {
                icon = MessageBoxIcon.None;
            }

            if (ari.IsChecked == true)
            {
                button = MessageBoxButtons.AbortRetryIgnore;
            }
            else if (ok.IsChecked == true)
            {
                button = MessageBoxButtons.OK;
            }
            else if (okcancel.IsChecked == true)
            {
                button = MessageBoxButtons.OKCancel;
            }
            else if (retrycancel.IsChecked == true)
            {
                button = MessageBoxButtons.RetryCancel;
            }
            else if (yesno.IsChecked == true)
            {
                button = MessageBoxButtons.YesNo;
            }
            else if (yesnocancel.IsChecked == true)
            {
                button = MessageBoxButtons.YesNoCancel;
            }

            System.Windows.Forms.MessageBox.Show(message.Text, title.Text, button, icon);
        }

        private void IconGen_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("This is Error",       "Icon",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            System.Windows.Forms.MessageBox.Show("This is Information", "Icon",  MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Windows.Forms.MessageBox.Show("This is Warning",     "Icon",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
            System.Windows.Forms.MessageBox.Show("This is Question",    "Icon",  MessageBoxButtons.OK, MessageBoxIcon.Question);
            System.Windows.Forms.MessageBox.Show("This is None", "Icon", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void ButGen_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("This is OK", "Buttons", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Windows.Forms.MessageBox.Show("This is OK, Cancel", "Buttons", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            System.Windows.Forms.MessageBox.Show("This is Retry, Cancel", "Buttons", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
            System.Windows.Forms.MessageBox.Show("This is Abort, Retry, Ignore", "Buttons", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);
            System.Windows.Forms.MessageBox.Show("This is Yes, No", "Buttons", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            System.Windows.Forms.MessageBox.Show("This is Yes, No, Cancel", "Buttons", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        }

        private void Ldmode_Click(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var darkWhite = (Brush)converter.ConvertFromString("#F0F0F0");

            var backC = (Brush)converter.ConvertFromString("#101010");

            RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\CMBG", true);

            if (!Convert.ToBoolean(reg.GetValue("isDarkMode")))
            {
                reg.SetValue("isDarkMode", true);
                System.Diagnostics.Process.Start(System.Windows.Application.ResourceAssembly.Location);
                System.Windows.Application.Current.Shutdown();
            }
            else
            {
                Style button = new Style
                {
                    TargetType = typeof(System.Windows.Controls.Button)
                };
                Style label = new Style
                {
                    TargetType = typeof(System.Windows.Controls.Label)
                };
                Style radio = new Style
                {
                    TargetType = typeof(System.Windows.Controls.RadioButton)
                };
                Style box = new Style
                {
                    TargetType = typeof(System.Windows.Controls.TextBox)
                };
                Style back = new Style
                {
                    TargetType = typeof(System.Windows.Controls.Border)
                };
                Style title = new Style
                {
                    TargetType = typeof(System.Windows.Controls.Border)
                };

                label.Setters.Add(new Setter(System.Windows.Controls.Label.ForegroundProperty, Brushes.Black));
                radio.Setters.Add(new Setter(System.Windows.Controls.RadioButton.ForegroundProperty, Brushes.Black));
                box.Setters.Add(new Setter(System.Windows.Controls.TextBox.ForegroundProperty, Brushes.Black));
                box.Setters.Add(new Setter(System.Windows.Controls.TextBox.BorderBrushProperty, Brushes.White));
                box.Setters.Add(new Setter(System.Windows.Controls.TextBox.BackgroundProperty, Brushes.LightGray));
                button.Setters.Add(new Setter(System.Windows.Controls.TextBox.ForegroundProperty, Brushes.Black));
                button.Setters.Add(new Setter(System.Windows.Controls.TextBox.BorderBrushProperty, Brushes.White));
                button.Setters.Add(new Setter(System.Windows.Controls.TextBox.BackgroundProperty, Brushes.LightGray));
                back.Setters.Add(new Setter(System.Windows.Controls.Border.BackgroundProperty, Brushes.White));
                title.Setters.Add(new Setter(System.Windows.Controls.Border.BackgroundProperty, darkWhite));

                System.Windows.Application.Current.Resources["button"] = button;
                System.Windows.Application.Current.Resources["label"] = label;
                System.Windows.Application.Current.Resources["textbox"] = box;
                System.Windows.Application.Current.Resources["radio"] = radio;
                System.Windows.Application.Current.Resources["title"] = title;
                System.Windows.Application.Current.Resources["back"] = back;
                reg.SetValue("isDarkMode", false);
                ldmode.Content = "Switch To Dark Mode";
            }
        }
    }
}
