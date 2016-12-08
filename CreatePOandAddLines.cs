            // spelunk to get the needed cost list id (needed if you want to create a PO) - do this in a separate program
            var cls = conn.GetCostLists();
            foreach (var cl in cls)
            {
                System.Console.WriteLine("{0} - {1} - {2} - {3}", cl.CostListId, cl.CostListName, cl.SupplierId, cl.SupplierName);
            }

            // create the purchase order OBJECT (not yet in db)
            var po = new PurchaseOrder(31, 0); // "standard" is probably 0

            // you'll get an exception if you don't set the ship-to location
            po.ShipToLocationId = 1; // view page source on ship-to locations or write program to find desired id

            // if you want the PO to have an "Ordered" state after adding material, set the order date
            po.OrderDate = DateTime.Now;

            var poid = conn.CreatePurchaseOrder(po); // NOW it's in the db

            // Now you can add a PO line - you'll need to spelunk to find desired purchase product variant id(s)
            var pv = conn.GetPurchaseProductVariant(913545); // purchase product variant - this one is Absolute Black 2cm in my system

            // create the OBJECT (not yet in DB)
            var popl = new PurchaseOrderProductLine(poid, pv);

            // now add measurements - if you don't, you'll get an exception that explains they are missing

            var m1 = new Measurement(60);
            var m2 = new Measurement(new decimal(120.3));
            popl.Measurements.AddMeasurement(m1);
            popl.Measurements.AddMeasurement(m2);
            popl.OrderedQuantity = 3; // if you don't add this, you'll have a 0 quantity, which is weird

            // Now create the actual product line (which adds it to the db - you can refresh the UI to see it)
            var poplid = conn.CreatePurchaseOrderProductLine(popl); // poplid can be used to find the line again to change it

            // If the product is serialized, then you can get serial numbers before receiving them
            var usns = conn.CreateUnreceivedSerialNumbers(poplid);
