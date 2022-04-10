using System.Windows.Controls;

namespace Tome.View.ViewModel
{
    public class SubItem
    {
        public SubItem(string name, UserControl screen = null)
        {
            Name = name;
            Screen = screen;
        }
        public string Name { get; private set; }
        public UserControl Screen { get; private set; }
    }
}
