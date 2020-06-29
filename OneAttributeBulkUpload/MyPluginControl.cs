using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using OneAttributeBulkUpload.Helpers;
using OneAttributeBulkUpload.Models;
using System.IO;

namespace OneAttributeBulkUpload
{
    public partial class MyPluginControl : PluginControlBase
    {
        private Settings mySettings;

        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }
        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        /// <summary>
        /// Load Entity Button click, call the crm to retrieve entity list, and add them into Entity Combobox
        /// Hide/Show, clear some controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadEntitiesButton_Click(object sender, EventArgs e)
        {
            ///Hide all the target Entity and target attribute related controls
            attributeUpdNoteLabel.Visible = false;
            entityRefLable1.Visible = false;
            targetEntityComboBox.Visible = false;
            targetAttributecomboBox.Visible = false;
            entityReferenceLable2.Visible = false;
            targetEntityComboBox.Visible = false;
            targetEntityNameLable.Visible = false;
            targetEntityAttrLabel.Visible = false;

            //Clear values of attrbutes related combox controls
            selectAttributeComboBox.Items.Clear();
            targetEntityComboBox.Items.Clear();
            targetAttributecomboBox.Items.Clear();
            selectUniqueAttributeComboBox.Items.Clear();

            //Call the method to execute fetching of crm entitties and load them into entity combobox
            ExecuteMethod(CrmEntitiesFetch);
        }

        /// <summary>
        /// Fetches the entity loist from CRM and display it under selct entity combobox control
        /// </summary>
        private void CrmEntitiesFetch()
        {
            WorkAsync(new WorkAsyncInfo
            {
                // Showing message until background work is completed  
                Message = "Retrieving Entities Information",

                // Main task which will be executed asynchronously  
                Work = (worker, args) =>
                {
                    CrmHelper crmHelper = new CrmHelper(Service);
                    args.Result = crmHelper.GetEntitylist();
                },

                // Work is completed, results can be shown to user  
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // Binding result data to ListBox Control                        
                    var result = args.Result as List<EntityMetadata>;
                    selectEntitiesComboBox.Items.Clear();
                    selectAttributeComboBox.Items.Clear();
                    foreach (var entityMetadata in result)
                    {
                        selectEntitiesComboBox.Items.Add(entityMetadata);
                    }
                }
            });
        }

        /// <summary>
        /// OnChange Committed event, when slect entity item change committed
        /// Once entity is selected, this method loads the attrbiutes list on slect attribute and unique attributes combox controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEntitySelect(object sender, EventArgs e)
        {
            string entityLogicalName = ((EntityMetadata)selectEntitiesComboBox.SelectedItem).LogicalName;
            ///Hide all the target Entity and target attribute related controls
            attributeUpdNoteLabel.Visible = false;
            entityRefLable1.Visible = false;
            targetEntityComboBox.Visible = false;
            targetAttributecomboBox.Visible = false;
            entityReferenceLable2.Visible = false;
            targetEntityComboBox.Visible = false;
            targetEntityNameLable.Visible = false;
            targetEntityAttrLabel.Visible = false;

            //Clear values of attrbutes related combox controls
            selectAttributeComboBox.Items.Clear();
            targetEntityComboBox.Items.Clear();
            targetAttributecomboBox.Items.Clear();
            selectUniqueAttributeComboBox.Items.Clear();

            PopulateSelecteAttrbuteComboBox(entityLogicalName);
            PopulateFirstAttributeList(entityLogicalName);
        }

        /// <summary>
        /// Method to populate the Select Attribute combobox from the entity selcted
        /// </summary>
        /// <param name="entityLogicalName"></param>
        private void PopulateSelecteAttrbuteComboBox(string entityLogicalName)
        {
            WorkAsync(new WorkAsyncInfo
            {
                // Showing message until background work is completed  
                Message = "Retrieving Attributes Information",

                // Main task which will be executed asynchronously  
                Work = (worker, args) =>
                {
                    var crmHelper = new CrmHelper(Service);
                    var pluginControlHelper = new PluginControlHelper();
                    var attributeList = crmHelper.GetAttributeListFromEntity(entityLogicalName);
                    args.Result = pluginControlHelper.GetCustomizedAttributes(attributeList);
                },

                // Work is completed, results can be shown to user  
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // Binding result data to ListBox Control                        
                    var result = args.Result as List<AttributeMetadata>;
                    selectAttributeComboBox.Items.Clear();
                    foreach (var attributeMetadata in result)
                    {
                        selectAttributeComboBox.Items.Add(attributeMetadata);
                    }
                }
            });

        }

        /// <summary>
        /// Method to populate the fist column attribute combobox with list of string attributes
        /// </summary>
        /// <param name="entityLogicalName"></param>
        private void PopulateFirstAttributeList(string entityLogicalName)
        {
            WorkAsync(new WorkAsyncInfo
            {
                // Showing message until background work is completed  
                Message = "Retrieving Attributes Information",

                // Main task which will be executed asynchronously  
                Work = (worker, args) =>
                {
                    var crmHelper = new CrmHelper(Service);
                    var pluginControlHelper = new PluginControlHelper();
                    var attributeList = crmHelper.GetAttributeListFromEntity(entityLogicalName);
                    args.Result = pluginControlHelper.GetStringAttributes(attributeList);
                },

                // Work is completed, results can be shown to user  
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // Binding result data to ListBox Control                        
                    var result = args.Result as List<AttributeMetadata>;
                    selectUniqueAttributeComboBox.Items.Clear();
                    foreach (var attributeMetadata in result)
                    {
                        selectUniqueAttributeComboBox.Items.Add(attributeMetadata);
                    }
                }
            });
        }


        /// <summary>
        /// Event to fired when Update Attribute option is slected
        /// Once the value is slected it will load the target entity and attribute related combox controls if attribute type is referene
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUpdAttributeSelect(object sender, EventArgs e)
        {
            targetEntityComboBox.Items.Clear();
            targetAttributecomboBox.Items.Clear();

            string attributeType = ((AttributeMetadata)selectAttributeComboBox.SelectedItem).AttributeType;
            if (attributeType != null)
            {
                var allowedRefTypes = (Enum.GetValues(typeof(AllowedRefAttrType))).OfType<object>().Select(o => o.ToString()).ToArray();
                if (Array.Exists(allowedRefTypes, element => element.ToLower() == attributeType.ToLower()))
                {
                    ///show all the target Entity and target attribute related controls
                    attributeUpdNoteLabel.Visible = false;
                    entityRefLable1.Visible = true;
                    targetEntityComboBox.Visible = true;
                    targetAttributecomboBox.Visible = true;
                    entityReferenceLable2.Visible = true;
                    targetEntityComboBox.Visible = true;
                    targetEntityNameLable.Visible = true;
                    targetEntityAttrLabel.Visible = true;

                    targetEntityComboBox.Items.Clear();
                    targetAttributecomboBox.Items.Clear();

                    var refEntityList = ((AttributeMetadata)selectAttributeComboBox.SelectedItem).TargetSchemaName;

                    foreach (var entityName in refEntityList)
                    {
                        targetEntityComboBox.Items.Add(entityName);
                    }
                }
                else
                {
                    ///Hide all the target Entity and target attribute related controls
                    attributeUpdNoteLabel.Visible = true;
                    entityRefLable1.Visible = false;
                    targetEntityComboBox.Visible = false;
                    targetAttributecomboBox.Visible = false;
                    entityReferenceLable2.Visible = false;
                    targetEntityComboBox.Visible = false;
                    targetEntityNameLable.Visible = false;
                    targetEntityAttrLabel.Visible = false;

                    targetEntityComboBox.Items.Clear();
                    targetAttributecomboBox.Items.Clear();
                }
            }
        }

        /// <summary>
        /// Event to be triggered when target entity combobox value is selected
        /// Once the value is selected it will populate items in Target Entity Attribute combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectTargetEntity(object sender, EventArgs e)
        {
            targetAttributecomboBox.Items.Clear();
            var entityLogicalName = targetEntityComboBox.SelectedItem.ToString();

            WorkAsync(new WorkAsyncInfo
            {
                // Showing message until background work is completed  
                Message = "Retrieving Target Entity Attributes Information",

                // Main task which will be executed asynchronously  
                Work = (worker, args) =>
                {
                    var crmHelper = new CrmHelper(Service);
                    var pluginControlHelper = new PluginControlHelper();
                    var attributeList = crmHelper.GetAttributeListFromEntity(entityLogicalName);
                    args.Result = pluginControlHelper.GetStringAttributes(attributeList);
                },

                // Work is completed, results can be shown to user  
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // Binding result data to ListBox Control                        
                    var result = args.Result as List<AttributeMetadata>;
                    targetAttributecomboBox.Items.Clear();
                    foreach (var attributeMetadata in result)
                    {
                        targetAttributecomboBox.Items.Add(attributeMetadata);
                    }
                }
            });
        }


        /// <summary>
        /// Evet to be fired when the Brwose button is clicked
        /// Perform validation, if validations are passed it will open the dialog box to select the load file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseButton_Click(object sender, EventArgs e)
        {
            var isEntitySelected = selectEntitiesComboBox.SelectedItem != null;
            var isCorrectAttrbiuteSelected = false;
            var isAttributeSelected = selectAttributeComboBox.SelectedItem != null;
            var isUniqueAttrSelected = selectUniqueAttributeComboBox.SelectedItem != null;
            var isTargetEntitySelected = targetEntityComboBox.SelectedItem != null;
            var isTargetAttrSelected = targetAttributecomboBox.SelectedItem != null;

            if (isAttributeSelected)
            {
                var attrType = ((AttributeMetadata)selectAttributeComboBox.SelectedItem).AttributeType;
                var allowedRefTypes = (Enum.GetValues(typeof(AllowedRefAttrType))).OfType<object>().Select(o => o.ToString()).ToArray();
                if (Array.Exists(allowedRefTypes, element => element.ToLower() == attrType.ToLower()))
                {
                    isCorrectAttrbiuteSelected = isTargetEntitySelected && isTargetAttrSelected;
                }
                else
                {
                    isCorrectAttrbiuteSelected = true;
                }
            }
            else
            {
                isCorrectAttrbiuteSelected = false;
            }

            if (isEntitySelected && isCorrectAttrbiuteSelected && isUniqueAttrSelected)
            {
                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt";
                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.            
                if (result == DialogResult.OK) // Test result.
                {
                    string fileName = openFileDialog1.FileName;
                    fileNameTextBox.Text = fileName;
                }
            }
            else
            {
                if (!isEntitySelected)
                {
                    MessageBox.Show("Please select the entity to update");
                }
                if (isEntitySelected && !isCorrectAttrbiuteSelected)
                {
                    MessageBox.Show("Please select the correct attribute to be updated");
                }
                if (isEntitySelected && isCorrectAttrbiuteSelected && !isUniqueAttrSelected)
                {
                    MessageBox.Show("Please select the unique attribute for the entity to be updated");
                }
            }
        }


        /// <summary>
        /// Event to fired when Proceed TO Load button is clicked
        /// It performs the validations before proceed for load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void proceedToLoadButton_Click(object sender, EventArgs e)
        {
            var isEntitySelected = selectEntitiesComboBox.SelectedItem != null;
            var isCorrectAttrbiuteSelected = false;
            var isAttributeSelected = selectAttributeComboBox.SelectedItem != null;
            var isUniqueAttrSelected = selectUniqueAttributeComboBox.SelectedItem != null;
            var isTargetEntitySelected = targetEntityComboBox.SelectedItem != null;
            var isTargetAttrSelected = targetAttributecomboBox.SelectedItem != null;
            var isDelimeterSelected = delimeterTextBox.Text.Length > 0;
            var isFileSelected = fileNameTextBox.Text.Length > 0;

            if (isAttributeSelected)
            {
                var attrType = ((AttributeMetadata)selectAttributeComboBox.SelectedItem).AttributeType;
                if (attrType == AttributeType.Lookup.ToString() || attrType == AttributeType.Owner.ToString())
                {
                    isCorrectAttrbiuteSelected = isTargetEntitySelected && isTargetAttrSelected;
                }
                else
                {
                    isCorrectAttrbiuteSelected = true;
                }
            }
            else
            {
                isCorrectAttrbiuteSelected = false;
            }

            if (!isEntitySelected)
            {
                MessageBox.Show("Please select the entity to update");
            }
            if (isEntitySelected && !isCorrectAttrbiuteSelected)
            {
                MessageBox.Show("Please select the correct attribute to be updated");
            }
            if (isEntitySelected && isCorrectAttrbiuteSelected && !isUniqueAttrSelected)
            {
                MessageBox.Show("Please select the unique attribute for the entity to be updated");
            }
            if (isEntitySelected && isCorrectAttrbiuteSelected && isUniqueAttrSelected && !isFileSelected)
            {
                MessageBox.Show("Please select the file for upload");
            }
            if (isEntitySelected && isCorrectAttrbiuteSelected && isUniqueAttrSelected && isFileSelected && !isDelimeterSelected)
            {
                MessageBox.Show("Please select the delimeter to be used for this data update");
            }
            if (isEntitySelected && isCorrectAttrbiuteSelected && isUniqueAttrSelected && isFileSelected && isDelimeterSelected)
            {
                var isSpacePresent = delimeterTextBox.Text.Contains(" ");
                var delimeterLenghtCheck = delimeterTextBox.Text.Length > 3;
                if (isSpacePresent)
                {
                    MessageBox.Show("File delimeter can not have spaces");
                }
                if (delimeterLenghtCheck)
                {
                    MessageBox.Show("File delimeter can not be greater than 3 characters long");
                }
                if (!isSpacePresent && !delimeterLenghtCheck)
                {
                    ProceedToLoad();
                }
            }
        }
        
        /// <summary>
        /// MEthod responsible to load the data in CRM
        /// </summary>
        private void ProceedToLoad()
        {
            WorkAsync(new WorkAsyncInfo
            {
                // Showing message until background work is completed  
                Message = "File load processing",

                // Main task which will be executed asynchronously  
                Work = (worker, args) =>
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ProcessLoadFile(ref stringBuilder);
                    args.Result = stringBuilder;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var logs = (StringBuilder)args.Result;
                    logsRichTextBox.Text = logs.ToString();
                }
            });

        }

        /// <summary>
        /// Process loading of file in CRM, this method responsible to read the lines of files and process further.
        /// </summary>
        /// <param name="stringBuilder"></param>
        private void ProcessLoadFile(ref StringBuilder stringBuilder)
        {
            string[] lines = File.ReadAllLines(fileNameTextBox.Text);
            stringBuilder.AppendLine("Start reading the file");
            var lineCount = lines.Count();
            stringBuilder.AppendLine($"No of lines in the file : {lineCount}");
            if (lineCount == 0)
            {
                stringBuilder.AppendLine("File is empty, no lines to prcoess");
            }
            if (lineCount > 1000)
            {
                stringBuilder.AppendLine($"There are more than 1000 lines in the file, only first 1000 will be processed");
                lines = lines.Take(1000).ToArray();
            }
            if (lineCount > 0)
            {
                var delimeter = delimeterTextBox.Text;
                var pluginControlHelper = new PluginControlHelper();
                var keyValuePairs = pluginControlHelper.CreateDictionaryListForLoad(lines, delimeter, ref stringBuilder);
                if (keyValuePairs.Count > 0)
                {

                    ProcessLoadInCrm(keyValuePairs, ref stringBuilder);
                }
            }

        }

        /// <summary>
        /// Method responsible to update record in CRM
        /// It performs different validation before updaing the record and calls the update record method
        /// </summary>
        /// <param name="keyValuePairs"></param>
        /// <param name="stringBuilder"></param>
        private void ProcessLoadInCrm(List<FileUpdateModel> keyValuePairs, ref StringBuilder stringBuilder)
        {
            UpdateAttributeStructure updateAttributeStructure = new UpdateAttributeStructure();

            var entityName = selectEntitiesComboBox.SelectedItem != null ? ((EntityMetadata)selectEntitiesComboBox.SelectedItem).LogicalName : null;
            if (entityName == null)
            {
                stringBuilder.AppendLine("Entity Name not selected, can not proceed load");
                return;
            }
            updateAttributeStructure.EntityName = entityName;

            var selectedAttr = selectAttributeComboBox.SelectedItem != null ? (AttributeMetadata)selectAttributeComboBox.SelectedItem : null;
            if (entityName == null)
            {
                stringBuilder.AppendLine("Attribute to be updated not selected, can not procees load");
                return;
            }

            var selectedAttrType = ((AttributeMetadata)selectAttributeComboBox.SelectedItem).AttributeType;
            var selectedAttrName = ((AttributeMetadata)selectAttributeComboBox.SelectedItem).LogicalName;
            updateAttributeStructure.UpdateAttrName = selectedAttrName;
            updateAttributeStructure.UpdateAttrDataType = selectedAttrType;

            var allowedRefTypes = (Enum.GetValues(typeof(AllowedRefAttrType))).OfType<object>().Select(o => o.ToString()).ToArray();

            var selectedAttrIsRef = Array.Exists(allowedRefTypes, element => element == selectedAttrType);

            string targetEntityName = null;
            string targetEntityAttrName = null;

            if (selectedAttrIsRef == true)
            {
                targetEntityName = targetEntityComboBox.SelectedItem != null ? targetEntityComboBox.SelectedItem.ToString() : null;
                if (targetEntityName == null)
                {
                    stringBuilder.AppendLine("Attribute to be updated is a reference attribute, target entity is not selected for it, can not proceed load");
                    return;
                }
                targetEntityAttrName = targetAttributecomboBox.SelectedItem != null ? ((AttributeMetadata)targetAttributecomboBox.SelectedItem).LogicalName : null;
                updateAttributeStructure.TargetEntityName = targetEntityName;
                if (targetEntityAttrName == null)
                {
                    stringBuilder.AppendLine("Attribute to be updated is a reference attribute, target entity Attrbite is not selected for it, can not proceed load");
                    return;
                }
                updateAttributeStructure.TargetEntityAttrName = targetEntityAttrName;
            }

            var uniqueAttributeName = ((AttributeMetadata)selectUniqueAttributeComboBox.SelectedItem).LogicalName;

            if (uniqueAttributeName == null)
            {
                stringBuilder.AppendLine("Attribute to be used as first column not selected, can not procees load");
                return;
            }
            updateAttributeStructure.UniqueAttrName = uniqueAttributeName;
            int succescCount = 0;

            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                try 
                { 
                    var item = keyValuePairs[i];
                    updateAttributeStructure.FileRecord = item;
                    var crmHelper = new CrmHelper(Service);
                    var activeRecords = activeRecordsCheckBox.Checked;

                    QueryExpression qEntity = new QueryExpression(entityName);
                    qEntity.ColumnSet.AddColumns(uniqueAttributeName, selectedAttrName);
                    qEntity.Criteria.AddCondition(uniqueAttributeName, ConditionOperator.Equal, item.UniqueAttrValue);
                    if(activeRecords)
                    {
                        qEntity.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
                    }

                    var ecEntity = crmHelper.GetEntityCollection(qEntity);
                    if (ecEntity.Entities.Count == 0)
                    {
                        stringBuilder.AppendLine($"Record : {i + 1} , No record found for the entity {entityName} for Attribute {uniqueAttributeName} with value - {item.UniqueAttrValue} ");
                    }
                    if (ecEntity.Entities.Count > 1)
                    {
                        stringBuilder.AppendLine($"Record: { i + 1} ,More than one ({ecEntity.Entities.Count}) record found for the entity {entityName} for Attribute {uniqueAttributeName} with value - {item.UniqueAttrValue} ");
                    }
                    if (ecEntity.Entities.Count == 1)
                    {                        
                        if (UpdateRecord(ecEntity.Entities[0], crmHelper, updateAttributeStructure, i, ref stringBuilder))
                        {
                            succescCount = succescCount + 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    stringBuilder.AppendLine($"Record: { i + 1}, Failed, {ex.Message}");
                }
            }
            stringBuilder.AppendLine($"Total Records Processed : {succescCount}");
        }

        /// <summary>
        /// This method responsible for updating record in CRM
        /// Based on the Attribute type, it takes the attrbite and update the record in CRM
        /// </summary>
        /// <param name="entityToUpd"></param>
        /// <param name="crmHelper"></param>
        /// <param name="updateAttributeStructure"></param>
        /// <param name="recordNumber"></param>
        /// <param name="stringBuilder"></param>
        /// <returns></returns>
        private bool UpdateRecord(Entity entityToUpd, CrmHelper crmHelper, UpdateAttributeStructure updateAttributeStructure, int recordNumber, ref StringBuilder stringBuilder)
        {
            string attrType = updateAttributeStructure.UpdateAttrDataType;
            var fileRecord = updateAttributeStructure.FileRecord;
            var updAttrName = updateAttributeStructure.UpdateAttrName;
            var allowedRefTypes = (Enum.GetValues(typeof(AllowedRefAttrType))).OfType<object>().Select(o => o.ToString()).ToArray();
            var allowedAllTypes = (Enum.GetValues(typeof(AllowedAttributeType))).OfType<object>().Select(o => o.ToString()).ToArray();

            var whetherToProcess = Array.Exists(allowedAllTypes, element => element.ToLower() == attrType.ToLower());
            if(!whetherToProcess)
            {
                stringBuilder.AppendLine($"Attribute selected for update is of type {attrType}, is currently unsupported.");
                return true;
            }

            if (string.IsNullOrEmpty(fileRecord.UpdateAttrValue))
            {
                entityToUpd[updAttrName] = null;
            }
            if (attrType.Equals(AttributeType.String.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                entityToUpd[updAttrName] = fileRecord.UpdateAttrValue.ToString();
            }
            else if (attrType.Equals(AttributeType.Integer.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                entityToUpd[updAttrName] = Convert.ToInt32(fileRecord.UpdateAttrValue);
            }
            else if (attrType.Equals(AttributeType.Double.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                entityToUpd[updAttrName] = Convert.ToDouble(fileRecord.UpdateAttrValue);
            }
            else if (attrType.Equals(AttributeType.Decimal.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                entityToUpd[updAttrName] = Convert.ToDecimal(fileRecord.UpdateAttrValue);
            }
            else if (attrType.Equals(AttributeType.Boolean.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                entityToUpd[updAttrName] = Convert.ToBoolean(bool.Parse(fileRecord.UpdateAttrValue));
            }
            else if (attrType.Equals(AttributeType.DateTime.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                entityToUpd[updAttrName] = DateTime.ParseExact(fileRecord.UpdateAttrValue, "yyyy-MM-dd HH:mm tt", null);
            }
            else if (attrType.Equals(AttributeType.Picklist.ToString(), StringComparison.CurrentCultureIgnoreCase) ||
                attrType.Equals(AttributeType.State.ToString(), StringComparison.CurrentCultureIgnoreCase) ||
                    attrType.Equals(AttributeType.Status.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                entityToUpd[updAttrName] = new OptionSetValue(Convert.ToInt32(fileRecord.UpdateAttrValue));
            }
            else if (attrType.Equals(AttributeType.Money.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                entityToUpd[updAttrName] = new Money(Convert.ToDecimal(fileRecord.UpdateAttrValue));
            }
            else if (Array.Exists(allowedRefTypes, element => element.ToLower() == attrType.ToLower()))
            {
                var tagetEntityName = updateAttributeStructure.TargetEntityName;
                var targetEntityAttrName = updateAttributeStructure.TargetEntityAttrName;
                QueryExpression qTargetEntity = new QueryExpression(tagetEntityName);
                qTargetEntity.ColumnSet.AddColumns(targetEntityAttrName);
                qTargetEntity.Criteria.AddCondition(targetEntityAttrName, ConditionOperator.Equal, fileRecord.UpdateAttrValue);

                var ecTargetEntity = crmHelper.GetEntityCollection(qTargetEntity);

                if (ecTargetEntity.Entities.Count == 0)
                {
                    stringBuilder.AppendLine($"Record : {recordNumber + 1} , No record found for the entity {tagetEntityName} for Attribute {targetEntityAttrName} with value - {fileRecord.UpdateAttrValue} ");
                    return false;
                }
                if (ecTargetEntity.Entities.Count > 1)
                {
                    stringBuilder.AppendLine($"Record: { recordNumber + 1} ,More than one ({ecTargetEntity.Entities.Count}) record found for the entity {tagetEntityName} for Attribute {targetEntityAttrName} with value - {fileRecord.UpdateAttrValue} ");
                    return false;
                }
                if (ecTargetEntity.Entities.Count == 1)
                {
                    if(attrType.Equals(AttributeType.PartyList.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        Entity activityParty = new Entity("activityparty");
                        activityParty["partyid"] = ecTargetEntity.Entities[0].ToEntityReference();
                        var parties = (EntityCollection)entityToUpd[updAttrName];
                        parties.Entities.Add(activityParty);
                        entityToUpd[updAttrName] = parties;
                    }
                    else
                    {
                        entityToUpd[updAttrName] = ecTargetEntity.Entities[0].ToEntityReference();
                    }                    
                }
            }
            crmHelper.UpdateRecord(entityToUpd);
            return true;
        }
    }
}