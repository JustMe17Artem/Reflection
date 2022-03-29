using System;
using System.Windows;
using System.Windows.Controls;
using ClassLibrary;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.IO;
using System.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name = Name.Text;
            Car car = new Car (name, 60);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(car);
            if (!Validator.TryValidateObject(car, context, results, true))
            {
                foreach (var error in results)
                {
                    InvalidName.Text = error.ErrorMessage;
                }
            }
            else
            {
                InvalidName.Text = "";
            }
            
        }

        private void Speed_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int speed = Convert.ToInt32(Speed.Text);
                Car car = new Car ("fdfdf", speed);
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var context = new ValidationContext(car);
                if (!Validator.TryValidateObject(car, context, results, true))
                {               
                    foreach (var error in results)
                    {
                        InvalidSpeed.Text = error.ErrorMessage;
                    }
                }
                else
                {
                    InvalidSpeed.Text = "";
                }
            }
            catch (FormatException)
            {
                InvalidSpeed.Text = "Wrong format";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Car car = new Car(Name.Text, Int32.Parse(Speed.Text));
            Car.WriteToJson(car);    
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void NameCar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var car = Car.cars.Where(c => c.Name == NameCar.Text).FirstOrDefault();
            if(car != null)
            {

                SpeedCar.Text = car.MaxSpeed.ToString();
            }
            else
            {
                SpeedCar.Text = "no such car";
            }
        }
    }
}
