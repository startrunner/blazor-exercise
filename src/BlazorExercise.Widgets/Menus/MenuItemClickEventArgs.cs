using Microsoft.AspNetCore.Components.Web;
namespace BlazorExercise.Widgets.Menus;

public sealed class MenuItemClickEventArgs : EventArgs
{
    public required MenuItem Sender { get; init; }
    public required MouseEventArgs MouseEventArgs { get; init; }
}