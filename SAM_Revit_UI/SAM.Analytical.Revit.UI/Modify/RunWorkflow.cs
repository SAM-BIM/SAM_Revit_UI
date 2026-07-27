// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020-2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using SAM.Analytical.Tas;
using SAM.Core.Windows.Forms;
using System.Threading;

namespace SAM.Analytical.Revit.UI
{
    public static partial class Modify
    {
        /// <summary>
        /// Runs the TAS workflow with a progress dialog that carries a Cancel button, for the Revit
        /// <see cref="Simulate"/> command. Cancellation is cooperative and between-step (see
        /// <see cref="WorkflowCalculator.CancellationToken"/>): it aborts before the next step but cannot
        /// interrupt the in-flight TAS COM simulate/sizing call.
        /// <para>
        /// The dialog runs on its own UI thread (<see cref="ProgressFormHost"/>) rather than on Revit's. The
        /// workflow blocks the calling thread for minutes at a time, and Windows ghosts a window whose thread
        /// has stopped pumping and then discards clicks on the ghost — so a Cancel button on Revit's own thread
        /// silently loses the click and the run carries on to completion. The job itself stays on the calling
        /// thread, so no TAS COM object changes apartment and no Revit API call moves off the API thread.
        /// </para>
        /// <para>
        /// This deliberately mirrors <c>SAM.Analytical.Grasshopper.Tas.Modify.RunWorkflow</c> rather than
        /// sharing it: that lives in a Grasshopper assembly, and the only sensible common home would be
        /// <c>SAM.Analytical.Tas</c>, which is kept free of any WinForms dependency. The part that would
        /// actually drift — the note wording and the list of uninterruptible stages — IS shared, through
        /// <see cref="Query.CancelNote"/>.
        /// </para>
        /// On cancellation the method returns null and sets <paramref name="cancelled"/> true; on any other
        /// failure it returns null with <paramref name="cancelled"/> false.
        /// </summary>
        /// <param name="externalCancellationToken">
        /// Lets the caller share one cancel across its own COM pre-step and this one, so a single Cancel click
        /// aborts either.
        /// </param>
        public static AnalyticalModel RunWorkflow(this AnalyticalModel analyticalModel, WorkflowSettings workflowSettings, CancellationToken externalCancellationToken, out bool cancelled)
        {
            cancelled = false;

            if (analyticalModel == null)
            {
                return null;
            }

            if (workflowSettings == null)
            {
                workflowSettings = new WorkflowSettings();
            }

            AnalyticalModel result = analyticalModel;

            using (CancellationTokenSource cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(externalCancellationToken))
            using (ProgressFormHost progressFormHost = new ProgressFormHost("Tas Workflow", 1, true, Analytical.Tas.Query.CancelNote(null)))
            {
                progressFormHost.CancelRequested += (s, e) => cancellationTokenSource.Cancel();

                WorkflowCalculator workflowCalculator = new WorkflowCalculator(workflowSettings)
                {
                    CancellationToken = cancellationTokenSource.Token
                };

                workflowCalculator.StepsCounted += (s, e) =>
                {
                    progressFormHost.Max = e.Count;
                };

                workflowCalculator.Updating += (s, e) =>
                {
                    progressFormHost.Note = Analytical.Tas.Query.CancelNote(e.Description);
                    progressFormHost.Update(e.Description);
                };

                try
                {
                    result = workflowCalculator.Calculate(analyticalModel);

                    // WorkflowCalculator observes the token before each stage and again before it returns, so a
                    // cancel during the last stage is caught there. This closes the remaining sliver: a click
                    // landing between that final check and Calculate handing back would otherwise leave
                    // cancelled false, and Simulate would go on to write results into the Revit document after
                    // the user asked it to stop.
                    cancellationTokenSource.Token.ThrowIfCancellationRequested();
                }
                catch (System.OperationCanceledException)
                {
                    cancelled = true;
                    result = null;
                }
            }

            return result;
        }
    }
}
