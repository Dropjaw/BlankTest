using System.Windows;
using BlankTest.Core.MatchRules;

namespace BlankTest.App;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var viewModel = new MatchRulesViewModel(new SampleMatchRulesService(), new NullMatchRuleNavigationService(), new NullMatchRuleExportService());
        DataContext = viewModel;
        Loaded += (_, _) => viewModel.LoadCommand.Execute(null);
    }
}
