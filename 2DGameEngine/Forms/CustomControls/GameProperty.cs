using System;
using Microsoft.Xna.Framework;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using CommonWinFormsFunctions;

namespace CustomControls
{
    public class GameProperty: Panel
    {
        private Label lblLabel;
        private TextBox txtTextbox1;
        private TextBox txtTextboxX;
        private TextBox txtTextboxY;
        private TextBox txtTextboxZ;
        private CheckBox chkCheckbox;

        public object classProperty = 0;
        public object classReference = 0;
        public string variableName = "";
        public int arrayIndex = 0;



        public GameProperty(string variableName, ref object value, ref object classReference, int arrayIndex)
        {
            this.Name = "gp" + variableName;
            this.classProperty = value;
            this.classReference = classReference;
            this.Initalise(variableName);
            this.FillProperty(value);
            this.variableName = variableName;
            this.arrayIndex = arrayIndex;
        }


        private void GainFocusOnMouseDown(object sender, MouseEventArgs e)
        {
            ((Control)(sender)).Focus();
        }

        private void Initalise(string name)
        {
            // 
            // panel1
            // 
            this.BorderStyle = BorderStyle.FixedSingle;
            this.TabIndex = 0;
            this.ClientSize = new Size(254, 27);
            this.Margin = new Padding(0,0,0,0);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GainFocusOnMouseDown);
            //
            //lblLabel
            //
            this.lblLabel = new System.Windows.Forms.Label();
            this.Controls.Add(this.lblLabel);
            this.lblLabel.Location = new System.Drawing.Point(3, 7);
            this.lblLabel.Text = name;
            this.lblLabel.Size = new Size(115, lblLabel.Height);
            this.lblLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GainFocusOnMouseDown);

            if (classProperty is bool)
            {
                //
                // chkCheckbox
                //
                this.chkCheckbox = new System.Windows.Forms.CheckBox();
                this.Controls.Add(this.chkCheckbox);
                this.chkCheckbox.CheckedChanged += new EventHandler(this.UpdatePropertyFromField);
                this.chkCheckbox.Location = new System.Drawing.Point(230, 3);
                this.chkCheckbox.Size = new System.Drawing.Size(125, 20);
                this.chkCheckbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GainFocusOnMouseDown);
            }
            else if (classProperty is Vector2)
            {
                //
                // txtTextboxX
                //
                this.txtTextboxX = new System.Windows.Forms.TextBox();
                this.Controls.Add(this.txtTextboxX);
                this.txtTextboxX.KeyPress += new KeyPressEventHandler(this.ValidateKeyPress);
                this.txtTextboxX.TextChanged += new EventHandler(this.UpdatePropertyFromField);
                this.txtTextboxX.Location = new System.Drawing.Point(120, 3);
                this.txtTextboxX.Size = new System.Drawing.Size(41, 20);
                this.txtTextboxX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GainFocusOnMouseDown);
                //
                // txtTextboxY
                //
                this.txtTextboxY = new System.Windows.Forms.TextBox();
                this.Controls.Add(this.txtTextboxY);
                this.txtTextboxY.KeyPress += new KeyPressEventHandler(this.ValidateKeyPress);
                this.txtTextboxY.TextChanged += new EventHandler(this.UpdatePropertyFromField);
                this.txtTextboxY.Location = new System.Drawing.Point(161, 3);
                this.txtTextboxY.Size = new System.Drawing.Size(41, 20);
                this.txtTextboxY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GainFocusOnMouseDown);
            }
            else if (classProperty is Vector3)
            {
                //
                // txtTextboxX
                //
                this.txtTextboxX = new System.Windows.Forms.TextBox();
                this.Controls.Add(this.txtTextboxX);
                this.txtTextboxX.KeyPress += new KeyPressEventHandler(this.ValidateKeyPress);
                this.txtTextboxX.TextChanged += new EventHandler(this.UpdatePropertyFromField);
                this.txtTextboxX.Location = new System.Drawing.Point(120, 3);
                this.txtTextboxX.Size = new System.Drawing.Size(41, 20);
                this.txtTextboxX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GainFocusOnMouseDown);
                //
                // txtTextboxY
                //
                this.txtTextboxY = new System.Windows.Forms.TextBox();
                this.Controls.Add(this.txtTextboxY);
                this.txtTextboxY.KeyPress += new KeyPressEventHandler(this.ValidateKeyPress);
                this.txtTextboxY.TextChanged += new EventHandler(this.UpdatePropertyFromField);
                this.txtTextboxY.Location = new System.Drawing.Point(161, 3);
                this.txtTextboxY.Size = new System.Drawing.Size(41, 20);
                this.txtTextboxY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GainFocusOnMouseDown);
                //
                // txtTextboxZ
                //
                this.txtTextboxZ = new System.Windows.Forms.TextBox();
                this.Controls.Add(this.txtTextboxZ);
                this.txtTextboxZ.KeyPress += new KeyPressEventHandler(this.ValidateKeyPress);
                this.txtTextboxZ.TextChanged += new EventHandler(this.UpdatePropertyFromField);
                this.txtTextboxZ.Location = new System.Drawing.Point(203, 3);
                this.txtTextboxZ.Size = new System.Drawing.Size(41, 20);
                this.txtTextboxZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GainFocusOnMouseDown);
            }
            else
            {
                //
                // txtTextbox
                //
                this.txtTextbox1 = new System.Windows.Forms.TextBox();
                this.Controls.Add(this.txtTextbox1);
                this.txtTextbox1.KeyPress += new KeyPressEventHandler(this.ValidateKeyPress);
                this.txtTextbox1.TextChanged += new EventHandler(this.UpdatePropertyFromField);
                this.txtTextbox1.Location = new System.Drawing.Point(120, 3);
                this.txtTextbox1.Size = new System.Drawing.Size(125, 20);
                this.txtTextbox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GainFocusOnMouseDown);
            }
        }







        public void FillProperty(object o)
        {

            if (classProperty is bool)
            {
                this.chkCheckbox.Checked = bool.Parse(o.ToString());
            }
            else if (classProperty is int || classProperty is float || classProperty is string)
            {
                this.txtTextbox1.Text = o.ToString();
            }
            else if (classProperty is Vector3)
            {
                this.txtTextboxX.Text = ((Vector3)(o)).X.ToString();
                this.txtTextboxY.Text = ((Vector3)(o)).Y.ToString();
                this.txtTextboxZ.Text = ((Vector3)(o)).Z.ToString();              
            }
            else if (classProperty is Vector2)
            {
                this.txtTextboxX.Text = ((Vector2)(o)).X.ToString();
                this.txtTextboxY.Text = ((Vector2)(o)).Y.ToString();
            }
        }







        public object GetProperty()
        {
            if (classProperty is bool)
            {
                return this.chkCheckbox.Checked;
            }
            else if (classProperty is int)
            {
                if (int.TryParse(this.txtTextbox1.Text, out int val)) return val;
                return null;
            }
            else if (classProperty is float)
            {
                if (float.TryParse(this.txtTextbox1.Text, out float val)) return val;
                return null;
            }
            else if (classProperty is Vector2)
            {
                if (this.txtTextboxX.Text == "" || this.txtTextboxX.Text == "-" || this.txtTextboxX.Text == "." || this.txtTextboxX.Text == "-.") return null;
                if (this.txtTextboxY.Text == "" || this.txtTextboxY.Text == "-" || this.txtTextboxY.Text == "." || this.txtTextboxY.Text == "-.") return null;
                return new Vector2(float.Parse(this.txtTextboxX.Text), float.Parse(this.txtTextboxY.Text));
            }
            else if (classProperty is Vector3)
            {
                if (this.txtTextboxX.Text == "" || this.txtTextboxX.Text == "-" || this.txtTextboxX.Text == "." || this.txtTextboxX.Text == "-.") return null;
                if (this.txtTextboxY.Text == "" || this.txtTextboxY.Text == "-" || this.txtTextboxY.Text == "." || this.txtTextboxY.Text == "-.") return null;
                if (this.txtTextboxZ.Text == "" || this.txtTextboxZ.Text == "-" || this.txtTextboxZ.Text == "." || this.txtTextboxZ.Text == "-.") return null;
                return new Vector3(float.Parse(this.txtTextboxX.Text), float.Parse(this.txtTextboxY.Text), float.Parse(this.txtTextboxZ.Text));
            }
            
            return this.txtTextbox1.Text;
        }

        private void ValidateKeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.ValidateText(this.classProperty.GetType(), ((TextBox)sender).Text, e, ((TextBox)sender).SelectionStart, ((TextBox)sender).SelectedText);
        }





        public void UpdatePropertyFromField(object sender, EventArgs e)
        {
            object newValue = this.GetProperty();   //this returns a null if the textbox(or whatever control) is invalid ie. if a textbox was "." updating a property would throw an error
            
            if (newValue == null) return;   //Doesnt update the property if not valid

            if (this.classReference is Array)
            {
                Array a = (Array)this.classReference;

                a.SetValue(newValue, this.arrayIndex);
            }
            else
            {
                Type type = this.classReference.GetType();
                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo property in properties)                       //Loops through all of the properties
                {
                    if (property.Name == this.variableName)                         //Checks for variable name match
                    {
                        property.SetValue(this.classReference, newValue, null);     //Changes the value.
                    }
                }
            }
        }
















        public void UpdateFieldFromProperty()
        {
            if (this.txtTextbox1 != null) if (this.txtTextbox1.Focused) return;
            if (this.txtTextboxX != null) if (this.txtTextboxX.Focused) return;
            if (this.txtTextboxY != null) if (this.txtTextboxY.Focused) return;
            if (this.txtTextboxZ != null) if (this.txtTextboxZ.Focused) return;
            if (this.chkCheckbox != null) if (this.chkCheckbox.Focused) return;

            Type type = this.classReference.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)                                   //Loops through all of the properties
            {
                if (property.Name == this.variableName)                                     //Checks for variable name match
                {
                    FillProperty(property.GetValue(this.classReference,null));
                }
            }
        }
    }
}
