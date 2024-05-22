
//using CStackLayout = Microsoft.Maui.Controls.StackLayout;
using CStackLayout=Microsoft.Maui.Controls.Compatibility.StackLayout;

namespace MauiApp1
{

    public class MainPage : ContentPage
    {
        CStackLayout m_ContentStack= new CStackLayout();
        Label m_LabelA = new Label { Text = "some Text A" };
        Label m_LabelB = new Label { Text = "some Text B" };
        Button m_Button;
        CStackLayout m_MainView;

        public MainPage()
        {
            m_ContentStack.Children.Add(m_LabelA);
            m_ContentStack.Children.Add(m_LabelB);

            m_Button = new Button { Text = "Update", Command = new Command(OnUpdate) };
            m_MainView = new CStackLayout();
            AddContentNow();
            Content = m_MainView;
        }

        void AddContentNow()
        {
            m_MainView.Children.Add(m_ContentStack);
            m_MainView.Children.Add(m_Button);
        }

        void OnUpdate()
        {
            m_MainView.Children.Clear();
            AddContentNow();
        }

    }
}