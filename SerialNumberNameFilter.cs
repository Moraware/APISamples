// The internal "serial number id" is the number that shows up on the address bar/url.
// The "serial number name" is what most people would think of as the serial number.
// To find by "serial number name" you have to search for it, which is slightly cumbersome:

            var snName = "13218"; // how users see the serial number
            var snf = new SerialNumberFilter();
            snf.AddTextFilter(SerialNumberFilter.SerialNumberTextFilterFields_Enum.Name, new TextFilter(snName, true));
            var SNs = conn.GetSerialNumbers(snf, new PagingOptions());
            var theSN = SNs.FirstOrDefault(); // will be null if not found
