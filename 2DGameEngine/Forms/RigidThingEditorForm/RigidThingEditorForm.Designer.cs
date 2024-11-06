using CommonWinFormsFunctions;

namespace _2DLevelCreator
{
    partial class RigidThingEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RigidThingEditorForm));
            msMenu = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            tsmiCreateThing2D = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            tsmiDeleteThing2D = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            tsToolBar = new System.Windows.Forms.ToolStrip();
            tsbConvertToBC = new System.Windows.Forms.ToolStripButton();
            tsbConvertToOBB = new System.Windows.Forms.ToolStripButton();
            tslConvertToConvexPolygon = new System.Windows.Forms.ToolStripButton();
            tsbAddVertex = new System.Windows.Forms.ToolStripButton();
            tsbDeleteVertex = new System.Windows.Forms.ToolStripButton();
            tsbCenterVertexPositions = new System.Windows.Forms.ToolStripButton();
            tsbMatchThing2DVerts = new System.Windows.Forms.ToolStripButton();
            expRightSidebar = new CustomControls.ExpanderLeft();
            flpRightSidebar = new System.Windows.Forms.FlowLayoutPanel();
            expLeftSidebar = new CustomControls.ExpanderRight();
            flpLeftSidebar = new System.Windows.Forms.FlowLayoutPanel();
            expDebugging = new CustomControls.ExpanderDown();
            grpDebugging = new System.Windows.Forms.GroupBox();
            pnlDebugging = new System.Windows.Forms.Panel();
            txtGridSpacing = new System.Windows.Forms.TextBox();
            lblGridSpacing = new System.Windows.Forms.Label();
            txtGridSize = new System.Windows.Forms.TextBox();
            txtTransparency = new System.Windows.Forms.TextBox();
            lblGridSize = new System.Windows.Forms.Label();
            lblTransparency = new System.Windows.Forms.Label();
            expManipulation = new CustomControls.ExpanderDown();
            grpManipulation = new System.Windows.Forms.GroupBox();
            pnlManiplutationTools3 = new System.Windows.Forms.Panel();
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
            expMode = new CustomControls.ExpanderDown();
            gbMode = new System.Windows.Forms.GroupBox();
            pnlMode = new System.Windows.Forms.Panel();
            rdoCentroidMode = new System.Windows.Forms.RadioButton();
            rdoRigidbodyMode = new System.Windows.Forms.RadioButton();
            rigidThingEditorWindow = new CustomControls.RigidThingEditorWindow();
            msMenu.SuspendLayout();
            tsToolBar.SuspendLayout();
            expRightSidebar.SuspendLayout();
            expLeftSidebar.SuspendLayout();
            flpLeftSidebar.SuspendLayout();
            expDebugging.SuspendLayout();
            grpDebugging.SuspendLayout();
            pnlDebugging.SuspendLayout();
            expManipulation.SuspendLayout();
            grpManipulation.SuspendLayout();
            pnlManiplutationTools3.SuspendLayout();
            pnlManiplutationTools.SuspendLayout();
            expMode.SuspendLayout();
            gbMode.SuspendLayout();
            pnlMode.SuspendLayout();
            SuspendLayout();
            // 
            // msMenu
            // 
            msMenu.BackColor = System.Drawing.SystemColors.ControlDark;
            msMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem1, editToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            msMenu.Location = new System.Drawing.Point(0, 0);
            msMenu.Name = "msMenu";
            msMenu.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            msMenu.Size = new System.Drawing.Size(1657, 30);
            msMenu.TabIndex = 23;
            msMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiCreateThing2D, toolStripSeparator, tsmiDeleteThing2D, toolStripSeparator6, saveToolStripMenuItem1, saveAsToolStripMenuItem, toolStripSeparator1, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new System.Drawing.Size(46, 24);
            fileToolStripMenuItem1.Text = "&File";
            // 
            // tsmiCreateThing2D
            // 
            tsmiCreateThing2D.Image = (System.Drawing.Image)resources.GetObject("tsmiCreateThing2D.Image");
            tsmiCreateThing2D.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsmiCreateThing2D.Name = "tsmiCreateThing2D";
            tsmiCreateThing2D.Size = new System.Drawing.Size(196, 26);
            tsmiCreateThing2D.Text = "Create Thing2D";
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(193, 6);
            // 
            // tsmiDeleteThing2D
            // 
            tsmiDeleteThing2D.Name = "tsmiDeleteThing2D";
            tsmiDeleteThing2D.Size = new System.Drawing.Size(196, 26);
            tsmiDeleteThing2D.Text = "Delete Thing2D";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(193, 6);
            // 
            // saveToolStripMenuItem1
            // 
            saveToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("saveToolStripMenuItem1.Image");
            saveToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            saveToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            saveToolStripMenuItem1.Size = new System.Drawing.Size(196, 26);
            saveToolStripMenuItem1.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
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
            // tsToolBar
            // 
            tsToolBar.BackColor = System.Drawing.SystemColors.ControlLight;
            tsToolBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            tsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsbConvertToBC, tsbConvertToOBB, tslConvertToConvexPolygon, tsbAddVertex, tsbDeleteVertex, tsbCenterVertexPositions, tsbMatchThing2DVerts });
            tsToolBar.Location = new System.Drawing.Point(0, 30);
            tsToolBar.Name = "tsToolBar";
            tsToolBar.Size = new System.Drawing.Size(1657, 39);
            tsToolBar.TabIndex = 24;
            tsToolBar.Text = "toolStrip1";
            // 
            // tsbConvertToBC
            // 
            tsbConvertToBC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbConvertToBC.Image = (System.Drawing.Image)resources.GetObject("tsbConvertToBC.Image");
            tsbConvertToBC.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbConvertToBC.Name = "tsbConvertToBC";
            tsbConvertToBC.Size = new System.Drawing.Size(36, 36);
            tsbConvertToBC.Text = "Convert To Bounding Circle";
            tsbConvertToBC.Click += tsbConvertToBC_Click;
            // 
            // tsbConvertToOBB
            // 
            tsbConvertToOBB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbConvertToOBB.Image = (System.Drawing.Image)resources.GetObject("tsbConvertToOBB.Image");
            tsbConvertToOBB.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbConvertToOBB.Name = "tsbConvertToOBB";
            tsbConvertToOBB.Size = new System.Drawing.Size(36, 36);
            tsbConvertToOBB.Text = "Convert To OBB";
            tsbConvertToOBB.Click += tsbConvertToOBB_Click;
            // 
            // tslConvertToConvexPolygon
            // 
            tslConvertToConvexPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tslConvertToConvexPolygon.Image = (System.Drawing.Image)resources.GetObject("tslConvertToConvexPolygon.Image");
            tslConvertToConvexPolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            tslConvertToConvexPolygon.Name = "tslConvertToConvexPolygon";
            tslConvertToConvexPolygon.Size = new System.Drawing.Size(36, 36);
            tslConvertToConvexPolygon.Text = "Convert To Convex Polygon";
            tslConvertToConvexPolygon.Click += tslConvertToConvexPolygon_Click;
            // 
            // tsbAddVertex
            // 
            tsbAddVertex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbAddVertex.Image = (System.Drawing.Image)resources.GetObject("tsbAddVertex.Image");
            tsbAddVertex.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbAddVertex.Name = "tsbAddVertex";
            tsbAddVertex.Size = new System.Drawing.Size(36, 36);
            tsbAddVertex.Text = "Add Vertex";
            tsbAddVertex.Click += tsbAddVertex_Click;
            // 
            // tsbDeleteVertex
            // 
            tsbDeleteVertex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbDeleteVertex.Image = (System.Drawing.Image)resources.GetObject("tsbDeleteVertex.Image");
            tsbDeleteVertex.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbDeleteVertex.Name = "tsbDeleteVertex";
            tsbDeleteVertex.Size = new System.Drawing.Size(36, 36);
            tsbDeleteVertex.Text = "Delete Vertex";
            tsbDeleteVertex.Click += tsbDeleteVertex_Click;
            // 
            // tsbCenterVertexPositions
            // 
            tsbCenterVertexPositions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbCenterVertexPositions.Image = (System.Drawing.Image)resources.GetObject("tsbCenterVertexPositions.Image");
            tsbCenterVertexPositions.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbCenterVertexPositions.Name = "tsbCenterVertexPositions";
            tsbCenterVertexPositions.Size = new System.Drawing.Size(36, 36);
            tsbCenterVertexPositions.Text = "Center Thing2D Vertice Positions";
            tsbCenterVertexPositions.Click += tsbCenterVertexPositions_Click;
            // 
            // tsbMatchThing2DVerts
            // 
            tsbMatchThing2DVerts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbMatchThing2DVerts.Image = (System.Drawing.Image)resources.GetObject("tsbMatchThing2DVerts.Image");
            tsbMatchThing2DVerts.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbMatchThing2DVerts.Name = "tsbMatchThing2DVerts";
            tsbMatchThing2DVerts.Size = new System.Drawing.Size(36, 36);
            tsbMatchThing2DVerts.Text = "Match Thing2D Image";
            tsbMatchThing2DVerts.Click += tsbMatchThing2DVerts_Click;
            // 
            // expRightSidebar
            // 
            expRightSidebar.Controls.Add(flpRightSidebar);
            expRightSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            expRightSidebar.Location = new System.Drawing.Point(1258, 69);
            expRightSidebar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            expRightSidebar.Name = "expRightSidebar";
            expRightSidebar.Size = new System.Drawing.Size(399, 1253);
            expRightSidebar.TabIndex = 0;
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
            // expLeftSidebar
            // 
            expLeftSidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            expLeftSidebar.Controls.Add(flpLeftSidebar);
            expLeftSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            expLeftSidebar.Location = new System.Drawing.Point(0, 69);
            expLeftSidebar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            expLeftSidebar.Name = "expLeftSidebar";
            expLeftSidebar.Size = new System.Drawing.Size(298, 1253);
            expLeftSidebar.TabIndex = 0;
            // 
            // flpLeftSidebar
            // 
            flpLeftSidebar.AutoScroll = true;
            flpLeftSidebar.Controls.Add(expDebugging);
            flpLeftSidebar.Controls.Add(expManipulation);
            flpLeftSidebar.Controls.Add(expMode);
            flpLeftSidebar.Location = new System.Drawing.Point(4, 5);
            flpLeftSidebar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            flpLeftSidebar.Name = "flpLeftSidebar";
            flpLeftSidebar.Size = new System.Drawing.Size(273, 1151);
            flpLeftSidebar.TabIndex = 25;
            // 
            // expDebugging
            // 
            expDebugging.Controls.Add(grpDebugging);
            expDebugging.Location = new System.Drawing.Point(4, 5);
            expDebugging.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            expDebugging.Name = "expDebugging";
            expDebugging.Size = new System.Drawing.Size(240, 198);
            expDebugging.TabIndex = 0;
            // 
            // grpDebugging
            // 
            grpDebugging.Controls.Add(pnlDebugging);
            grpDebugging.Location = new System.Drawing.Point(4, 37);
            grpDebugging.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            grpDebugging.Name = "grpDebugging";
            grpDebugging.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            grpDebugging.Size = new System.Drawing.Size(228, 151);
            grpDebugging.TabIndex = 19;
            grpDebugging.TabStop = false;
            grpDebugging.Text = "Debugging";
            // 
            // pnlDebugging
            // 
            pnlDebugging.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlDebugging.Controls.Add(txtGridSpacing);
            pnlDebugging.Controls.Add(lblGridSpacing);
            pnlDebugging.Controls.Add(txtGridSize);
            pnlDebugging.Controls.Add(txtTransparency);
            pnlDebugging.Controls.Add(lblGridSize);
            pnlDebugging.Controls.Add(lblTransparency);
            pnlDebugging.Location = new System.Drawing.Point(8, 29);
            pnlDebugging.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlDebugging.Name = "pnlDebugging";
            pnlDebugging.Size = new System.Drawing.Size(211, 111);
            pnlDebugging.TabIndex = 19;
            // 
            // txtGridSpacing
            // 
            txtGridSpacing.Location = new System.Drawing.Point(164, 72);
            txtGridSpacing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtGridSpacing.Name = "txtGridSpacing";
            txtGridSpacing.Size = new System.Drawing.Size(40, 27);
            txtGridSpacing.TabIndex = 4;
            txtGridSpacing.Text = "0.1";
            txtGridSpacing.TextChanged += txtGridSpacing_TextChanged;
            txtGridSpacing.KeyPress += TextboxValidateFloat;
            txtGridSpacing.Validated += txtGridSpacing_Validated;
            // 
            // lblGridSpacing
            // 
            lblGridSpacing.AutoSize = true;
            lblGridSpacing.Location = new System.Drawing.Point(7, 77);
            lblGridSpacing.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGridSpacing.Name = "lblGridSpacing";
            lblGridSpacing.Size = new System.Drawing.Size(94, 20);
            lblGridSpacing.TabIndex = 3;
            lblGridSpacing.Text = "Grid Spacing";
            // 
            // txtGridSize
            // 
            txtGridSize.Location = new System.Drawing.Point(164, 38);
            txtGridSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtGridSize.Name = "txtGridSize";
            txtGridSize.Size = new System.Drawing.Size(40, 27);
            txtGridSize.TabIndex = 2;
            txtGridSize.Text = "1";
            txtGridSize.TextChanged += txtGridSize_TextChanged;
            txtGridSize.KeyPress += TextboxValidateFloat;
            txtGridSize.Validated += txtGridSize_Validated;
            // 
            // txtTransparency
            // 
            txtTransparency.Location = new System.Drawing.Point(164, 5);
            txtTransparency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtTransparency.Name = "txtTransparency";
            txtTransparency.Size = new System.Drawing.Size(40, 27);
            txtTransparency.TabIndex = 2;
            txtTransparency.Text = "0.5";
            txtTransparency.TextChanged += txtTransparency_TextChanged;
            txtTransparency.KeyPress += TextboxValidateFloat;
            txtTransparency.Validated += txtTransparency_Validated;
            // 
            // lblGridSize
            // 
            lblGridSize.AutoSize = true;
            lblGridSize.Location = new System.Drawing.Point(7, 43);
            lblGridSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGridSize.Name = "lblGridSize";
            lblGridSize.Size = new System.Drawing.Size(68, 20);
            lblGridSize.TabIndex = 0;
            lblGridSize.Text = "Grid Size";
            // 
            // lblTransparency
            // 
            lblTransparency.AutoSize = true;
            lblTransparency.Location = new System.Drawing.Point(7, 9);
            lblTransparency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTransparency.Name = "lblTransparency";
            lblTransparency.Size = new System.Drawing.Size(95, 20);
            lblTransparency.TabIndex = 0;
            lblTransparency.Text = "Transparency";
            // 
            // expManipulation
            // 
            expManipulation.Controls.Add(grpManipulation);
            expManipulation.Location = new System.Drawing.Point(4, 213);
            expManipulation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            expManipulation.Name = "expManipulation";
            expManipulation.Size = new System.Drawing.Size(240, 280);
            expManipulation.TabIndex = 0;
            // 
            // grpManipulation
            // 
            grpManipulation.Controls.Add(pnlManiplutationTools3);
            grpManipulation.Controls.Add(pnlManiplutationTools);
            grpManipulation.Location = new System.Drawing.Point(4, 37);
            grpManipulation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            grpManipulation.Name = "grpManipulation";
            grpManipulation.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            grpManipulation.Size = new System.Drawing.Size(227, 237);
            grpManipulation.TabIndex = 1;
            grpManipulation.TabStop = false;
            grpManipulation.Text = "Manitulation Tools    Grid Snap";
            // 
            // pnlManiplutationTools3
            // 
            pnlManiplutationTools3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlManiplutationTools3.Controls.Add(txtPivotRotation);
            pnlManiplutationTools3.Location = new System.Drawing.Point(8, 172);
            pnlManiplutationTools3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlManiplutationTools3.Name = "pnlManiplutationTools3";
            pnlManiplutationTools3.Size = new System.Drawing.Size(211, 50);
            pnlManiplutationTools3.TabIndex = 18;
            // 
            // txtPivotRotation
            // 
            txtPivotRotation.Location = new System.Drawing.Point(163, 5);
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
            txtGridSnapMove.Text = "0.1";
            txtGridSnapMove.TextChanged += txtGridSnapMove_TextChanged;
            txtGridSnapMove.KeyPress += TextboxValidateFloat;
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
            txtGridSnapScale.Text = "0.1";
            txtGridSnapScale.TextChanged += txtGridSnapScale_TextChanged;
            txtGridSnapScale.KeyPress += TextboxValidateFloat;
            // 
            // expMode
            // 
            expMode.Controls.Add(gbMode);
            expMode.Location = new System.Drawing.Point(4, 503);
            expMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            expMode.Name = "expMode";
            expMode.Size = new System.Drawing.Size(240, 160);
            expMode.TabIndex = 20;
            // 
            // gbMode
            // 
            gbMode.Controls.Add(pnlMode);
            gbMode.Location = new System.Drawing.Point(4, 37);
            gbMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gbMode.Name = "gbMode";
            gbMode.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gbMode.Size = new System.Drawing.Size(228, 115);
            gbMode.TabIndex = 19;
            gbMode.TabStop = false;
            gbMode.Text = "Mode";
            // 
            // pnlMode
            // 
            pnlMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlMode.Controls.Add(rdoCentroidMode);
            pnlMode.Controls.Add(rdoRigidbodyMode);
            pnlMode.Location = new System.Drawing.Point(8, 29);
            pnlMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlMode.Name = "pnlMode";
            pnlMode.Size = new System.Drawing.Size(211, 74);
            pnlMode.TabIndex = 19;
            // 
            // rdoCentroidMode
            // 
            rdoCentroidMode.AutoSize = true;
            rdoCentroidMode.Location = new System.Drawing.Point(4, 40);
            rdoCentroidMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            rdoCentroidMode.Name = "rdoCentroidMode";
            rdoCentroidMode.Size = new System.Drawing.Size(130, 24);
            rdoCentroidMode.TabIndex = 9;
            rdoCentroidMode.Text = "Centroid Mode";
            rdoCentroidMode.UseVisualStyleBackColor = true;
            rdoCentroidMode.CheckedChanged += rdoCentroidMode_CheckedChanged;
            // 
            // rdoRigidbodyMode
            // 
            rdoRigidbodyMode.AutoSize = true;
            rdoRigidbodyMode.Checked = true;
            rdoRigidbodyMode.Location = new System.Drawing.Point(4, 5);
            rdoRigidbodyMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            rdoRigidbodyMode.Name = "rdoRigidbodyMode";
            rdoRigidbodyMode.Size = new System.Drawing.Size(142, 24);
            rdoRigidbodyMode.TabIndex = 8;
            rdoRigidbodyMode.TabStop = true;
            rdoRigidbodyMode.Text = "Rigidbody Mode";
            rdoRigidbodyMode.UseVisualStyleBackColor = true;
            rdoRigidbodyMode.CheckedChanged += rdoRigidbodyMode_CheckedChanged;
            // 
            // rigidThingEditorWindow
            // 
            rigidThingEditorWindow.form = null;
            rigidThingEditorWindow.GraphicsProfile = Microsoft.Xna.Framework.Graphics.GraphicsProfile.HiDef;
            rigidThingEditorWindow.Location = new System.Drawing.Point(0, 72);
            rigidThingEditorWindow.MouseHoverUpdatesOnly = false;
            rigidThingEditorWindow.Name = "rigidThingEditorWindow";
            rigidThingEditorWindow.Size = new System.Drawing.Size(1654, 1250);
            rigidThingEditorWindow.TabIndex = 25;
            rigidThingEditorWindow.Text = "rigidThingEditorWindow";
            rigidThingEditorWindow.Click += XnaMainWindow_Click;
            rigidThingEditorWindow.MouseEnter += XnaMainWindow_MouseEnter;
            rigidThingEditorWindow.MouseLeave += XnaMainWindow_MouseLeave;
            // 
            // RigidThingEditorForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1657, 1322);
            Controls.Add(expRightSidebar);
            Controls.Add(expLeftSidebar);
            Controls.Add(tsToolBar);
            Controls.Add(msMenu);
            Controls.Add(rigidThingEditorWindow);
            MainMenuStrip = msMenu;
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "RigidThingEditorForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Rigidbody Editor";
            FormClosing += ClosingForm;
            Resize += ResizeForm;
            msMenu.ResumeLayout(false);
            msMenu.PerformLayout();
            tsToolBar.ResumeLayout(false);
            tsToolBar.PerformLayout();
            expRightSidebar.ResumeLayout(false);
            expLeftSidebar.ResumeLayout(false);
            flpLeftSidebar.ResumeLayout(false);
            expDebugging.ResumeLayout(false);
            grpDebugging.ResumeLayout(false);
            pnlDebugging.ResumeLayout(false);
            pnlDebugging.PerformLayout();
            expManipulation.ResumeLayout(false);
            grpManipulation.ResumeLayout(false);
            pnlManiplutationTools3.ResumeLayout(false);
            pnlManiplutationTools3.PerformLayout();
            pnlManiplutationTools.ResumeLayout(false);
            pnlManiplutationTools.PerformLayout();
            expMode.ResumeLayout(false);
            gbMode.ResumeLayout(false);
            pnlMode.ResumeLayout(false);
            pnlMode.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        //public CustomControls.XnaWindow XnaWindow;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateThing2D;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
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
        private System.Windows.Forms.ToolStrip tsToolBar;
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
        private System.Windows.Forms.Panel pnlManiplutationTools3;
        private System.Windows.Forms.TextBox txtPivotRotation;
        private CustomControls.ExpanderDown expDebugging;
        private System.Windows.Forms.GroupBox grpDebugging;
        private CustomControls.ExpanderDown expManipulation;
        private System.Windows.Forms.GroupBox grpManipulation;
        private System.Windows.Forms.FlowLayoutPanel flpLeftSidebar;
        private CustomControls.ExpanderRight expLeftSidebar;
        public CustomControls.ExpanderLeft expRightSidebar;
        public System.Windows.Forms.FlowLayoutPanel flpRightSidebar;
        private System.Windows.Forms.Panel pnlDebugging;
        private System.Windows.Forms.TextBox txtTransparency;
        private System.Windows.Forms.Label lblTransparency;
        private System.Windows.Forms.TextBox txtGridSpacing;
        private System.Windows.Forms.Label lblGridSpacing;
        private System.Windows.Forms.TextBox txtGridSize;
        private System.Windows.Forms.Label lblGridSize;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteThing2D;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbConvertToBC;
        private System.Windows.Forms.ToolStripButton tsbConvertToOBB;
        private System.Windows.Forms.ToolStripButton tslConvertToConvexPolygon;
        private CustomControls.ExpanderDown expMode;
        private System.Windows.Forms.GroupBox gbMode;
        private System.Windows.Forms.Panel pnlMode;
        private System.Windows.Forms.RadioButton rdoCentroidMode;
        private System.Windows.Forms.RadioButton rdoRigidbodyMode;
        private System.Windows.Forms.ToolStripButton tsbAddVertex;
        private System.Windows.Forms.ToolStripButton tsbDeleteVertex;
        private System.Windows.Forms.ToolStripButton tsbCenterVertexPositions;
        private System.Windows.Forms.ToolStripButton tsbMatchThing2DVerts;
        public CustomControls.RigidThingEditorWindow rigidThingEditorWindow;
    }
}