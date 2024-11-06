using CustomControls;
using CommonWinFormsFunctions;

namespace _2DLevelCreator
{
    partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            tsbTexCoordEditor = new System.Windows.Forms.ToolStripButton();
            tsbVertexEditor = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            tsbPlanarMapObjectSpace = new System.Windows.Forms.ToolStripButton();
            tsbPlanarMapWorldSpace = new System.Windows.Forms.ToolStripButton();
            tsbMatchAlignment = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            tscbSelection = new System.Windows.Forms.ToolStripComboBox();
            toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            lblSegment = new System.Windows.Forms.ToolStripLabel();
            txtSegmentIndex = new System.Windows.Forms.ToolStripTextBox();
            tsbNewSegment = new System.Windows.Forms.ToolStripButton();
            tsbDeleteSegment = new System.Windows.Forms.ToolStripButton();
            tsbAddToSegment = new System.Windows.Forms.ToolStripButton();
            tsbRemoveFromSegment = new System.Windows.Forms.ToolStripButton();
            tsbLinkSegments = new System.Windows.Forms.ToolStripButton();
            tsbInspectSegment = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            tsbPlay = new System.Windows.Forms.ToolStripButton();
            tsbRigidBodyEditor = new System.Windows.Forms.ToolStripButton();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            tsmLoad = new System.Windows.Forms.ToolStripMenuItem();
            tsmiLoadSegmentFile = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            tsmSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            tsmiSaveSegmentFile = new System.Windows.Forms.ToolStripMenuItem();
            tsmiSaveMaterials = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            expLeftSidebar = new ExpanderRight();
            flpLeftSidebar = new System.Windows.Forms.FlowLayoutPanel();
            expDebugging = new ExpanderDown();
            groupBox3 = new System.Windows.Forms.GroupBox();
            pnlShow = new System.Windows.Forms.Panel();
            chkSegmentMode = new System.Windows.Forms.CheckBox();
            chkShowAABBsNS = new System.Windows.Forms.CheckBox();
            chkShowAABBsS = new System.Windows.Forms.CheckBox();
            chkShowRigidbodies = new System.Windows.Forms.CheckBox();
            chkShowThings = new System.Windows.Forms.CheckBox();
            expManipulation = new ExpanderDown();
            groupBox2 = new System.Windows.Forms.GroupBox();
            pnlManiplutationTools3 = new System.Windows.Forms.Panel();
            chkAsAGroup = new System.Windows.Forms.CheckBox();
            txtPivotRotation = new System.Windows.Forms.TextBox();
            pnlManiplutationTools = new System.Windows.Forms.Panel();
            txtGridSnapMove = new System.Windows.Forms.TextBox();
            rdoNone = new System.Windows.Forms.RadioButton();
            chkGridSnapScale = new System.Windows.Forms.CheckBox();
            rdoScaleTool = new System.Windows.Forms.RadioButton();
            rdoRotateTool = new System.Windows.Forms.RadioButton();
            chkGridSnapMove = new System.Windows.Forms.CheckBox();
            rdoMoveTool = new System.Windows.Forms.RadioButton();
            txtGridSnapRotate = new System.Windows.Forms.TextBox();
            chkGridSnapRotate = new System.Windows.Forms.CheckBox();
            txtGridSnapScale = new System.Windows.Forms.TextBox();
            expBlueprints = new ExpanderDown();
            groupBox1 = new System.Windows.Forms.GroupBox();
            lstBlueprints = new System.Windows.Forms.ListBox();
            expObjects = new ExpanderDown();
            groupBox4 = new System.Windows.Forms.GroupBox();
            lstObjects = new System.Windows.Forms.ListBox();
            expRightSidebar = new ExpanderLeft();
            flpRightSidebar = new System.Windows.Forms.FlowLayoutPanel();
            lblAspectRatio = new System.Windows.Forms.Label();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            monoGameMainWindow = new MonoGameMainWindow();
            toolStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            expLeftSidebar.SuspendLayout();
            flpLeftSidebar.SuspendLayout();
            expDebugging.SuspendLayout();
            groupBox3.SuspendLayout();
            pnlShow.SuspendLayout();
            expManipulation.SuspendLayout();
            groupBox2.SuspendLayout();
            pnlManiplutationTools3.SuspendLayout();
            pnlManiplutationTools.SuspendLayout();
            expBlueprints.SuspendLayout();
            groupBox1.SuspendLayout();
            expObjects.SuspendLayout();
            groupBox4.SuspendLayout();
            expRightSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripSeparator7, tsbTexCoordEditor, tsbVertexEditor, toolStripSeparator6, tsbPlanarMapObjectSpace, tsbPlanarMapWorldSpace, tsbMatchAlignment, toolStripSeparator9, toolStripLabel1, tscbSelection, toolStripSeparator8, lblSegment, txtSegmentIndex, tsbNewSegment, tsbDeleteSegment, tsbAddToSegment, tsbRemoveFromSegment, tsbLinkSegments, tsbInspectSegment, toolStripSeparator10, tsbPlay, tsbRigidBodyEditor });
            toolStrip1.Location = new System.Drawing.Point(0, 30);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(1450, 39);
            toolStrip1.TabIndex = 28;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbTexCoordEditor
            // 
            tsbTexCoordEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbTexCoordEditor.Image = (System.Drawing.Image)resources.GetObject("tsbTexCoordEditor.Image");
            tsbTexCoordEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbTexCoordEditor.Name = "tsbTexCoordEditor";
            tsbTexCoordEditor.Size = new System.Drawing.Size(36, 36);
            tsbTexCoordEditor.Text = "Thing2D Tex Coord Editor";
            tsbTexCoordEditor.Click += tsbTexCoordEditor_Click;
            // 
            // tsbVertexEditor
            // 
            tsbVertexEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbVertexEditor.Image = (System.Drawing.Image)resources.GetObject("tsbVertexEditor.Image");
            tsbVertexEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbVertexEditor.Name = "tsbVertexEditor";
            tsbVertexEditor.Size = new System.Drawing.Size(36, 36);
            tsbVertexEditor.Text = "Thing2D Vertex Editor";
            tsbVertexEditor.Click += tsbVertexEditor_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbPlanarMapObjectSpace
            // 
            tsbPlanarMapObjectSpace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbPlanarMapObjectSpace.Image = (System.Drawing.Image)resources.GetObject("tsbPlanarMapObjectSpace.Image");
            tsbPlanarMapObjectSpace.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbPlanarMapObjectSpace.Name = "tsbPlanarMapObjectSpace";
            tsbPlanarMapObjectSpace.Size = new System.Drawing.Size(36, 36);
            tsbPlanarMapObjectSpace.Text = "Planar Map Object Space";
            tsbPlanarMapObjectSpace.Click += tsbPlanarMapObjectSpace_Click;
            // 
            // tsbPlanarMapWorldSpace
            // 
            tsbPlanarMapWorldSpace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbPlanarMapWorldSpace.Image = (System.Drawing.Image)resources.GetObject("tsbPlanarMapWorldSpace.Image");
            tsbPlanarMapWorldSpace.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbPlanarMapWorldSpace.Name = "tsbPlanarMapWorldSpace";
            tsbPlanarMapWorldSpace.Size = new System.Drawing.Size(36, 36);
            tsbPlanarMapWorldSpace.Text = "Planar Map (World Space)";
            tsbPlanarMapWorldSpace.Click += tsbPlanarMapWorldSpace_Click;
            // 
            // tsbMatchAlignment
            // 
            tsbMatchAlignment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbMatchAlignment.Image = (System.Drawing.Image)resources.GetObject("tsbMatchAlignment.Image");
            tsbMatchAlignment.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbMatchAlignment.Name = "tsbMatchAlignment";
            tsbMatchAlignment.Size = new System.Drawing.Size(36, 36);
            tsbMatchAlignment.Text = "Match Alignment";
            tsbMatchAlignment.Click += tsbMatchAlignment_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(113, 36);
            toolStripLabel1.Text = "Selection Type:";
            // 
            // tscbSelection
            // 
            tscbSelection.ForeColor = System.Drawing.SystemColors.WindowText;
            tscbSelection.Items.AddRange(new object[] { "Object", "Segment", "Segment StartEnd" });
            tscbSelection.Name = "tscbSelection";
            tscbSelection.Size = new System.Drawing.Size(132, 39);
            tscbSelection.Text = "Object";
            tscbSelection.TextChanged += tscbSelection_TextChanged;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new System.Drawing.Size(6, 39);
            // 
            // lblSegment
            // 
            lblSegment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblSegment.Name = "lblSegment";
            lblSegment.Size = new System.Drawing.Size(118, 36);
            lblSegment.Text = "Segment Index:";
            // 
            // txtSegmentIndex
            // 
            txtSegmentIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSegmentIndex.Name = "txtSegmentIndex";
            txtSegmentIndex.Size = new System.Drawing.Size(66, 39);
            txtSegmentIndex.Text = "0";
            txtSegmentIndex.KeyPress += TextboxValidateFloat;
            txtSegmentIndex.TextChanged += txtSegmentIndex_TextChanged;
            // 
            // tsbNewSegment
            // 
            tsbNewSegment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbNewSegment.Image = (System.Drawing.Image)resources.GetObject("tsbNewSegment.Image");
            tsbNewSegment.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbNewSegment.Name = "tsbNewSegment";
            tsbNewSegment.Size = new System.Drawing.Size(36, 36);
            tsbNewSegment.Text = "New Segment";
            tsbNewSegment.Click += tsbNewSegment_Click;
            // 
            // tsbDeleteSegment
            // 
            tsbDeleteSegment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbDeleteSegment.Image = (System.Drawing.Image)resources.GetObject("tsbDeleteSegment.Image");
            tsbDeleteSegment.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbDeleteSegment.Name = "tsbDeleteSegment";
            tsbDeleteSegment.Size = new System.Drawing.Size(36, 36);
            tsbDeleteSegment.Text = "Delete Segment";
            tsbDeleteSegment.Click += tsbDeleteSegment_Click;
            // 
            // tsbAddToSegment
            // 
            tsbAddToSegment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbAddToSegment.Image = (System.Drawing.Image)resources.GetObject("tsbAddToSegment.Image");
            tsbAddToSegment.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbAddToSegment.Name = "tsbAddToSegment";
            tsbAddToSegment.Size = new System.Drawing.Size(36, 36);
            tsbAddToSegment.Text = "Add To Segment";
            tsbAddToSegment.Click += tsbAddToSegment_Click;
            // 
            // tsbRemoveFromSegment
            // 
            tsbRemoveFromSegment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbRemoveFromSegment.Image = (System.Drawing.Image)resources.GetObject("tsbRemoveFromSegment.Image");
            tsbRemoveFromSegment.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbRemoveFromSegment.Name = "tsbRemoveFromSegment";
            tsbRemoveFromSegment.Size = new System.Drawing.Size(36, 36);
            tsbRemoveFromSegment.Text = "Remove From Segment";
            tsbRemoveFromSegment.Click += tsbRemoveFromSegment_Click;
            // 
            // tsbLinkSegments
            // 
            tsbLinkSegments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbLinkSegments.Image = (System.Drawing.Image)resources.GetObject("tsbLinkSegments.Image");
            tsbLinkSegments.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbLinkSegments.Name = "tsbLinkSegments";
            tsbLinkSegments.Size = new System.Drawing.Size(36, 36);
            tsbLinkSegments.Text = "Link Segments";
            tsbLinkSegments.Click += tsbLinkSegments_Click;
            // 
            // tsbInspectSegment
            // 
            tsbInspectSegment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbInspectSegment.Image = (System.Drawing.Image)resources.GetObject("tsbInspectSegment.Image");
            tsbInspectSegment.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbInspectSegment.Name = "tsbInspectSegment";
            tsbInspectSegment.Size = new System.Drawing.Size(36, 36);
            tsbInspectSegment.Text = "Inspect Segment";
            tsbInspectSegment.Click += tsbInspectSegment_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbPlay
            // 
            tsbPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbPlay.Image = (System.Drawing.Image)resources.GetObject("tsbPlay.Image");
            tsbPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbPlay.Name = "tsbPlay";
            tsbPlay.Size = new System.Drawing.Size(36, 36);
            tsbPlay.Text = "Play Game";
            tsbPlay.Click += tsbPlay_Click;
            // 
            // tsbRigidBodyEditor
            // 
            tsbRigidBodyEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbRigidBodyEditor.Image = (System.Drawing.Image)resources.GetObject("tsbRigidBodyEditor.Image");
            tsbRigidBodyEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbRigidBodyEditor.Name = "tsbRigidBodyEditor";
            tsbRigidBodyEditor.Size = new System.Drawing.Size(36, 36);
            tsbRigidBodyEditor.Text = "Rigid Body Editor";
            tsbRigidBodyEditor.Click += tsbRigidBodyEditor_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem1, editToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            menuStrip1.Size = new System.Drawing.Size(1450, 30);
            menuStrip1.TabIndex = 27;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiNew, tsmLoad, tsmiLoadSegmentFile, toolStripSeparator, tsmSave, tsmSaveAs, tsmiSaveSegmentFile, tsmiSaveMaterials, toolStripSeparator1, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new System.Drawing.Size(46, 24);
            fileToolStripMenuItem1.Text = "&File";
            // 
            // tsmiNew
            // 
            tsmiNew.Image = (System.Drawing.Image)resources.GetObject("tsmiNew.Image");
            tsmiNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsmiNew.Name = "tsmiNew";
            tsmiNew.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N;
            tsmiNew.Size = new System.Drawing.Size(215, 26);
            tsmiNew.Text = "&New";
            tsmiNew.Click += tsmiNew_Click;
            // 
            // tsmLoad
            // 
            tsmLoad.Image = (System.Drawing.Image)resources.GetObject("tsmLoad.Image");
            tsmLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsmLoad.Name = "tsmLoad";
            tsmLoad.Size = new System.Drawing.Size(215, 26);
            tsmLoad.Text = "Load";
            tsmLoad.Click += tsmLoad_Click;
            // 
            // tsmiLoadSegmentFile
            // 
            tsmiLoadSegmentFile.Name = "tsmiLoadSegmentFile";
            tsmiLoadSegmentFile.Size = new System.Drawing.Size(215, 26);
            tsmiLoadSegmentFile.Text = "Load Segment File";
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(212, 6);
            // 
            // tsmSave
            // 
            tsmSave.Image = (System.Drawing.Image)resources.GetObject("tsmSave.Image");
            tsmSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsmSave.Name = "tsmSave";
            tsmSave.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            tsmSave.Size = new System.Drawing.Size(215, 26);
            tsmSave.Text = "&Save";
            tsmSave.Click += tsmSave_Click;
            // 
            // tsmSaveAs
            // 
            tsmSaveAs.Name = "tsmSaveAs";
            tsmSaveAs.Size = new System.Drawing.Size(215, 26);
            tsmSaveAs.Text = "Save &As";
            tsmSaveAs.Click += tsmSaveAs_Click;
            // 
            // tsmiSaveSegmentFile
            // 
            tsmiSaveSegmentFile.Name = "tsmiSaveSegmentFile";
            tsmiSaveSegmentFile.Size = new System.Drawing.Size(215, 26);
            tsmiSaveSegmentFile.Text = "Save Segment File";
            tsmiSaveSegmentFile.Click += tsmiSaveSegmentFile_Click;
            // 
            // tsmiSaveMaterials
            // 
            tsmiSaveMaterials.Name = "tsmiSaveMaterials";
            tsmiSaveMaterials.Size = new System.Drawing.Size(215, 26);
            tsmiSaveMaterials.Text = "Save Materials";
            tsmiSaveMaterials.Click += tsmiSaveMaterials_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(212, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator3, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator4, selectAllToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z;
            undoToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y;
            redoToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(176, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("cutToolStripMenuItem.Image");
            cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X;
            cutToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C;
            copyToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("pasteToolStripMenuItem.Image");
            pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V;
            pasteToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(176, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { customizeToolStripMenuItem, optionsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { contentsToolStripMenuItem, indexToolStripMenuItem, searchToolStripMenuItem, toolStripSeparator5, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            indexToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(147, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            aboutToolStripMenuItem.Text = "&About...";
            // 
            // expLeftSidebar
            // 
            expLeftSidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            expLeftSidebar.Controls.Add(flpLeftSidebar);
            expLeftSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            expLeftSidebar.Location = new System.Drawing.Point(0, 69);
            expLeftSidebar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            expLeftSidebar.Name = "expLeftSidebar";
            expLeftSidebar.Size = new System.Drawing.Size(298, 1229);
            expLeftSidebar.TabIndex = 31;
            // 
            // flpLeftSidebar
            // 
            flpLeftSidebar.AutoScroll = true;
            flpLeftSidebar.Controls.Add(expDebugging);
            flpLeftSidebar.Controls.Add(expManipulation);
            flpLeftSidebar.Controls.Add(expBlueprints);
            flpLeftSidebar.Controls.Add(expObjects);
            flpLeftSidebar.Location = new System.Drawing.Point(4, 5);
            flpLeftSidebar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            flpLeftSidebar.Name = "flpLeftSidebar";
            flpLeftSidebar.Size = new System.Drawing.Size(273, 1151);
            flpLeftSidebar.TabIndex = 25;
            // 
            // expDebugging
            // 
            expDebugging.Controls.Add(groupBox3);
            expDebugging.Location = new System.Drawing.Point(4, 5);
            expDebugging.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            expDebugging.Name = "expDebugging";
            expDebugging.Size = new System.Drawing.Size(240, 286);
            expDebugging.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(pnlShow);
            groupBox3.Location = new System.Drawing.Point(4, 37);
            groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox3.Size = new System.Drawing.Size(228, 232);
            groupBox3.TabIndex = 19;
            groupBox3.TabStop = false;
            groupBox3.Text = "Debugging";
            // 
            // pnlShow
            // 
            pnlShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlShow.Controls.Add(chkSegmentMode);
            pnlShow.Controls.Add(chkShowAABBsNS);
            pnlShow.Controls.Add(chkShowAABBsS);
            pnlShow.Controls.Add(chkShowRigidbodies);
            pnlShow.Controls.Add(chkShowThings);
            pnlShow.Location = new System.Drawing.Point(8, 29);
            pnlShow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlShow.Name = "pnlShow";
            pnlShow.Size = new System.Drawing.Size(211, 193);
            pnlShow.TabIndex = 18;
            // 
            // chkSegmentMode
            // 
            chkSegmentMode.AutoSize = true;
            chkSegmentMode.Checked = true;
            chkSegmentMode.CheckState = System.Windows.Forms.CheckState.Checked;
            chkSegmentMode.Location = new System.Drawing.Point(4, 146);
            chkSegmentMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            chkSegmentMode.Name = "chkSegmentMode";
            chkSegmentMode.Size = new System.Drawing.Size(133, 24);
            chkSegmentMode.TabIndex = 17;
            chkSegmentMode.Text = "Segment Mode";
            chkSegmentMode.UseVisualStyleBackColor = true;
            chkSegmentMode.CheckedChanged += chkSegmentMode_CheckedChanged;
            // 
            // chkShowAABBsNS
            // 
            chkShowAABBsNS.AutoSize = true;
            chkShowAABBsNS.Location = new System.Drawing.Point(4, 5);
            chkShowAABBsNS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            chkShowAABBsNS.Name = "chkShowAABBsNS";
            chkShowAABBsNS.Size = new System.Drawing.Size(191, 24);
            chkShowAABBsNS.TabIndex = 13;
            chkShowAABBsNS.Text = "Show AABBs (nonStatic)";
            chkShowAABBsNS.UseVisualStyleBackColor = true;
            chkShowAABBsNS.CheckedChanged += chkShowAABBsNS_CheckedChanged;
            // 
            // chkShowAABBsS
            // 
            chkShowAABBsS.AutoSize = true;
            chkShowAABBsS.Location = new System.Drawing.Point(4, 40);
            chkShowAABBsS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            chkShowAABBsS.Name = "chkShowAABBsS";
            chkShowAABBsS.Size = new System.Drawing.Size(166, 24);
            chkShowAABBsS.TabIndex = 14;
            chkShowAABBsS.Text = "Show AABBs (Static)";
            chkShowAABBsS.UseVisualStyleBackColor = true;
            chkShowAABBsS.CheckedChanged += chkShowAABBsS_CheckedChanged;
            // 
            // chkShowRigidbodies
            // 
            chkShowRigidbodies.AutoSize = true;
            chkShowRigidbodies.Location = new System.Drawing.Point(4, 75);
            chkShowRigidbodies.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            chkShowRigidbodies.Name = "chkShowRigidbodies";
            chkShowRigidbodies.Size = new System.Drawing.Size(151, 24);
            chkShowRigidbodies.TabIndex = 15;
            chkShowRigidbodies.Text = "Show Rigidbodies";
            chkShowRigidbodies.UseVisualStyleBackColor = true;
            chkShowRigidbodies.CheckedChanged += chkShowRigidbodies_CheckedChanged;
            // 
            // chkShowThings
            // 
            chkShowThings.AutoSize = true;
            chkShowThings.Checked = true;
            chkShowThings.CheckState = System.Windows.Forms.CheckState.Checked;
            chkShowThings.Location = new System.Drawing.Point(4, 111);
            chkShowThings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            chkShowThings.Name = "chkShowThings";
            chkShowThings.Size = new System.Drawing.Size(114, 24);
            chkShowThings.TabIndex = 16;
            chkShowThings.Text = "Show Things";
            chkShowThings.UseVisualStyleBackColor = true;
            chkShowThings.CheckedChanged += chkShowThings_CheckedChanged;
            // 
            // expManipulation
            // 
            expManipulation.Controls.Add(groupBox2);
            expManipulation.Location = new System.Drawing.Point(4, 301);
            expManipulation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            expManipulation.Name = "expManipulation";
            expManipulation.Size = new System.Drawing.Size(240, 309);
            expManipulation.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pnlManiplutationTools3);
            groupBox2.Controls.Add(pnlManiplutationTools);
            groupBox2.Location = new System.Drawing.Point(4, 37);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox2.Size = new System.Drawing.Size(227, 263);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Manitulation Tools    Grid Snap";
            // 
            // pnlManiplutationTools3
            // 
            pnlManiplutationTools3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlManiplutationTools3.Controls.Add(chkAsAGroup);
            pnlManiplutationTools3.Controls.Add(txtPivotRotation);
            pnlManiplutationTools3.Location = new System.Drawing.Point(8, 172);
            pnlManiplutationTools3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlManiplutationTools3.Name = "pnlManiplutationTools3";
            pnlManiplutationTools3.Size = new System.Drawing.Size(211, 76);
            pnlManiplutationTools3.TabIndex = 18;
            // 
            // chkAsAGroup
            // 
            chkAsAGroup.AutoSize = true;
            chkAsAGroup.Location = new System.Drawing.Point(5, 11);
            chkAsAGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            chkAsAGroup.Name = "chkAsAGroup";
            chkAsAGroup.Size = new System.Drawing.Size(106, 24);
            chkAsAGroup.TabIndex = 1;
            chkAsAGroup.Tag = "";
            chkAsAGroup.Text = "As A Group";
            chkAsAGroup.UseVisualStyleBackColor = true;
            chkAsAGroup.CheckedChanged += chkAsAGroup_CheckedChanged;
            // 
            // txtPivotRotation
            // 
            txtPivotRotation.Location = new System.Drawing.Point(136, 34);
            txtPivotRotation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtPivotRotation.Name = "txtPivotRotation";
            txtPivotRotation.Size = new System.Drawing.Size(40, 27);
            txtPivotRotation.TabIndex = 2;
            txtPivotRotation.Text = "0";
            // 
            // pnlManiplutationTools
            // 
            pnlManiplutationTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlManiplutationTools.Controls.Add(txtGridSnapMove);
            pnlManiplutationTools.Controls.Add(rdoNone);
            pnlManiplutationTools.Controls.Add(chkGridSnapScale);
            pnlManiplutationTools.Controls.Add(rdoScaleTool);
            pnlManiplutationTools.Controls.Add(rdoRotateTool);
            pnlManiplutationTools.Controls.Add(chkGridSnapMove);
            pnlManiplutationTools.Controls.Add(rdoMoveTool);
            pnlManiplutationTools.Controls.Add(txtGridSnapRotate);
            pnlManiplutationTools.Controls.Add(chkGridSnapRotate);
            pnlManiplutationTools.Controls.Add(txtGridSnapScale);
            pnlManiplutationTools.Location = new System.Drawing.Point(8, 29);
            pnlManiplutationTools.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlManiplutationTools.Name = "pnlManiplutationTools";
            pnlManiplutationTools.Size = new System.Drawing.Size(211, 144);
            pnlManiplutationTools.TabIndex = 17;
            // 
            // txtGridSnapMove
            // 
            txtGridSnapMove.Location = new System.Drawing.Point(163, 6);
            txtGridSnapMove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtGridSnapMove.Name = "txtGridSnapMove";
            txtGridSnapMove.Size = new System.Drawing.Size(40, 27);
            txtGridSnapMove.TabIndex = 3;
            txtGridSnapMove.Text = "1";
            txtGridSnapMove.TextChanged += txtGridSnapMove_TextChanged;
            txtGridSnapMove.KeyPress += TextboxValidateFloat;
            txtGridSnapMove.Validated += txtGridSnapMove_Validated;
            // 
            // rdoNone
            // 
            rdoNone.AutoSize = true;
            rdoNone.Checked = true;
            rdoNone.Location = new System.Drawing.Point(4, 111);
            rdoNone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            rdoNone.Name = "rdoNone";
            rdoNone.Size = new System.Drawing.Size(66, 24);
            rdoNone.TabIndex = 10;
            rdoNone.TabStop = true;
            rdoNone.Text = "None";
            rdoNone.UseVisualStyleBackColor = true;
            rdoNone.CheckedChanged += rdoNone_CheckedChanged;
            // 
            // chkGridSnapScale
            // 
            chkGridSnapScale.AutoSize = true;
            chkGridSnapScale.Location = new System.Drawing.Point(136, 78);
            chkGridSnapScale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            chkGridSnapScale.Name = "chkGridSnapScale";
            chkGridSnapScale.Size = new System.Drawing.Size(18, 17);
            chkGridSnapScale.TabIndex = 8;
            chkGridSnapScale.UseVisualStyleBackColor = true;
            chkGridSnapScale.CheckedChanged += chkGridSnapScale_CheckedChanged;
            // 
            // rdoScaleTool
            // 
            rdoScaleTool.AutoSize = true;
            rdoScaleTool.Location = new System.Drawing.Point(4, 75);
            rdoScaleTool.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            rdoScaleTool.Name = "rdoScaleTool";
            rdoScaleTool.Size = new System.Drawing.Size(98, 24);
            rdoScaleTool.TabIndex = 7;
            rdoScaleTool.Text = "Scale Tool";
            rdoScaleTool.UseVisualStyleBackColor = true;
            rdoScaleTool.CheckedChanged += rdoScaleTool_CheckedChanged;
            // 
            // rdoRotateTool
            // 
            rdoRotateTool.AutoSize = true;
            rdoRotateTool.Location = new System.Drawing.Point(4, 40);
            rdoRotateTool.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            rdoRotateTool.Name = "rdoRotateTool";
            rdoRotateTool.Size = new System.Drawing.Size(107, 24);
            rdoRotateTool.TabIndex = 4;
            rdoRotateTool.Text = "Rotate Tool";
            rdoRotateTool.UseVisualStyleBackColor = true;
            rdoRotateTool.CheckedChanged += rdoRotateTool_CheckedChanged;
            // 
            // chkGridSnapMove
            // 
            chkGridSnapMove.AutoSize = true;
            chkGridSnapMove.Location = new System.Drawing.Point(136, 11);
            chkGridSnapMove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            chkGridSnapMove.Name = "chkGridSnapMove";
            chkGridSnapMove.Size = new System.Drawing.Size(18, 17);
            chkGridSnapMove.TabIndex = 2;
            chkGridSnapMove.UseVisualStyleBackColor = true;
            chkGridSnapMove.CheckedChanged += chkGridSnapMove_CheckedChanged;
            // 
            // rdoMoveTool
            // 
            rdoMoveTool.AutoSize = true;
            rdoMoveTool.Location = new System.Drawing.Point(4, 5);
            rdoMoveTool.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            rdoMoveTool.Name = "rdoMoveTool";
            rdoMoveTool.Size = new System.Drawing.Size(100, 24);
            rdoMoveTool.TabIndex = 1;
            rdoMoveTool.Text = "Move Tool";
            rdoMoveTool.UseVisualStyleBackColor = true;
            rdoMoveTool.CheckedChanged += rdoMoveTool_CheckedChanged;
            // 
            // txtGridSnapRotate
            // 
            txtGridSnapRotate.Location = new System.Drawing.Point(163, 40);
            txtGridSnapRotate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtGridSnapRotate.Name = "txtGridSnapRotate";
            txtGridSnapRotate.Size = new System.Drawing.Size(40, 27);
            txtGridSnapRotate.TabIndex = 6;
            txtGridSnapRotate.Text = "20";
            txtGridSnapRotate.TextChanged += txtGridSnapRotate_TextChanged;
            txtGridSnapRotate.KeyPress += TextboxValidateFloat;
            txtGridSnapRotate.Validated += txtGridSnapRotate_Validated;
            // 
            // chkGridSnapRotate
            // 
            chkGridSnapRotate.AutoSize = true;
            chkGridSnapRotate.Location = new System.Drawing.Point(136, 45);
            chkGridSnapRotate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            chkGridSnapRotate.Name = "chkGridSnapRotate";
            chkGridSnapRotate.Size = new System.Drawing.Size(18, 17);
            chkGridSnapRotate.TabIndex = 5;
            chkGridSnapRotate.UseVisualStyleBackColor = true;
            chkGridSnapRotate.CheckedChanged += chkGridSnapRotate_CheckedChanged;
            // 
            // txtGridSnapScale
            // 
            txtGridSnapScale.Location = new System.Drawing.Point(163, 74);
            txtGridSnapScale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtGridSnapScale.Name = "txtGridSnapScale";
            txtGridSnapScale.Size = new System.Drawing.Size(40, 27);
            txtGridSnapScale.TabIndex = 9;
            txtGridSnapScale.Text = "1";
            txtGridSnapScale.TextChanged += txtGridSnapScale_TextChanged;
            txtGridSnapScale.KeyPress += TextboxValidateFloat;
            txtGridSnapScale.Validated += txtGridSnapScale_Validated;
            // 
            // expBlueprints
            // 
            expBlueprints.Controls.Add(groupBox1);
            expBlueprints.Location = new System.Drawing.Point(4, 620);
            expBlueprints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            expBlueprints.Name = "expBlueprints";
            expBlueprints.Size = new System.Drawing.Size(240, 232);
            expBlueprints.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lstBlueprints);
            groupBox1.Location = new System.Drawing.Point(4, 37);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox1.Size = new System.Drawing.Size(228, 183);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Blueprints";
            // 
            // lstBlueprints
            // 
            lstBlueprints.FormattingEnabled = true;
            lstBlueprints.ItemHeight = 20;
            lstBlueprints.Items.AddRange(new object[] { "Constructs 01", "Constructs 02", "Constructs 03", "etc..." });
            lstBlueprints.Location = new System.Drawing.Point(8, 23);
            lstBlueprints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            lstBlueprints.Name = "lstBlueprints";
            lstBlueprints.Size = new System.Drawing.Size(211, 144);
            lstBlueprints.TabIndex = 19;
            lstBlueprints.MouseDoubleClick += lstBlueprints_MouseDoubleClick;
            // 
            // expObjects
            // 
            expObjects.Controls.Add(groupBox4);
            expObjects.Location = new System.Drawing.Point(4, 862);
            expObjects.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            expObjects.Name = "expObjects";
            expObjects.Size = new System.Drawing.Size(240, 248);
            expObjects.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lstObjects);
            groupBox4.Location = new System.Drawing.Point(5, 35);
            groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox4.Size = new System.Drawing.Size(227, 205);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "All Objects";
            // 
            // lstObjects
            // 
            lstObjects.FormattingEnabled = true;
            lstObjects.ItemHeight = 20;
            lstObjects.Items.AddRange(new object[] { "Things 01", "Things 02", "Things 03", "etc..." });
            lstObjects.Location = new System.Drawing.Point(8, 29);
            lstObjects.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            lstObjects.Name = "lstObjects";
            lstObjects.Size = new System.Drawing.Size(209, 164);
            lstObjects.TabIndex = 20;
            lstObjects.MouseDoubleClick += lstObjects_MouseDoubleClick;
            // 
            // expRightSidebar
            // 
            expRightSidebar.Controls.Add(flpRightSidebar);
            expRightSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            expRightSidebar.Location = new System.Drawing.Point(1051, 69);
            expRightSidebar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            expRightSidebar.Name = "expRightSidebar";
            expRightSidebar.Size = new System.Drawing.Size(399, 1229);
            expRightSidebar.TabIndex = 30;
            // 
            // flpRightSidebar
            // 
            flpRightSidebar.AutoScroll = true;
            flpRightSidebar.Location = new System.Drawing.Point(21, 0);
            flpRightSidebar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            flpRightSidebar.Name = "flpRightSidebar";
            flpRightSidebar.Size = new System.Drawing.Size(377, 1163);
            flpRightSidebar.TabIndex = 26;
            // 
            // lblAspectRatio
            // 
            lblAspectRatio.AutoSize = true;
            lblAspectRatio.Location = new System.Drawing.Point(951, 80);
            lblAspectRatio.Name = "lblAspectRatio";
            lblAspectRatio.Size = new System.Drawing.Size(93, 20);
            lblAspectRatio.TabIndex = 32;
            lblAspectRatio.Text = "Aspect Ratio";
            // 
            // saveFileDialog
            // 
            saveFileDialog.FileOk += this.saveFileDialog_FileOk;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            openFileDialog.FileOk += openFileDialog_FileOk;
            // 
            // monoGameMainWindow
            // 
            monoGameMainWindow.form = null;
            monoGameMainWindow.GraphicsProfile = Microsoft.Xna.Framework.Graphics.GraphicsProfile.HiDef;
            monoGameMainWindow.Location = new System.Drawing.Point(0, 69);
            monoGameMainWindow.MouseHoverUpdatesOnly = false;
            monoGameMainWindow.Name = "monoGameMainWindow";
            monoGameMainWindow.Size = new System.Drawing.Size(1450, 1229);
            monoGameMainWindow.TabIndex = 0;
            monoGameMainWindow.Text = "monoGameMainWindow1";
            monoGameMainWindow.Click += monoGameMainWindow_Click;
            monoGameMainWindow.MouseEnter += monoGameMainWindow_MouseEnter;
            monoGameMainWindow.MouseLeave += monoGameMainWindow_MouseLeave;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1450, 1298);
            Controls.Add(lblAspectRatio);
            Controls.Add(expLeftSidebar);
            Controls.Add(expRightSidebar);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(monoGameMainWindow);
            Name = "MainForm";
            Text = "MainWindow";
            ResizeBegin += MainForm_ResizeBegin;
            ResizeEnd += MainForm_ResizeEnd;
            Resize += MainForm_Resize;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            expLeftSidebar.ResumeLayout(false);
            flpLeftSidebar.ResumeLayout(false);
            expDebugging.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            pnlShow.ResumeLayout(false);
            pnlShow.PerformLayout();
            expManipulation.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            pnlManiplutationTools3.ResumeLayout(false);
            pnlManiplutationTools3.PerformLayout();
            pnlManiplutationTools.ResumeLayout(false);
            pnlManiplutationTools.PerformLayout();
            expBlueprints.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            expObjects.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            expRightSidebar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsbTexCoordEditor;
        private System.Windows.Forms.ToolStripButton tsbVertexEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbPlanarMapObjectSpace;
        private System.Windows.Forms.ToolStripButton tsbPlanarMapWorldSpace;
        private System.Windows.Forms.ToolStripButton tsbMatchAlignment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscbSelection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripLabel lblSegment;
        private System.Windows.Forms.ToolStripTextBox txtSegmentIndex;
        private System.Windows.Forms.ToolStripButton tsbNewSegment;
        private System.Windows.Forms.ToolStripButton tsbDeleteSegment;
        private System.Windows.Forms.ToolStripButton tsbAddToSegment;
        private System.Windows.Forms.ToolStripButton tsbRemoveFromSegment;
        private System.Windows.Forms.ToolStripButton tsbLinkSegments;
        private System.Windows.Forms.ToolStripButton tsbInspectSegment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton tsbPlay;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmLoad;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadSegmentFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem tsmSave;
        private System.Windows.Forms.ToolStripMenuItem tsmSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveSegmentFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveMaterials;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private ExpanderRight expLeftSidebar;
        private System.Windows.Forms.FlowLayoutPanel flpLeftSidebar;
        private ExpanderDown expDebugging;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel pnlShow;
        private System.Windows.Forms.CheckBox chkSegmentMode;
        private System.Windows.Forms.CheckBox chkShowAABBsNS;
        private System.Windows.Forms.CheckBox chkShowAABBsS;
        private System.Windows.Forms.CheckBox chkShowRigidbodies;
        private System.Windows.Forms.CheckBox chkShowThings;
        private ExpanderDown expManipulation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlManiplutationTools3;
        private System.Windows.Forms.CheckBox chkAsAGroup;
        private System.Windows.Forms.TextBox txtPivotRotation;
        private System.Windows.Forms.Panel pnlManiplutationTools;
        private System.Windows.Forms.TextBox txtGridSnapMove;
        private System.Windows.Forms.RadioButton rdoNone;
        private System.Windows.Forms.CheckBox chkGridSnapScale;
        private System.Windows.Forms.RadioButton rdoScaleTool;
        private System.Windows.Forms.RadioButton rdoRotateTool;
        private System.Windows.Forms.CheckBox chkGridSnapMove;
        private System.Windows.Forms.RadioButton rdoMoveTool;
        private System.Windows.Forms.TextBox txtGridSnapRotate;
        private System.Windows.Forms.CheckBox chkGridSnapRotate;
        private System.Windows.Forms.TextBox txtGridSnapScale;
        private ExpanderDown expBlueprints;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstBlueprints;
        private ExpanderDown expObjects;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstObjects;
        public ExpanderLeft expRightSidebar;
        public System.Windows.Forms.FlowLayoutPanel flpRightSidebar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        public MonoGameMainWindow monoGameMainWindow;
        private System.Windows.Forms.ToolStripButton tsbRigidBodyEditor;
        private System.Windows.Forms.Label lblAspectRatio;
    }
}