using CommunityToolkit.Maui.Markup;

namespace MauiApp1
{
    public class TestPage : ContentPage
    {
        int count = 0;

        public TestPage()
        {
            Title = "Test Page";
            var scollView = new ScrollView();
            var verticalStackLayout = new VerticalStackLayout
            {
                Spacing = 25,
                Children =
                {
                    new Label
                    {
                        Text = "Hello, World from C# markup! (TEST)"
                    }
                    .Font(size: 32)
                    .CenterHorizontal(),

                    new Label
                    {
                        Text = "Testing C# markup"
                    }
                    .Font(size: 18)
                    .CenterHorizontal(),

                    new Label
                    {
                        Text = "Current count: 0",
                    }
                    .Font(size: 12)
                    .CenterHorizontal()
                    .Assign(out Label countLabel),

                    new Button
                    {
                        Text = "Click"
                    }
                    .Font(bold: true)
                    .CenterHorizontal()
                    .Invoke(b => b.Clicked += (sender,e) =>
                    {
                        count++;
                        countLabel.Text = $"Current count: {count}";

                        SemanticScreenReader.Announce(countLabel.Text);
                    }),

                    new Image
                    {
                        Source = new FileImageSource
                        {
                            File = "logo.png"
                        },
                        WidthRequest = 250,
                        HeightRequest = 250
                    }
                    .CenterHorizontal()
                }
            }
            .Padding(new Thickness(30));

            scollView.Content = verticalStackLayout;

            Content = scollView;
        }
    }
}
