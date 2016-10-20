﻿using DevEvent.Apps.Models;
using DevEvent.Apps.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DevEvent.Apps.Pages
{
    public partial class MainPage : ContentPage
    {
        //MobileEventManager manager;


        public MainPage()
        {
            InitializeComponent();
            Month.Text = "행사 목록";
            GetEventList();

            // Init 
            //manager = MobileEventManager.DefaultManager;

            //await manager.GetEventItemsAsync(true);
        }

        async void GetEventList()
        {
            ApiService apiService = new ApiService();
            var list = await apiService.GetAllEvent(DateTime.Now);

            foreach (var item in list)
            {
                string ImageURL = "img" + item.ImageNumber + ".png";
                item.EventTitle = item.EventTitle;
                item.EventStartDay = item.EventStartDay;
                item.Description = item.Description;
                //item.Image = ImageURL;
            }
            MyList.ItemsSource = list;
        }

        //이벤트 정보 넘겨주는 코드 
        async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                
                if(e.SelectedItem is ViewModels.EventListViewModel)
                {
                    //await Navigation.PushAsync()
                }
                /*if (e.SelectedItem is ViewModels.OrderViewModel)
                {
                    var list = e.SelectedItem as ViewModels.OrderViewModel;
                    var modelList = e.SelectedItem as Models.Event;
                    var eventDetailPage = new EventDetailPage(list.locationX, list.locationY, list.Venue, list.EventStartDay, list.ContentsURL, list.RegistrationURL, list.Audience);
                    eventDetailPage.BindingContext = list;

                    await Navigation.PushAsync(eventDetailPage);

                }
                else
                {
                    var list = e.SelectedItem as Models.Event;
                    var eventDetailPage = new EventDetailPage(list.locationX, list.locationY, list.Venue, list.EventStartDay, list.ContentsURL, list.RegistrationURL, list.Audience);
                    eventDetailPage.BindingContext = list;

                    await Navigation.PushAsync(eventDetailPage);
                } */               
            }
        }

    }
}
