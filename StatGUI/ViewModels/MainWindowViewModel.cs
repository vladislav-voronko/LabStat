using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatGUI.ViewModels
{
    public class MainWindowViewModel
    {
        public OptionViewModel OptionViewModel { get; set; }

        public MainWindowViewModel()
        {
            OptionViewModel = new OptionViewModel();
        }
    }
}
