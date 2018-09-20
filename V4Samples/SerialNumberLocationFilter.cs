//First, you have to find your inventory locations like this (I would just do this in some throwaway code):
​
​            var ILs = conn.GetInventoryLocations();
            foreach(var il in ILs) {
                Console.WriteLine("Location: {0}, id: {1}", il.InventoryLocationName, il.InventoryLocationId);
            }


//Then, make an array with the inventory locations you want to filter for:
​
​            var arrayOfValues = new int[] { 8, 9 }; // get these values from inspecting results of conn.GetInventoryLocations


//Finally, set up the filter like this:
​
            var lovf = new ListOfValuesFilter(false, new ListOfValuesFilterValues( arrayOfValues ));
            var snf = new SerialNumberFilter();
            snf.AddListOfValuesFilter(SerialNumberFilter.SerialNumberListOfValuesFilterFields_Enum.InventoryLocation, lovf);
            var SNs = conn.GetSerialNumbers(snf, new PagingOptions(0, 99999));
