using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using CustomControls;

namespace _2DLevelCreator
{
    public static class PropertyUpdater
    {
        public static List<string> lstSkipPropertyType = new List<string>();      //Property Types That Should Be Skipped While Performing Reflection
        public static List<string> lstSkipPropertyName = new List<string>();      //Property Names That Should Be Skipped While Performing Reflection
        public static List<string> lstAllowPropertyType = new List<string>();     //Property Types That We Will Update


        public static void InitiateVariableStringLists()
        {
            PropertyUpdater.lstSkipPropertyType.Clear();
            PropertyUpdater.lstSkipPropertyName.Clear();
            PropertyUpdater.lstAllowPropertyType.Clear();

            PropertyUpdater.lstSkipPropertyType.Add("LevelCreator.AABB");
            PropertyUpdater.lstSkipPropertyType.Add("LevelCreator.Transform");
            PropertyUpdater.lstSkipPropertyType.Add("Microsoft.Xna.Framework.Matrix");
            PropertyUpdater.lstSkipPropertyType.Add("Microsoft.Xna.Framework.Color");

            PropertyUpdater.lstAllowPropertyType.Add("System.Boolean");
            PropertyUpdater.lstAllowPropertyType.Add("System.Int32");
            PropertyUpdater.lstAllowPropertyType.Add("Single");
            PropertyUpdater.lstAllowPropertyType.Add("System.Single");
            PropertyUpdater.lstAllowPropertyType.Add("System.String");
            PropertyUpdater.lstAllowPropertyType.Add("Microsoft.Xna.Framework.Vector3");
            PropertyUpdater.lstAllowPropertyType.Add("Vector3");
            PropertyUpdater.lstAllowPropertyType.Add("Microsoft.Xna.Framework.Vector2");
            PropertyUpdater.lstAllowPropertyType.Add("Vector2");
            //PropertyUpdater.lstAllowPropertyType.Add("Microsoft.Xna.Framework.Graphics.VertexPositionTexture[]");
        }




        /// <summary>
        /// Looks at the property type and checks to see if its name matches and types that
        /// the user has specified to skip. It also checks for any variable names to skip as well
        /// </summary>
        /// <returns> Return true if a match was found(Ie skip this property) </returns>
        public static bool SkipThisProperty(PropertyInfo property)
        {
            for (int iCount = 0, iCountMax = lstSkipPropertyType.Count; iCount < iCountMax; ++iCount)
            {
                if (property.PropertyType.FullName == lstSkipPropertyType[iCount])
                    return true;
            }
            for (int iCount = 0, iCountMax = lstSkipPropertyName.Count; iCount < iCountMax; ++iCount)
            {
                if (property.Name == lstSkipPropertyName[iCount]) return true;
            }

            return false;
        }

        /// <summary>
        /// Loops through a list that holds the names of variable types that the user has considered as valid
        /// </summary>
        /// <returns> Returns true if Type is valid. False if not valid.</returns>
        public static bool AllowThisProperty(PropertyInfo property)
        {
            for (int iCount = 0, iCountMax = lstAllowPropertyType.Count; iCount < iCountMax; ++iCount)
            {
                if (property.PropertyType.FullName == lstAllowPropertyType[iCount])
                    return true;
            }
            return false;
        }

        public static bool AllowThisType(Type type)
        {
            for (int iCount = 0, iCountMax = lstAllowPropertyType.Count; iCount < iCountMax; ++iCount)
            {
                if (type.Name == lstAllowPropertyType[iCount])
                    return true;
            }
            return false;
        }














        public static void DisplayProperties(ref object objectClass, Control control)
        {
            ClearThisControl(control);
            DisplayPropertiesInThisControl(ref objectClass, control, objectClass.GetType().Name, -1);
            ResizeExpandersInThisControl(control);
        }

        private static void DisplayPropertiesInThisControl(ref object objectClass, Control thisControl, string parentName, int arrayID)
        {


            if (objectClass is Array)
            {
                Array array = (Array)objectClass;
                object opa  = array;

                
      
                for (int i = 0; i < array.Length; i++)                      //Loops through all of the properties (Change to "foreach (object o in a){}" ???)
                {
                    object objectFromArray = array.GetValue(i);

                    if (AllowThisType(array.GetValue(i).GetType()))
                    {
                        AddPropertyToThisControl(array.GetType().Name + " " + i , objectFromArray.GetType().Name, ref objectFromArray, ref opa, i, thisControl); //ie float[4]
                    }
                    else
                    {
                        DisplayPropertiesInThisControl(ref objectFromArray, thisControl, parentName, i);    //Recursion. ie Vector3[4]
                    }
                }
            }
            else
            {


                Type type = objectClass.GetType();
                PropertyInfo[] properties = type.GetProperties();   
                string ParentName = (arrayID < 0) ? parentName : parentName + arrayID;
           
                foreach (PropertyInfo property in properties)                   //Loops through all of the properties
                {
                    if (AllowThisProperty(property))                            //Checks for Valid Types
                    {
                        object op = property.GetValue(objectClass, null);
                        AddPropertyToThisControl(ParentName, property.Name, ref op, ref objectClass, 0, thisControl);
                    }
                    else if (!SkipThisProperty(property))                       //If Type not valid then checks the properties of this type.(Ignores User spesific Types e.g. AABB)
                    {
                        object op = property.GetValue(objectClass, null);
                        DisplayPropertiesInThisControl(ref op, thisControl, property.Name, -1);    //Recursion
                    }
                }
                
            }
        }



        private static void ResizeExpandersInThisControl(Control thisControl)
        {
            List<Control> lstTemp = PropertyUpdater.GetAllControlTypesInThisControl(typeof(Expander), thisControl);     //Gets all of the controls that match the type inside of thisControl
            List<Expander> lstExpanders = new List<Expander>();
            for (int i = 0; i < lstTemp.Count; ++i) {if (lstTemp[i] is Expander) lstExpanders.Add((Expander)lstTemp[i]);}   //Converts all of the matched type to their correct type
            

            //Loop through the expanders and open and close them to refresh their size.
            for (int i = 0; i < lstExpanders.Count; ++i)
            {
                lstExpanders[i].OpenExpander();
            }
        }







        public static void AddPropertyToThisControl(string propertySection, string propertyName, ref object value, ref object classReference, int arrayIndex, Control thisControl)
        {
            //Search for Property Section and creates one if it does not exist.
            if ((FlowLayoutPanel)thisControl.Controls.Find("flp" + propertySection, true).FirstOrDefault() == null) AddGamePropertyExpander(propertySection, thisControl);

            FlowLayoutPanel flp = (FlowLayoutPanel)thisControl.Controls.Find("flp" + propertySection, true).FirstOrDefault();
            ExpanderDown exp = (ExpanderDown)thisControl.Controls.Find("exp" + propertySection, true).FirstOrDefault();



            //Searches for a property and updates if it exists or creates if it doesnt exist.
            GameProperty gameProperty = (GameProperty)flp.Controls.Find("gp" + propertyName, true).FirstOrDefault();
            if (gameProperty != null)
            {
                gameProperty.FillProperty(value);
            }
            else
            {
                gameProperty = new GameProperty(propertyName, ref value, ref classReference, arrayIndex);
                flp.Controls.Add(gameProperty);
            }
        }


        public static void AddGamePropertyExpander(string name, Control control)
        {
            object op = null;
            using (GameProperty gp = new GameProperty("", ref op, ref op, 0))
            {
                ExpanderDown exp = new ExpanderDown();
                exp.Name = "exp" + name;
                exp.Size = new Size(gp.Width, 0);

                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Name = "flp" + name;
                flp.Location = new System.Drawing.Point(0, exp.btnCollapse.Height);
                flp.AutoSize = true;
                flp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                flp.FlowDirection = FlowDirection.TopDown;
                exp.Controls.Add(flp);

                control.Controls.Add(exp);
            }
        }

        public static void ClearThisControl(Control thisControl)
        {
            thisControl.Controls.Clear();
        }


































        /// <summary>
        /// This function will search for all of the GameProperty Types inside of thisControl.
        /// It will then update its field.
        /// </summary>
        public static void UpdateGamePropertiesFields(Control control)
        {
            List<Control> lstTemp = PropertyUpdater.GetAllControlTypesInThisControl(typeof(GameProperty), control);
            List<GameProperty> lstGameProperties = new List<GameProperty>();
            for (int iCount = 0, iCountMax = lstTemp.Count; iCount < iCountMax; ++iCount)
            {
                if (lstTemp[iCount] is GameProperty) lstGameProperties.Add((GameProperty)lstTemp[iCount]);
            }

            for (int iCount = 0, iCountMax = lstGameProperties.Count; iCount < iCountMax; ++iCount)
            {
                lstGameProperties[iCount].UpdateFieldFromProperty();
            }
        }







        /// <summary>
        /// Specify the type to look for and the control to look inside of.
        /// Will then run a function that will return a list of controls that match the type
        /// that was specified.
        /// </summary>
        public static List<Control> GetAllControlTypesInThisControl(Type type, Control thisControl)
        {
            List<Control> lstControls = new List<Control>();
            FindAllControlsInThisControl(type, ref lstControls, thisControl);
            return lstControls;

        }

        /// <summary>
        /// Looks inside of thisControl for objects of the specified type which it will then add to the list.
        /// Will then call this function recursivly on each object inside of thisControl to locate more matches.
        /// </summary>
        private static void FindAllControlsInThisControl(Type type, ref List<Control> lstControls, Control thisControl)
        {
            //Look at all the controls inside of thisControl for a match.
            foreach (Control ctrl in thisControl.Controls)
            {
                if (ctrl.GetType().IsSubclassOf(type) || ctrl.GetType() == type) lstControls.Add(ctrl);    //Adds the control to the list if it matches the type.
            }

            //Now have a look inside each of thisControl's controls for matches.
            foreach (Control ctrl in thisControl.Controls)
            {
                FindAllControlsInThisControl(type, ref lstControls, ctrl);  //Recursion.
            }
        }


    }
}
