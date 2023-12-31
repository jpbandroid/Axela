﻿using System.Diagnostics;
using System.Net;
using System.Reflection;
using App2.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Windows.Media.PlayTo;
using Windows.Security.Cryptography.Core;
using Windows.System;

namespace App2.Views;

public sealed partial class MainPage : Microsoft.UI.Xaml.Controls.Page
{
    private string AxelaText;

    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        AxelaText = axelabox.Text;
        tester.Text = AxelaText;
        AxelaText = AxelaText.ToLower();
        processText();
    }

    private async void processText()
    {
        if (AxelaText != null)
        {
            if (AxelaText.Length > 0)
            {
                if (AxelaText.Contains("hello") || AxelaText.Contains("hi") || AxelaText.Contains("hii")) {
                    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    AxelaResponseText.Text = "Hello, " + userName;
                }
                else if (AxelaText.Contains("who is your developer"))
                {
                    AxelaResponseText.Text = "My developer is jpb, sometimes referred to as jpbandroid :D";
                }
                else if (AxelaText.Contains("bye"))
                {
                    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    AxelaResponseText.Text = "Bye! :D\nHave a nice day, " + userName;
                }
                else if (AxelaText.Contains("it's my birthday"))
                {
                    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    AxelaResponseText.Text = "Happy birthday, " + userName;
                }
                else if (AxelaText.Contains("what's the time"))
                {
                    AxelaResponseText.Text = "The time right now is: " + DateTime.Now.ToString();
                }
                else if (AxelaText.Contains("get")) {
                    if (AxelaText.Contains("from wikipedia"))
                    {
                        //string WikiArticle = string.Empty;
                        //AxelaText = WikiArticle;
                        //WikiArticle.Replace("get ", "");
                        //WikiArticle.Replace("from wikipedia", "");
                        //WebClient client = new WebClient();

                        //using (Stream stream = client.OpenRead("http://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&explaintext=1&titles=stack%20overflow"))
                        //using (StreamReader reader = new StreamReader(stream))
                        //{
                        //    JsonSerializer ser = new JsonSerializer();
                        //    Result result = ser.Deserialize<Result>(new JsonTextReader(reader));

                        //    foreach (Page page in result.query.pages.Values)
                        //        Console.WriteLine(page.extract);

                        //}

                        // This is the path for the "LocalState" folder.
                        string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                        Process P = new();
                        P.StartInfo.UseShellExecute = true;
                        P.StartInfo.Verb = "runas";
                        P.StartInfo.FileName = $@"{directory}\axela_wiki.exe";
                        P.StartInfo.Arguments = "";
                        P.Start();
                        AxelaResponseText.Text = "Please input any queries from Wikipedia into the textbox of the new app window";

                    }
                }
                else if (AxelaText.Contains("how are you"))
                {
                    AxelaResponseText.Text = "I'm great! :D\nBut I don't really have feelings, as I am an AI chatbot";
                }
                else if (AxelaText.Contains("axela, axela"))
                {
                    AxelaResponseText.Text = "Hey there, I see you're repeating my name...";
                }
                else if (AxelaText.Contains("cortana"))
                {
                    AxelaResponseText.Text = "...\ncoming soon\n...";
                }
                else
                {
                    AxelaResponseText.Text = "Sorry, I couldn't find any response to your command! :(\nMaybe update the app to its latest version and then try again?";
                }
            }
        }
    }

    public async void UserInit()
    {
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;


        //text1.Text = "Welcome, " + userName;
    }

    public class Result
    {
        public Query query
        {
            get; set;
        }
    }

    public class Query
    {
        public Dictionary<string, Page> pages
        {
            get; set;
        }
    }

    public class Page
    {
        public string extract
        {
            get; set;
        }
    }
}
