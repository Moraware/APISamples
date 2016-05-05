// The internal "serial number id" is the number that shows up on the address bar/url.
// ... so for the URL https://patrick.moraware.net/d.aspx?wp=37&snId=1871
// ... the serial number id is 1871, which you can get directly with 
            var id = 1871;
            var sn = conn.GetSerialNumber(id);

// The "serial number name" is what most people would think of as the serial number.
// To find by "serial number name" you have to search for it, which is slightly cumbersome:

            var snName = "13218"; // how users see the serial number
            var snf = new SerialNumberFilter();
            snf.AddTextFilter(SerialNumberFilter.SerialNumberTextFilterFields_Enum.Name, new TextFilter(snName, true));
            var SNs = conn.GetSerialNumbers(snf, new PagingOptions());
            var theSN = SNs.FirstOrDefault(); // will be null if not found
