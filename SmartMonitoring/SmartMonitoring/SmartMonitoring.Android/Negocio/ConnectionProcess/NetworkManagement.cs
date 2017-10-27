using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using SmartMonitoring.Droid.Negocio.ConnectionProcess;
using SmartMonitoring;
using Android.Net;

[assembly: Dependency(typeof(NetworkManagement))]
namespace SmartMonitoring.Droid.Negocio.ConnectionProcess
{
    public class NetworkManagement : INetworkManagement
    {
        public bool IsOn()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        public void sendEmail(List<string> list)
        {
            var email = new Intent(Android.Content.Intent.ActionSend);
            email.PutExtra(Android.Content.Intent.ExtraEmail,
            new string[] { "person1@xamarin.com", "person2@xamrin.com" });

          

            email.PutExtra(Android.Content.Intent.ExtraSubject, "Diagnóstico CareConnect ");

            email.PutExtra(Android.Content.Intent.ExtraText,
            "Hello from Xamarin.Android");
            email.SetType("message/rfc822");
            Forms.Context.StartActivity(email);
        }
    }
}