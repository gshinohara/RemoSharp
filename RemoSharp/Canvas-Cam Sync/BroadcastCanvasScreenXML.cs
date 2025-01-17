﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Drawing;
using System.IO;
using System.Threading;
using GHCustomControls;
using WPFNumericUpDown;
using Newtonsoft.Json;
using System.Linq;
using AdvancedStringBuilder;
using Grasshopper.Kernel.Data;
using System.Text;

namespace RemoSharp
{
    public class PanelContentRepo
    {
        public string guidString;
        public string content;
        public PanelContentRepo(string guidString, string content)
        {
            this.guidString = guidString;
            this.content = content;

        }
    }
    public class BroadcastCanvasScreenXML : GHCustomComponent
    {
        //PushButton setupButton;

        /// <summary>
        /// Initializes a new instance of the BroadcastCanvasScreenXML class.
        /// </summary>
        public BroadcastCanvasScreenXML()
          : base("BroadcastCanvasScreen", "BrdCstCanvas",
              "Broadcasts the extents of the grasshopper canvas as a Grasshopper document as an XML text representation.",
              "RemoSharp", "BroadcastTools")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            //setupButton = new PushButton("WS_Client",
            //       "Creates The Required WS Client Components To Broadcast Canvas Screen.", "WS_Client");
            //setupButton.OnValueChanged += SetupButton_OnValueChanged;
            //AddCustomControl(setupButton);

            //pManager.AddBooleanParameter("Broadcast", "BrdCst",
            //    "Creates and broadcasts the current GH_Canvas screenshot in a text format.",
            //    GH_ParamAccess.item, false);
            //pManager.AddTextParameter("ID", "ID", "PC Network ID", GH_ParamAccess.item, "1");

        }
        //private void CheckForDirectoryAndFileExistance(string path)
        //{
        //    bool directoryExists = Directory.Exists(Path.GetDirectoryName(path));
        //    bool fileExists = File.Exists(path);

        //    if (directoryExists && fileExists) return;

        //    if (!directoryExists) Directory.CreateDirectory(Path.GetDirectoryName(path));
        //    if (!fileExists)
        //    {
        //        using (var file = File.Create(path))
        //        {
        //            byte[] byteArray = Encoding.ASCII.GetBytes("First Line"); 
        //            file.Write(byteArray,0,0);
        //            file.Close();
        //        }
        //    }
        //}

        //private void SetupButton_OnValueChanged(object sender, ValueChangeEventArgumnet e)
        //{
        //    bool currentValue = Convert.ToBoolean(e.Value);
        //    if (currentValue)
        //    {

        //        System.Drawing.PointF pivot = this.Attributes.Pivot;
        //        //System.Drawing.PointF panelPivot = new System.Drawing.PointF(pivot.X - 404, pivot.Y -110);
        //        //System.Drawing.PointF IDpanelPivot = new System.Drawing.PointF(pivot.X - 404, pivot.Y -9);
        //        System.Drawing.PointF togglePivot = new System.Drawing.PointF(pivot.X - 231 , pivot.Y -140);
        //        System.Drawing.PointF buttnPivot = new System.Drawing.PointF(pivot.X - 230, pivot.Y - 62);
        //        System.Drawing.PointF wssPivot = new System.Drawing.PointF(pivot.X + 30, pivot.Y - 71);
        //        System.Drawing.PointF wsSendPivot = new System.Drawing.PointF(pivot.X + 180, pivot.Y - 10);
        //        System.Drawing.PointF triggerPivot = new System.Drawing.PointF(pivot.X - 330, pivot.Y - 175);  

        //        // run/notrun toggle
        //        Grasshopper.Kernel.Special.GH_BooleanToggle toggle = new Grasshopper.Kernel.Special.GH_BooleanToggle();
        //        toggle.CreateAttributes();
        //        toggle.Attributes.Pivot = togglePivot;
        //        toggle.NickName = "RemoSharp";

        //        //string address = "";
        //        //Grasshopper.Kernel.Special.GH_Panel panel = new Grasshopper.Kernel.Special.GH_Panel();
        //        //panel.CreateAttributes();
        //        //panel.Attributes.Pivot = panelPivot;
        //        //panel.Attributes.Bounds = new System.Drawing.RectangleF(panelPivot.X, panelPivot.Y, 300, 20);
        //        //panel.SetUserText(address);
        //        //panel.NickName = "RemoSharp Canvas Server";

        //        //string ID = "1";
        //        //Grasshopper.Kernel.Special.GH_Panel IDpanel = new Grasshopper.Kernel.Special.GH_Panel();
        //        //IDpanel.CreateAttributes();
        //        //IDpanel.Attributes.Pivot = IDpanelPivot;
        //        //IDpanel.Attributes.Bounds = new System.Drawing.RectangleF(IDpanelPivot.X, IDpanelPivot.Y, 300, 20);
        //        //IDpanel.SetUserText(ID);
        //        //IDpanel.NickName = "RemoSharp Collaborator ID";

        //        // sending wss button
        //        Grasshopper.Kernel.Special.GH_ButtonObject button = new Grasshopper.Kernel.Special.GH_ButtonObject();
        //        button.CreateAttributes();
        //        button.Attributes.Pivot = buttnPivot;
        //        button.NickName = "RemoSharp";

        //        // sending wss
        //        RemoSharp.WsClientCat.WsClientStart wss = new WsClientCat.WsClientStart();
        //        wss.CreateAttributes();
        //        wss.Attributes.Pivot = wssPivot;
        //        wss.Params.RepairParamAssociations();

        //        // send component
        //        RemoSharp.WsClientCat.WsClientSend wsSend = new WsClientCat.WsClientSend();
        //        wsSend.CreateAttributes();
        //        wsSend.Attributes.Pivot = wsSendPivot;
        //        wsSend.Params.RepairParamAssociations();

        //        // trigger
        //        Grasshopper.Kernel.Special.GH_Timer trigger = new Grasshopper.Kernel.Special.GH_Timer();
        //        trigger.CreateAttributes();
        //        trigger.Attributes.Pivot = triggerPivot;
        //        trigger.NickName = "RemoSharp";
        //        trigger.Interval = 100;
        //        var guid = this.InstanceGuid;


        //        var addressOutPuts = RemoSharp.RemoCommandTypes.Utilites.CreateServerMakerComponent(this.OnPingDocument(), pivot, -350, -38, false);


        //        this.OnPingDocument().ScheduleSolution(1, doc =>
        //        {
        //            //this.OnPingDocument().AddObject(panel, true);
        //            //this.OnPingDocument().AddObject(IDpanel, true);
        //            this.OnPingDocument().AddObject(toggle, true);
        //            this.OnPingDocument().AddObject(button, true);
        //            this.OnPingDocument().AddObject(wss, true);
        //            this.OnPingDocument().AddObject(wsSend, true);

        //            this.OnPingDocument().AddObject(trigger, true);

        //            //if(!address.Equals("")) wss.Params.Input[0].AddSource((IGH_Param)panel);
        //            wss.Params.Input[0].AddSource(addressOutPuts[0]);
        //            wss.Params.Input[2].AddSource((IGH_Param)button);
        //            wsSend.Params.Input[0].AddSource((IGH_Param)wss.Params.Output[0]);

        //            this.Params.Input[0].AddSource((IGH_Param)toggle);
        //            this.Params.Input[1].AddSource(addressOutPuts[4]);

        //            trigger.AddTarget(guid);
        //        });


        //        string commandAddressString = "";
        //        CreateWebSocketClientComponents(pivot, 7, 94, commandAddressString, false, addressOutPuts[2], addressOutPuts[3]);

        //        string commandAddressString2 = "";
        //        CreateWebSocketClientComponents(pivot, 7, 189, commandAddressString2, true, addressOutPuts[2], addressOutPuts[3]);

        //    }
        //}


        //private void CreateWebSocketClientComponents(System.Drawing.PointF pivot, int shiftX, int shiftY, string address, bool IsCameraSync, IGH_Param commandServer, IGH_Param cameraServer)
        //{
        //    //System.Drawing.PointF panelPivot = new System.Drawing.PointF(pivot.X - 350 + shiftX, pivot.Y - 109 + shiftY - 15);
        //    //System.Drawing.PointF panelPivot2 = new System.Drawing.PointF(pivot.X - 670 + shiftX, pivot.Y - 29 + shiftY - 15);
        //    System.Drawing.PointF buttnPivot2 = new System.Drawing.PointF(pivot.X - 500 + shiftX, pivot.Y + 19 + shiftY - 15);
        //    System.Drawing.PointF wssPivot2 = new System.Drawing.PointF(pivot.X - 290 + shiftX, pivot.Y + 10 + shiftY - 15);
        //    System.Drawing.PointF wsRecvPivot = new System.Drawing.PointF(pivot.X - 160 + shiftX, pivot.Y + 20 + shiftY - 15);
        //    int slightShiftup = IsCameraSync ? -35 : -25;
        //    System.Drawing.PointF commandReceiver = new System.Drawing.PointF(pivot.X - 0 + shiftX, pivot.Y + 20 + shiftY + slightShiftup);


        //    //Grasshopper.Kernel.Special.GH_Panel panel2 = new Grasshopper.Kernel.Special.GH_Panel();
        //    //panel2.CreateAttributes();
        //    //panel2.Attributes.Pivot = panelPivot2;
        //    //panel2.Attributes.Bounds = new System.Drawing.RectangleF(panelPivot.X, panelPivot.Y, 300, 20);
        //    //panel2.SetUserText(address);
        //    //panel2.NickName = IsCameraSync ? "RemoSharp Camera Server" : "RemoSharp Command Server";

        //    // receiving wss button
        //    Grasshopper.Kernel.Special.GH_ButtonObject button2 = new Grasshopper.Kernel.Special.GH_ButtonObject();
        //    button2.CreateAttributes();
        //    button2.Attributes.Pivot = buttnPivot2;
        //    button2.NickName = "RemoSharp";

        //    // receiving wss
        //    RemoSharp.WsClientCat.WsClientStart wss2 = new WsClientCat.WsClientStart();
        //    wss2.CreateAttributes();
        //    wss2.Attributes.Pivot = wssPivot2;
        //    wss2.Params.RepairParamAssociations();

        //    // send component
        //    RemoSharp.WsClientCat.WsClientRecv wsRecv = new WsClientCat.WsClientRecv();
        //    wsRecv.CreateAttributes();
        //    wsRecv.Attributes.Pivot = wsRecvPivot;
        //    wsRecv.Params.RepairParamAssociations();

        //    //if (!address.Equals("")) wss2.Params.Input[0].AddSource((IGH_Param)panel2);
        //    wss2.Params.Input[2].AddSource((IGH_Param)button2);
        //    wsRecv.Params.Input[0].AddSource((IGH_Param)wss2.Params.Output[0]);

        //    if (IsCameraSync)
        //    {
        //        System.Drawing.PointF togglePivot = new System.Drawing.PointF(pivot.X - 225, pivot.Y + 231);
        //        // run/notrun toggle
        //        Grasshopper.Kernel.Special.GH_BooleanToggle toggle = new Grasshopper.Kernel.Special.GH_BooleanToggle();
        //        toggle.CreateAttributes();
        //        toggle.Attributes.Pivot = togglePivot;
        //        toggle.NickName = "RemoSharp";

        //        this.OnPingDocument().AddObject(wss2, true);
        //        this.OnPingDocument().AddObject(wsRecv, true);
        //        //this.OnPingDocument().AddObject(panel2, true);
        //        this.OnPingDocument().AddObject(button2, true);
        //        this.OnPingDocument().AddObject(toggle, true);

        //        RemoSharp.SyncCamera syncCamera = new RemoSharp.SyncCamera();
        //        syncCamera.CreateAttributes();
        //        syncCamera.Attributes.Pivot = commandReceiver;
        //        syncCamera.Params.RepairParamAssociations();

        //        this.OnPingDocument().ScheduleSolution(1, doc =>
        //        {
        //            this.OnPingDocument().AddObject(syncCamera, true);

        //            //if (!address.Equals("")) wss2.Params.Input[0].AddSource((IGH_Param)panel2);
        //            wss2.Params.Input[0].AddSource(cameraServer);
        //            wss2.Params.Input[2].AddSource((IGH_Param)button2);
        //            wsRecv.Params.Input[0].AddSource((IGH_Param)wss2.Params.Output[0]);
        //            syncCamera.Params.Input[0].AddSource((IGH_Param)toggle);
        //        });

        //    }
        //    else
        //    {
        //        this.OnPingDocument().AddObject(wss2, true);
        //        this.OnPingDocument().AddObject(wsRecv, true);
        //        //this.OnPingDocument().AddObject(panel2, true);
        //        this.OnPingDocument().AddObject(button2, true);

        //        RemoSharp.CommandExecutor remoCommands = new RemoSharp.CommandExecutor();
        //        remoCommands.CreateAttributes();
        //        remoCommands.Attributes.Pivot = commandReceiver;
        //        remoCommands.Params.RepairParamAssociations();

        //        this.OnPingDocument().ScheduleSolution(1, doc =>
        //        {
        //            this.OnPingDocument().AddObject(remoCommands, true);

        //            //if (!address.Equals("")) wss2.Params.Input[0].AddSource((IGH_Param)panel2);
        //            wss2.Params.Input[0].AddSource(commandServer);
        //            wss2.Params.Input[2].AddSource((IGH_Param)button2);
        //            wsRecv.Params.Input[0].AddSource((IGH_Param)wss2.Params.Output[0]);
        //            //remoCommands.Params.Input[0].AddSource((IGH_Param)wsRecv.Params.Output[0]);
        //        });

        //    }
        //}

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("CanvasScreenshot", "screenshot", "A text based representation of the current GH_Canvas screenshot",
                GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //bool run = false;
            //string ID = "";
            //DA.GetData(0, ref run);
            //DA.GetData(1, ref ID);

            //if (!run) return;
            //string savePath = @"C:\temp\RemoSharp\saveTempFile.ghx";
            //string openPath = @"C:\temp\RemoSharp\openTempFile" + ID + ".ghx";
            //string finalPath = @"C:\temp\RemoSharp\finalTempFile" + ID + ".ghx";

            //CheckForDirectoryAndFileExistance(savePath);
            //CheckForDirectoryAndFileExistance(openPath);
            //CheckForDirectoryAndFileExistance(finalPath);



            //var panelContents = new List<PanelContentRepo>();
            //foreach (var obj in this.OnPingDocument().Objects)
            //{
            //    if (obj.GetType().ToString().Equals("Grasshopper.Kernel.Special.GH_Panel") &&
            //       !obj.NickName.Contains("RemoSharp"))
            //    {
            //        //var panel = (Grasshopper.Kernel.Special.GH_Panel)obj;
            //        //var panelGuid = panel.InstanceGuid.ToString();


            //        //string panelLiveContent = GetLivePanelContent(panel);
            //        //panel.SetUserText(panelLiveContent);
            //        //panelContents.Add(new PanelContentRepo(panelGuid, panelLiveContent));
            //        //string tempStreamPath = @"C:\temp\RemoSharp\" + panelGuid + ".ghx";
            //        //CheckForDirectoryAndFileExistance(tempStreamPath);

            //        //using (StreamWriter sw = new StreamWriter(tempStreamPath))
            //        //{
            //        //    sw.Write();
            //        //}

            //    }
            //}
            //Grasshopper.Kernel.GH_DocumentIO saveDoc = new GH_DocumentIO(this.OnPingDocument());
            //bool saveDocR = saveDoc.SaveQuiet(savePath);

            //while (true)
            //{
            //    try
            //    {
            //        System.IO.File.Copy(savePath, openPath, true);
            //        break;
            //    }
            //    catch { }
            //}

            ////Grasshopper.Kernel.GH_DocumentIO openDoc = new GH_DocumentIO();
            ////openDoc.Open(openPath);
            ////var bounds = new VisibleBounds(coords);
            ////foreach (var obj in openDoc.Document.Objects.Reverse())
            ////{
            ////    string type = obj.GetType().ToString();
            ////    var objPivot = obj.Attributes.Pivot;
            ////    bool outside = false;
            ////    bool isFromRemoSharp = type.Contains("RemoSharp");
            ////    bool remosharpNickname = obj.NickName.Contains("RemoSharp");
            ////    if (
            ////      (int)objPivot.X < bounds.topLeftCornerX ||
            ////      (int)objPivot.Y < bounds.topLeftCornerY ||
            ////      (int)objPivot.X > bounds.topLeftCornerX + bounds.visibleAreaWidth ||
            ////      (int)objPivot.Y > bounds.topLeftCornerY + bounds.visibleAreaHeight) outside = true;
            ////    if (isFromRemoSharp || outside || remosharpNickname)
            ////    {
            ////        openDoc.Document.RemoveObject(obj, false);
            ////    }
            ////    if (!outside)
            ////    {
            ////        if (obj.GetType().ToString().Equals("Grasshopper.Kernel.Special.GH_Panel"))
            ////        {
            ////            Grasshopper.Kernel.Special.GH_Panel panel = (Grasshopper.Kernel.Special.GH_Panel)obj;
            ////            if (panel.NickName.Contains("RemoSharp")) continue;
            ////            panel.Properties.Colour = Color.Transparent;
            ////            openDoc.Document.ArrangeObject(panel, GH_Arrange.MoveToBack);
            ////            var panelPivot = panel.Attributes.Pivot;
            ////            var newPivot = new System.Drawing.PointF(panelPivot.X + 10, panelPivot.Y);
            ////            Grasshopper.Kernel.Special.GH_Panel newPanel = new Grasshopper.Kernel.Special.GH_Panel();
            ////            newPanel.CreateAttributes();
            ////            newPanel.Attributes.Pivot = newPivot;
            ////            string newPanelContent = BackgoundDocumentPanelContent(panel, panelContents);
            ////            newPanel.SetUserText(newPanelContent);
            ////            newPanel.ExpireSolution(true);
            ////            newPanel.Properties.Alignment = Grasshopper.Kernel.Special.GH_Panel.Alignment.Left;
            ////            newPanel.Attributes.Bounds = panel.Attributes.Bounds;
            ////            //newPanel.Properties.Multiline = false;
            ////            openDoc.Document.AddObject(newPanel, false, openDoc.Document.ObjectCount - 1);

            ////            openDoc.Document.ArrangeObject(newPanel, GH_Arrange.MoveToFront);
            ////            //openDoc.Document.ScheduleSolution(0, (GH_Document doc) => 
            ////            //{
            ////            //});
            ////            ////panel.StreamCurrentContent()
            ////            ////foreach (var source in panel.Sources)
            ////            ////{
            ////            ////    var data = so;
            ////            ////}
            ////        }
            ////    }
            ////}
            ////openDoc.SaveQuiet(savePath);

            //try
            //{
            //    string content = "";
            //    using (StreamReader sr = new StreamReader(finalPath))
            //    {
            //        content = sr.ReadToEnd();
            //        sr.Close();
            //        //WebMarkupMin.Core.XmlMinifier minifier = new XmlMinifier();
            //        //MarkupMinificationResult result = minifier.Minify(content, false);
            //        //content = result.MinifiedContent;
            //    }
            //    if (content.Length < 150000)
            //    {
            //        if(!string.IsNullOrEmpty(content)) DA.SetData(0, content);
            //    }
            //    else
            //    {
            //        this.AddRuntimeMessage(GH_RuntimeMessageLevel.Remark, "Broadcasting region too large");
            //    }
            //}
            //catch { }
        }

        //string GetLivePanelContent(Grasshopper.Kernel.Special.GH_Panel panel)
        //{

        //    var e = panel.VolatileData;
        //    string content = "";
        //    for (int i = 0; i < e.Paths.Count; i++)
        //    {
        //        var currPath = e.Paths[i];
        //        content += "Branch: " + currPath.ToString(true) + Environment.NewLine;
        //        int index = 0;
        //        foreach (object o in e.get_Branch(currPath))
        //        {
        //            content += "   " + index + "| " + o.ToString() + Environment.NewLine;
        //            index++;
        //        }
        //    }

        //    return content;
        //}

        //string BackgoundDocumentPanelContent(Grasshopper.Kernel.Special.GH_Panel panel, List<PanelContentRepo> panelContents)
        //{


        //    string content = "";

        //    foreach (PanelContentRepo panelContentRepo in panelContents)
        //    {
        //        if(panel.InstanceGuid.ToString() == panelContentRepo.guidString)
        //        {
        //            content = panelContentRepo.content;
        //        }
        //    }
        //    ////for (int i = 0; i < e.Paths.Count; i++)
        //    ////{
        //    ////    var currPath = e.Paths[i];
        //    ////    content += "Branch: " + currPath.ToString(true) + Environment.NewLine;
        //    ////    int index = 0;
        //    ////    foreach (object o in e.get_Branch(currPath))
        //    ////    {
        //    ////        content += index + "| " + o.ToString() + Environment.NewLine;
        //    ////        index++;
        //    ////    }
        //    ////}
        //    //var panelGuid = panel.InstanceGuid.ToString().Substring(0, 15);
        //    //string tempStreamPath = @"C:\temp\RemoSharp\" + panelGuid + ".ghx";
        //    //CheckForDirectoryAndFileExistance(tempStreamPath);

        //    //string content = "";
        //    ////try
        //    ////{
        //    ////    using (StreamReader sr = new StreamReader(tempStreamPath))
        //    ////    {
        //    ////        content = sr.ReadToEnd();
        //    ////    }
        //    ////}
        //    ////catch { }

        //    return content;
        //}

        private class VisibleBounds
        {
            public int topLeftCornerX;
            public int topLeftCornerY;
            public int visibleAreaWidth;
            public int visibleAreaHeight;

            public VisibleBounds(string coordinatesCSV)
            {
                string[] csv = coordinatesCSV.Split(',');
                double topLeftCornerX = Convert.ToDouble(csv[0]);
                double topLeftCornerY = Convert.ToDouble(csv[1]);
                double visibleAreaWidth = Convert.ToDouble(csv[2]);
                double visibleAreaHeight = Convert.ToDouble(csv[3]);

                this.topLeftCornerX = (int)topLeftCornerX;
                this.topLeftCornerY = (int)topLeftCornerY;
                this.visibleAreaWidth = (int)visibleAreaWidth;
                this.visibleAreaHeight = (int)visibleAreaHeight;
            }
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
                return RemoSharp.Properties.Resources.BroadcastCanvas.ToBitmap();
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("EF3EC033-ACFF-44AA-8749-4655BC50E498"); }
        }
    }
}