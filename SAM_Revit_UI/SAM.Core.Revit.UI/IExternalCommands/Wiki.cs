// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using SAM.Core.Revit.UI.Properties;
using System.Windows.Media.Imaging;

namespace SAM.Core.Revit.UI
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Wiki : PushButtonExternalCommand
    {
        public override string RibbonPanelName => "General";

        public override int Index => 0;

        public override BitmapSource BitmapSource => Convert.ToBitmapSource(Resources.SAM_Small);

        public override string Text => "Info";

        public override string ToolTip => "Info";

        public override string AvailabilityClassName => typeof(AlwaysAvailableExternalCommandAvailability).FullName;

        public override Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Query.StartProcess("https://github.com/SAM-BIM/SAM/wiki/00-Home");

            return Result.Succeeded;
        }
    }
}
