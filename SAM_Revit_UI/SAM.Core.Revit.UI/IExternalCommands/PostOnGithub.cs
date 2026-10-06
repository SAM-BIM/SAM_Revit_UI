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
    public class PostOnGithub : PushButtonExternalCommand
    {
        public override string RibbonPanelName => "General";

        public override int Index => 1;

        public override BitmapSource BitmapSource => Convert.ToBitmapSource(Resources.SAM_PostOnGitHub, 32, 32);

        public override string Text => "Post on\nGithub";

        public override string ToolTip => "Post On Github";

        public override string AvailabilityClassName => typeof(AlwaysAvailableExternalCommandAvailability).FullName;

        public override Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Query.StartProcess("https://github.com/SAM-BIM/SAM/issues/new/choose");

            return Result.Succeeded;
        }
    }
}
