//using CStackLayout = Microsoft.Maui.Controls.StackLayout;
using CStackLayout=Microsoft.Maui.Controls.Compatibility.StackLayout;

namespace MauiApp1
{

    public class MainPage : ContentPage
    {
        CollectionView m_Collection;
        CStackLayout m_MainSubView;
        CStackLayout m_SearchView;
        Button m_Button;
        CStackLayout m_MainView;

        public MainPage()
        {
            m_Collection = new CollectionView
            {
                ItemsSource = new List<string>() { "aaa", "bb", "c" }
            };

            m_SearchView = new CStackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = 
                { 
                    new Label { Text="Items" }
                }
            };

            m_MainSubView = new CStackLayout
            {
                Children = { m_SearchView, m_Collection }
            };

            m_Button = new Button { Text = "Update", Command = new Command(OnUpdate) };
            m_MainView = new CStackLayout();
            AddContentNow();
            Content = m_MainView;
        }

        void AddContentNow()
        {
            m_MainView.Children.Add(m_MainSubView);
            m_MainView.Children.Add(m_Button);
        }

        void OnUpdate()
        {
#if ANDROID // Workaround for System.ObjectDisposedException: 'Cannot access a disposed object. Object name: 'Microsoft.Maui.Controls.Compatibility.Platform.Android.Platform+DefaultRenderer'.'
            m_SearchView.Handler.DisconnectHandler();
            m_MainSubView.Handler.DisconnectHandler();
#endif

#if IOS // Workaround for System.ArgumentNullException: 'Value cannot be null. (Parameter 'view')' ???
#endif

            m_MainView.Children.Clear();
            AddContentNow();
        }

    }
}