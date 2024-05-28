
//using CStackLayout = Microsoft.Maui.Controls.StackLayout;
using CStackLayout=Microsoft.Maui.Controls.Compatibility.StackLayout;

namespace MauiApp1
{

    public class MainPage : ContentPage
    {
        View m_Collection;
        Button m_Button;
        CStackLayout m_MainView;

        public MainPage()
        {
            m_Collection = new CollectionView
            {
                ItemsSource = new List<string>() { "aaa", "bbb", "ccc" },
            };

            m_Button = new Button { Text = "Update", Command = new Command(OnUpdate) };
            m_MainView = new CStackLayout();
            AddContentNow();
            Content = m_MainView;
        }

        void AddContentNow()
        {
            m_MainView.Children.Add(m_Collection);
            m_MainView.Children.Add(m_Button);
        }

        void OnUpdate()
        {
            m_MainView.Children.Clear();
            AddContentNow();
        }

    }
}