using ErrandApp.Models;
using ErrandApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace ErrandApp.Views
{

    public sealed partial class ClosedErrands : Page
    {
        public ClosedErrands()
        {
            this.InitializeComponent();
        }

        private void btnClosed_Click(object sender, RoutedEventArgs e)
        {
            lvClosed.ItemsSource = ErrandService.GetErrandsClosed((Application.Current as App)
                .connectionString).Take(Views.Settings.SetItemsMax());
        }

        private void lvClosed_ItemClick(object sender, ItemClickEventArgs e)
        {
                Errand errand = (Errand)lvClosed.SelectedItem;
                idLoad.Text = Convert.ToString(errand.Id);
                descriptionLoad.Text = errand.Description;
                firstnameLoad.Text = errand.CustomerFirstName;
                lastnameLoad.Text = errand.CustomerLastName;
                phonenumberLoad.Text = Convert.ToString(errand.CustomerPhonenumber);
                emailLoad.Text = errand.CustomerEmail;
                commentsload.Text = errand.Comment;
 

        }
    }
}
