using System.Windows;
using eConcierge.Foundation.Applications.Views;
using eConcierge.Foundation.Presenters;
using eConcierge.Foundation.Views;

namespace eConcierge.Foundation.Applications.Presenters
{
    public abstract class ABaseToolPresenter : APresenter
    {
        protected ABaseToolPresenter(IBaseToolView view, string title, string description, IView body)
            : base(view)
        {
            Title = title;
            Description = description;
            body.Presenter = this;
            Body = body;
        }




        public Visibility DescriptionVisibility
        {
            get { return (Visibility)GetValue(DescriptionVisibilityProperty); }
            set { SetValue(DescriptionVisibilityProperty, value); }
        }

        public static readonly DependencyProperty DescriptionVisibilityProperty =
            DependencyProperty.Register("DescriptionVisibility", typeof(Visibility), typeof(ABaseToolPresenter), new UIPropertyMetadata(Visibility.Visible));



        public Visibility TitleVisibility
        {
            get { return (Visibility)GetValue(TitleVisibilityProperty); }
            set { SetValue(TitleVisibilityProperty, value); }
        }

        public static readonly DependencyProperty TitleVisibilityProperty =
            DependencyProperty.Register("TitleVisibility", typeof(Visibility), typeof(ABaseToolPresenter), new UIPropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title",
            typeof(string),
            typeof(ABaseToolPresenter));
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }
        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
            "Description",
            typeof(string),
            typeof(ABaseToolPresenter));
        public string Description
        {
            get
            {
                return (string)GetValue(DescriptionProperty);
            }
            set
            {
                SetValue(DescriptionProperty, value);
            }
        }

        public static readonly DependencyProperty BodyProperty = DependencyProperty.Register(
            "Body",
            typeof(IView),
            typeof(ABaseToolPresenter));
        public IView Body
        {
            get
            {
                return (IView)GetValue(BodyProperty);
            }
            set
            {
                SetValue(BodyProperty, value);
            }
        }

    }
}
