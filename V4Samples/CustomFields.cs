// this example is for Job Custom Fields - other custom fields (account, activity, etc.) work similarly

// Get the list of job custom fields
var jcfs = conn.GetCustomJobFieldTypes(false); // true if you want inactive, too
foreach (var jcf in jcfs)
{
    // do something with the list
    Console.WriteLine("{0} - {1} ({2})", jcf.CustomFieldTypeId, jcf.CustomFieldTypeName, jcf.CustomFieldDataType);
}

var j = conn.GetJob(5310); // a job in my demo system
var jn = j.CustomFieldValues.Item("Job Number"); // get Job Number by custom field name
var jn2 = j.CustomFieldValues.Item(597); // get Job Number by custom field id
                                         // (597 is the id for "Job Number" in my demo system)

Console.WriteLine("{0} == {1}", jn.FieldValue, jn2.FieldValue); // do something with the field value

var x = j.CustomFieldValues.Item("Job Number").FieldValue; // if you want to get just the value in one shot
