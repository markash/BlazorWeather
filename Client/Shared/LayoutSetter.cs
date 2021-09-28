using System;
using Microsoft.AspNetCore.Components;

namespace Client.Shared
{
    public class LayoutSetter : ComponentBase
    {
        [CascadingParameter]
        public MainLayout Layout { get; set; }

        [Parameter]
        public RenderFragment AppContextMenu { get; set; }

        protected override void OnInitialized()
        {
            Layout.SetAppContextMenu(AppContextMenu);
        }
    }
}