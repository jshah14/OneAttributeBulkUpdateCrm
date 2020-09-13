# OneAttributeBulkUpdateCrm
This XrmToolBox Plugin helps update one attribute of an Entity.


It takes a text file as an input. Text file should contain 2 columns separated by some delimiter. First Column should contain the unique value of the record to be updated, and second column should contain the attribute value to be updated. 


Following is the sample file, which is used to update Email Address of Contact records. 


First column = Contact Id, which is unique for contact entity


Second Column = Email value to be updated 


Delimiter = ||

CON-00001||abc@xyz.com


CON-00002||Test@xyz.com


CON-00003||Test123@xyz.com



