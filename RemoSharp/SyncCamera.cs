﻿using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

using Rhino;

using Grasshopper;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

using System.Linq;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Parameters.Hints;
using Grasshopper.Kernel.Special;
using ScriptComponents;

namespace RemoSharp
{
    public class SyncCamera : GH_Component
    {
        IGH_Component Component;
        Rhino.RhinoDoc rhinoDoc;
        /// <summary>
        /// Initializes a new instance of the SyncCamera class.
        /// </summary>
        public SyncCamera()
          : base("SyncCamera", "SyncCam",
              "Syncs a viewport based on the string input",
              "RemoSharp", "CameraTools")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Update", "update", "Update the target viewport camera", GH_ParamAccess.item, false);
            pManager.AddTextParameter("TargetCamera", "TgtCam", "A string containing the info about the target viewport camera", GH_ParamAccess.item, "");
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("State","state", "Result of Camera Sync", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            Component = this;
            Rhino.RhinoDoc rhinoDoc = Rhino.RhinoDoc.ActiveDoc;

            bool update = false;
            string TargetCamera = "";

            // defining the output
            string state = "";

            DA.GetData(0, ref update);
            DA.GetData(1, ref TargetCamera);

            if (!update)
            {
                return;
            }
            try
            {
                string camName;
                int projectionMode = 1;
                double[] camPose = ParseCameraPose(TargetCamera, out camName, out projectionMode);
                Point3d camPos = new Point3d(camPose[0], camPose[1], camPose[2]);
                Vector3d camDir = new Vector3d(camPose[3], camPose[4], camPose[5]);
                double focalLength = camPose[6];
                int tgtIndex = -1;
                var camera = rhinoDoc.Views.GetViewList(true, false);
                for (int i = 0; i < camera.Length; i++)
                {
                    var tempView = camera[i];
                    string viewName = tempView.ActiveViewport.Name;
                    if (viewName == camName)
                    {
                        tgtIndex = i;
                    }
                }

                try
                {
                    var checkCam = camera[tgtIndex];
                }
                catch
                {
                    state = "Target Viewport Is Invalid!";
                    if (tgtIndex == -1) {
                        this.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Target Viewport Does Not Exist!");
                    }
                    return;
                }
                var tgtCam = camera[tgtIndex];
                if (update)
                {
                    tgtCam.ActiveViewport.Camera35mmLensLength = focalLength;
                    tgtCam.ActiveViewport.SetCameraLocation(camPos, true);
                    tgtCam.ActiveViewport.SetCameraDirection(camDir, false);

                    // setting the projection Mode
                    if (projectionMode == 0) { tgtCam.ActiveViewport.ChangeToParallelProjection(true); }
                    else if (projectionMode == 1) { tgtCam.ActiveViewport.ChangeToPerspectiveProjection(true, focalLength); }
                    else if (projectionMode == 2) {
                        this.Component.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Plan View Not Yet Implemented.");
                        /*tgtCam.ActiveViewport.SetToPlanView(camPos, Vector3d.XAxis, Vector3d.YAxis, false);*/ }
                    else if (projectionMode == 3) {
                        this.Component.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "TwoPointPerspective View Not Yet Implemented.");
                        /*tgtCam.ActiveViewport.ChangeToTwoPointPerspectiveProjection(focalLength);*/ }
                    else { tgtCam.ActiveViewport.ChangeToPerspectiveProjection(true, focalLength); }

                    state = "Camera Location Being Updated!";
                }
            }
            catch
            {
                state = "Viewport Camera Pose Input Is Invalid!";
            }

            DA.SetData(0, state);
        }

        public double[] ParseCameraPose(string targetCamPose, out string camName, out int cameraType)
        {
            double[] camPose = new double[8];
            string[] poseString = targetCamPose.Split(',');
            for (int i = 1; i < camPose.Length + 1; i++)
            {
                camPose[i - 1] = Convert.ToDouble(poseString[i]);
            }
            camName = poseString[0];
            cameraType = Convert.ToInt32(camPose[7]);
            return camPose;
        }
        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return RemoSharp.Properties.Resources.Sync_Camera.ToBitmap();
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("42d07ca6-73ab-49bc-a4ee-def3541a3394"); }
        }
    }
}