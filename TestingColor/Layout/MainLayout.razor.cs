using MudBlazor;

namespace TestingColor.Layout;

public partial class MainLayout
{
    private bool isDarkMode;
    private MudThemeProvider? mudThemeProvider;

    private readonly MudTheme myCustomTheme = new()
    {
        PaletteLight = new PaletteLight
        {
            Primary = Colors.Blue.Default,
            Secondary = Colors.Green.Accent4,
            AppbarBackground = Colors.Red.Default,
        },
        PaletteDark = new PaletteDark
        {
            Primary = Colors.Blue.Lighten1
        },
        LayoutProperties = new LayoutProperties
        {
            DrawerWidthLeft = "260px",
            DrawerWidthRight = "300px"
        }
    };

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender || mudThemeProvider is null)
        {
            return;
        }

        isDarkMode = await mudThemeProvider.GetSystemPreference();
        await mudThemeProvider.WatchSystemPreference(OnSystemPreferenceChanged);
        StateHasChanged();
    }

    private Task OnSystemPreferenceChanged(bool newValue)
    {
        isDarkMode = newValue;
        StateHasChanged();
        return Task.CompletedTask;
    }
}
